using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prunel
{
    /// <summary>The result of a call (see BellRinger.RingAllAsync).</summary>
    internal enum BellResult
    {
        /// <summary>All the bells that are on rang.</summary>
        Sent,

        /// <summary>Some bells rang, at least one failed.</summary>
        PartlyFailed,

        /// <summary>All the bells that are on failed: the computer bell rang instead.</summary>
        Fallback,

        /// <summary>All the bells that are on failed.</summary>
        Failed,

        /// <summary>No bell is on in the settings: nothing rang.</summary>
        NoBell,

        /// <summary>A call left less than [CooldownSeconds] ago: this one is ignored.</summary>
        TooSoon
    }

    /// <summary>
    /// The CALL BELL (step call-bell): the "Call" button of the menu bar asks this class to
    /// ring. It rings ALL the bells that are on in the settings ("Bell" tab), each one on its
    /// own side: if one fails, the others ring all the same. If ALL of them fail (no internet
    /// for the Alexa bell...) and the computer bell is off, the computer bell rings instead:
    /// someone may still hear it.
    ///
    /// After a call, a new call is ignored for [CooldownSeconds]: looking at the button again
    /// by mistake does not ring twice (useful later for the bells that go through the
    /// network, which have a monthly limit of calls).
    ///
    /// To add a kind of bell later: write a class that implements IBell, then add it to the
    /// "Bells" list below.
    /// </summary>
    internal static class BellRinger
    {
        /// <summary>Seconds after a call during which a new call is ignored.</summary>
        public const double CooldownSeconds = 5;

        /// <summary>All the kinds of bells, in order.</summary>
        private static readonly List<IBell> Bells = new List<IBell>
        {
            new ComputerBell(),
            new VoiceMonkeyBell()
        };

        // The computer bell, also used as the fallback.
        private static readonly IBell Computer = Bells[0];

        // Time of the last call that left (DateTime.MinValue = none yet).
        private static DateTime _lastCall = DateTime.MinValue;

        /// <summary>
        /// Rings all the bells that are on. Returns at once to the caller (the gaze is not
        /// slowed down); the result arrives when every bell has answered.
        /// </summary>
        public static async Task<BellResult> RingAllAsync()
        {
            AppSettings p = AppSettings.Current;
            List<IBell> on = Bells.FindAll(b => b.IsOn(p));
            if (on.Count == 0)
            {
                App.Log("Bell: no bell is on");
                return BellResult.NoBell;
            }

            DateTime now = DateTime.UtcNow;
            if ((now - _lastCall).TotalSeconds < CooldownSeconds)
            {
                App.LogDetail("Bell: call ignored (a call left less than " + CooldownSeconds + " s ago)");
                return BellResult.TooSoon;
            }
            _lastCall = now;

            List<Task<bool>> calls = new List<Task<bool>>();
            foreach (IBell bell in on)
            {
                calls.Add(RingOne(bell, p));
            }
            bool[] results = await Task.WhenAll(calls);
            bool oneRang = Array.IndexOf(results, true) >= 0;
            bool oneFailed = Array.IndexOf(results, false) >= 0;
            if (oneRang)
            {
                return oneFailed ? BellResult.PartlyFailed : BellResult.Sent;
            }

            // Everything failed: the computer bell, if it was not among them, rings instead.
            if (!on.Contains(Computer))
            {
                App.Log("Bell: every bell failed, the computer bell rings instead");
                if (await RingOne(Computer, p))
                {
                    return BellResult.Fallback;
                }
            }
            return BellResult.Failed;
        }

        /// <summary>Rings one bell and logs the result. Never throws.</summary>
        private static async Task<bool> RingOne(IBell bell, AppSettings p)
        {
            bool ok;
            try
            {
                ok = await bell.RingAsync(p);
            }
            catch (Exception e)
            {
                App.Log("Bell (" + bell.Name + "): error (" + e.Message + ")");
                ok = false;
            }
            App.Log("Bell (" + bell.Name + "): " + (ok ? "rang" : "failed"));
            return ok;
        }
    }
}
