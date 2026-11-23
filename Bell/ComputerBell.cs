using System;
using System.IO;
using System.Media;
using System.Threading.Tasks;

namespace Prunel
{
    /// <summary>
    /// THE COMPUTER BELL (step call-bell): a loud "ding-dong", repeated for [BellDuration]
    /// seconds, on this computer. It goes to the default Windows output: the computer's
    /// speakers, or a Bluetooth speaker if Windows plays its sounds there.
    ///
    /// Like the sound feedback (see SoundFeedback), the sound is not a file: it is computed
    /// as a WAV in memory and played with System.Media.SoundPlayer (provided with .NET
    /// Framework 4.8, no extra library). It is computed again only when [BellDuration] or
    /// [BellVolume] changed.
    ///
    /// WINDOWS VOLUME ([BellWindowsVolume], 80 % by default, 0 = not touched): while the bell
    /// rings, the Windows volume is raised to this level (if it is lower) and the sound is
    /// unmuted; when the bell stops, the original volume and mute come back (see WindowsVolume).
    /// A volume already higher is left as it is. If Prunel closes while the bell rings, the
    /// volume is put back too (App.OnExit calls RestoreVolume).
    ///
    /// Windows plays only one SoundPlayer sound at a time: while the bell rings, the short
    /// sounds of the keys and buttons are skipped, so that they do not cut it (see IsRinging).
    /// </summary>
    internal sealed class ComputerBell : IBell
    {
        // One "ding-dong": two notes (E5 then C5), then a short silence.
        private const double NoteSeconds = 0.6;
        private const double SilenceSeconds = 0.4;
        private static readonly double[] Notes = { 659.25, 523.25 };

        // The sound ready to play, and the settings it was made with.
        private static SoundPlayer _player;
        private static double _madeDuration = -1;
        private static double _madeVolume = -1;

        // Until when the bell rings (UTC; MinValue = it does not ring).
        private static DateTime _ringsUntil = DateTime.MinValue;

        // The Windows volume and mute before the bell raised them (only while _volumeRaised).
        private static bool _volumeRaised;
        private static float _originalLevel;
        private static bool _originalMuted;

        /// <summary>True while the bell rings: the sound feedback then keeps quiet.</summary>
        public static bool IsRinging
        {
            get { return DateTime.UtcNow < _ringsUntil; }
        }

        public string Name
        {
            get { return "computer"; }
        }

        public bool IsOn(AppSettings settings)
        {
            return settings.ComputerBell;
        }

        public Task<bool> RingAsync(AppSettings settings)
        {
            try
            {
                if (_player == null || _madeDuration != settings.BellDuration || _madeVolume != settings.BellVolume)
                {
                    _player = MakePlayer(settings.BellDuration, settings.BellVolume);
                    _madeDuration = settings.BellDuration;
                    _madeVolume = settings.BellVolume;
                }
                RaiseVolume(settings.BellWindowsVolume);
                // Play() returns at once: the sound plays in the background.
                _player.Play();
                double seconds = Cycles(settings.BellDuration) * CycleSeconds;
                _ringsUntil = DateTime.UtcNow.AddSeconds(seconds);
                if (_volumeRaised)
                {
                    RestoreVolumeLater(seconds);
                }
                return Task.FromResult(true);
            }
            catch (Exception e)
            {
                _player = null;
                App.Log("Bell (computer): cannot play the sound (" + e.Message + ")");
                return Task.FromResult(false);
            }
        }

        /// <summary>
        /// Raises the Windows volume to percent (if it is lower) and unmutes it, keeping the
        /// original values to put them back. 0 = nothing changes. If the bell rings again while
        /// the volume is already raised, the original values stay the first ones.
        /// </summary>
        private static void RaiseVolume(double percent)
        {
            if (percent <= 0)
            {
                return;
            }
            float target = (float)(percent / 100.0);
            float level;
            bool muted;
            if (!_volumeRaised)
            {
                if (!WindowsVolume.TryGet(out level, out muted))
                {
                    return;
                }
                if (level >= target && !muted)
                {
                    return;   // loud enough already: nothing to change, nothing to put back
                }
                _originalLevel = level;
                _originalMuted = muted;
            }
            else
            {
                level = _originalLevel;
            }
            if (WindowsVolume.TrySet(Math.Max(level, target), false))
            {
                _volumeRaised = true;
                App.LogDetail("Bell (computer): Windows volume raised");
            }
        }

        /// <summary>
        /// Puts the volume back once the bell has stopped. If the bell rang again meanwhile,
        /// the later call does it.
        /// </summary>
        private static async void RestoreVolumeLater(double seconds)
        {
            // A small margin: the end of the sound is still playing.
            await Task.Delay(TimeSpan.FromSeconds(seconds + 0.3));
            if (DateTime.UtcNow >= _ringsUntil)
            {
                RestoreVolume();
            }
        }

        /// <summary>Puts the Windows volume and mute back as they were before the bell, if it raised them.</summary>
        public static void RestoreVolume()
        {
            if (!_volumeRaised)
            {
                return;
            }
            _volumeRaised = false;
            WindowsVolume.TrySet(_originalLevel, _originalMuted);
            App.LogDetail("Bell (computer): Windows volume put back");
        }

        private static double CycleSeconds
        {
            get { return Notes.Length * NoteSeconds + SilenceSeconds; }
        }

        /// <summary>How many "ding-dong" fit in this duration (at least one).</summary>
        private static int Cycles(double durationSeconds)
        {
            return Math.Max(1, (int)Math.Round(durationSeconds / CycleSeconds));
        }

        /// <summary>
        /// Builds the sound: [Cycles] "ding-dong" one after the other. Each note fades slowly,
        /// like a real bell, with a quieter second harmonic (twice the frequency) that gives
        /// it its "metal" colour. A very short rise at the start of each note avoids a "crack".
        /// volumePercent: 10 to 100 % of the loudest sound (the Windows volume still applies).
        /// </summary>
        private static SoundPlayer MakePlayer(double durationSeconds, double volumePercent)
        {
            int rate = SoundFeedback.SampleRate;
            int perNote = (int)(rate * NoteSeconds);
            int perCycle = (int)(rate * CycleSeconds);
            int cycles = Cycles(durationSeconds);
            int rise = rate / 1000 * 3;   // 3 ms
            // 0.9 at most: a small margin below the loudest value, so that nothing crackles.
            double volume = 0.9 * volumePercent / 100.0;

            short[] samples = new short[perCycle * cycles];
            for (int c = 0; c < cycles; c++)
            {
                for (int n = 0; n < Notes.Length; n++)
                {
                    int first = c * perCycle + n * perNote;
                    for (int i = 0; i < perNote; i++)
                    {
                        double t = (double)i / rate;
                        double fade = Math.Exp(-4.0 * i / perNote);
                        double start = i < rise ? (double)i / rise : 1.0;
                        double wave = 0.75 * Math.Sin(2 * Math.PI * Notes[n] * t)
                                    + 0.25 * Math.Sin(2 * Math.PI * 2 * Notes[n] * t);
                        samples[first + i] = (short)(wave * fade * start * volume * short.MaxValue);
                    }
                }
                // The rest of the cycle stays at 0: the silence.
            }

            SoundPlayer player = new SoundPlayer(new MemoryStream(SoundFeedback.ToWav(samples)));
            player.Load();
            return player;
        }
    }
}
