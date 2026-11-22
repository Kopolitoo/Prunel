using System.Threading.Tasks;

namespace Prunel
{
    /// <summary>
    /// A CALL BELL (step call-bell): one way of calling someone. Each kind of bell is a
    /// class of its own: today ComputerBell (a loud sound on this computer); later, for
    /// example, a bell on an Alexa speaker (Voice Monkey) or on a Google speaker.
    /// BellRinger rings all the bells that are on, each one on its own side.
    /// </summary>
    internal interface IBell
    {
        /// <summary>A short name for the log, in English (for example "computer").</summary>
        string Name { get; }

        /// <summary>True if the user turned this bell on in the settings ("Bell" tab).</summary>
        bool IsOn(AppSettings settings);

        /// <summary>
        /// Rings the bell. The result says whether the call left (true) or failed (false).
        /// It is a Task so that a bell that goes through the network can answer later
        /// without blocking the gaze. It must never throw: a failure returns false.
        /// </summary>
        Task<bool> RingAsync(AppSettings settings);
    }
}
