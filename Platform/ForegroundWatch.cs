using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace Prunel
{
    /// <summary>
    /// Writes to the detailed log each time the ACTIVE window changes (the window that
    /// receives the keyboard, including the keys sent by Dragon).
    ///
    /// Why: the user sometimes sees Dragon's shortcuts (page back, page forward) go nowhere
    /// until he clicks in the page. Prunel's overlay is built never to take the focus
    /// (WS_EX_NOACTIVATE, see OverlayWindow), but a few modes do change the active window on
    /// purpose (scroll mode, settings window, Diagnostic window). This log tells, in testing,
    /// which program became active and when, next to the "Mode: ..." lines.
    ///
    /// Only the program name and the window class are written, never the window title (a web
    /// page title could be personal) and never a position.
    ///
    /// How: Windows calls OnForegroundChanged through SetWinEventHook. "Out of context" means
    /// the call arrives in Prunel's own display thread (through its message loop), not inside
    /// the other program.
    /// </summary>
    internal sealed class ForegroundWatch : IDisposable
    {
        private IntPtr _hook;
        // The delegate must stay alive as long as the hook exists: if the garbage collector
        // freed it, Windows would call a function that no longer exists (crash).
        private NativeMethods.WinEventProc _callback;
        private readonly uint _myProcess = (uint)Process.GetCurrentProcess().Id;

        /// <summary>Starts watching. A failure is only logged: Prunel works without it.</summary>
        public void Install()
        {
            _callback = OnForegroundChanged;
            _hook = NativeMethods.SetWinEventHook(
                NativeMethods.EVENT_SYSTEM_FOREGROUND, NativeMethods.EVENT_SYSTEM_FOREGROUND,
                IntPtr.Zero, _callback, 0, 0, NativeMethods.WINEVENT_OUTOFCONTEXT);
            if (_hook == IntPtr.Zero)
            {
                App.Log("Active window watch: cannot be started");
            }
        }

        /// <summary>Called by Windows when another window becomes active.</summary>
        private void OnForegroundChanged(IntPtr hook, uint eventType, IntPtr window,
                                         int objectId, int childId, uint thread, uint timeMs)
        {
            // Cheap test first: nothing to do when the detailed log is off.
            AppSettings settings = AppSettings.Current;
            if (settings == null || !settings.DetailedLog || window == IntPtr.Zero)
            {
                return;
            }
            try
            {
                uint process;
                NativeMethods.GetWindowThreadProcessId(window, out process);
                string name;
                if (process == _myProcess)
                {
                    name = "PRUNEL";
                }
                else
                {
                    using (Process other = Process.GetProcessById((int)process))
                    {
                        name = other.ProcessName;
                    }
                }
                StringBuilder className = new StringBuilder(128);
                NativeMethods.GetClassName(window, className, className.Capacity);
                App.LogDetail("Active window: " + name + " (" + className + ")");
            }
            catch (Exception ex)
            {
                // The program may have closed in the meantime: only logged.
                App.LogDetail("Active window: unknown (" + ex.Message + ")");
            }
        }

        public void Dispose()
        {
            if (_hook != IntPtr.Zero)
            {
                NativeMethods.UnhookWinEvent(_hook);
                _hook = IntPtr.Zero;
            }
        }
    }
}
