using System;
using System.Diagnostics;
using System.Windows.Media;

namespace Prunel
{
    /// <summary>
    /// INTERFACE: simple performance counters, shown in the Diagnostic window.
    ///
    /// They answer three questions, to compare before and after an optimisation:
    ///   - does WPF draw with the graphics card (rendering tier)?
    ///   - how many times per second does the modes clock run (ModeManager)?
    ///   - how many times per second is the circle really moved (OverlayWindow.ShowCircle)?
    /// And the processor time used by Prunel, as a percentage of the whole processor (the same
    /// unit as the Windows Task Manager).
    ///
    /// Only counters: no position is kept (eyetracker licence). Counting costs almost nothing
    /// (one addition), so the counters always run; the rates are computed only while the
    /// Diagnostic window is open.
    /// </summary>
    internal static class RenderStats
    {
        private static long _clockTicks;
        private static long _circleMoves;

        /// <summary>Called by ModeManager on each tick of the modes clock.</summary>
        public static void CountClockTick()
        {
            _clockTicks++;
        }

        /// <summary>Called by OverlayWindow when the circle really changes place or size.</summary>
        public static void CountCircleMove()
        {
            _circleMoves++;
        }

        /// <summary>
        /// WPF rendering tier: 2 = everything drawn by the graphics card, 1 = partly,
        /// 0 = no graphics card help (everything drawn by the processor).
        /// </summary>
        public static int Tier
        {
            get { return RenderCapability.Tier >> 16; }
        }

        // Values at the previous Measure call.
        private static readonly Stopwatch Clock = Stopwatch.StartNew();
        private static double _lastWallMs = -1;
        private static TimeSpan _lastProcessor;
        private static long _lastClockTicks;
        private static long _lastCircleMoves;

        /// <summary>Clock ticks per second, over the last measured period.</summary>
        public static double ClockTicksPerSecond { get; private set; }

        /// <summary>Circle moves per second, over the last measured period.</summary>
        public static double CircleMovesPerSecond { get; private set; }

        /// <summary>Processor used by Prunel, in % of the whole processor (all cores).</summary>
        public static double ProcessorPercent { get; private set; }

        /// <summary>True once a first period has been measured.</summary>
        public static bool HasMeasure { get; private set; }

        /// <summary>
        /// Computes the rates if at least [periodMs] have passed since the previous call.
        /// Returns true if new values are available. The first call only starts the period.
        /// </summary>
        public static bool Measure(double periodMs)
        {
            double now = Clock.Elapsed.TotalMilliseconds;
            if (_lastWallMs >= 0 && now - _lastWallMs < periodMs)
            {
                return false;
            }

            TimeSpan processor;
            using (Process self = Process.GetCurrentProcess())
            {
                processor = self.TotalProcessorTime;
            }
            long ticks = _clockTicks;
            long moves = _circleMoves;

            bool measured = false;
            if (_lastWallMs >= 0)
            {
                double seconds = (now - _lastWallMs) / 1000.0;
                ClockTicksPerSecond = (ticks - _lastClockTicks) / seconds;
                CircleMovesPerSecond = (moves - _lastCircleMoves) / seconds;
                double processorMs = (processor - _lastProcessor).TotalMilliseconds;
                ProcessorPercent = 100.0 * processorMs / ((now - _lastWallMs) * Environment.ProcessorCount);
                HasMeasure = true;
                measured = true;
            }

            _lastWallMs = now;
            _lastProcessor = processor;
            _lastClockTicks = ticks;
            _lastCircleMoves = moves;
            return measured;
        }

        /// <summary>Forgets the previous period (when the Diagnostic window opens).</summary>
        public static void Restart()
        {
            _lastWallMs = -1;
            HasMeasure = false;
        }
    }
}
