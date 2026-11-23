using System;
using System.Runtime.InteropServices;

namespace Prunel
{
    /// <summary>
    /// PLATFORM: reads and changes the volume of the default Windows output (the one of the
    /// volume icon of the taskbar), and its mute.
    ///
    /// It uses "Core Audio", the Windows sound interface, through COM: the three interfaces
    /// below are declared here as Windows describes them (their methods MUST stay in this
    /// order). No extra library. Used by the computer bell (see ComputerBell), which raises the
    /// volume while it rings, then puts it back.
    /// Every method catches its errors (no sound card...) and returns false: a volume problem
    /// must not stop the bell.
    /// </summary>
    internal static class WindowsVolume
    {
        /// <summary>
        /// Reads the volume (0 to 1) and the mute of the default output. Returns false when it
        /// cannot be read.
        /// </summary>
        public static bool TryGet(out float level, out bool muted)
        {
            level = 0;
            muted = false;
            IAudioEndpointVolume volume = Open();
            if (volume == null)
            {
                return false;
            }
            try
            {
                Marshal.ThrowExceptionForHR(volume.GetMasterVolumeLevelScalar(out level));
                Marshal.ThrowExceptionForHR(volume.GetMute(out muted));
                return true;
            }
            catch (Exception e)
            {
                App.Log("Windows volume: cannot read it (" + e.Message + ")");
                return false;
            }
            finally
            {
                Marshal.ReleaseComObject(volume);
            }
        }

        /// <summary>Sets the volume (0 to 1) and the mute of the default output. Returns false on failure.</summary>
        public static bool TrySet(float level, bool muted)
        {
            IAudioEndpointVolume volume = Open();
            if (volume == null)
            {
                return false;
            }
            try
            {
                Guid context = Guid.Empty;
                level = Math.Max(0f, Math.Min(1f, level));
                Marshal.ThrowExceptionForHR(volume.SetMasterVolumeLevelScalar(level, ref context));
                Marshal.ThrowExceptionForHR(volume.SetMute(muted, ref context));
                return true;
            }
            catch (Exception e)
            {
                App.Log("Windows volume: cannot change it (" + e.Message + ")");
                return false;
            }
            finally
            {
                Marshal.ReleaseComObject(volume);
            }
        }

        /// <summary>The volume control of the default output (multimedia), or null.</summary>
        private static IAudioEndpointVolume Open()
        {
            IMMDeviceEnumerator enumerator = null;
            IMMDevice device = null;
            try
            {
                enumerator = (IMMDeviceEnumerator)new MMDeviceEnumerator();
                Marshal.ThrowExceptionForHR(enumerator.GetDefaultAudioEndpoint(EDataFlowRender, ERoleMultimedia, out device));
                Guid iid = typeof(IAudioEndpointVolume).GUID;
                object control;
                Marshal.ThrowExceptionForHR(device.Activate(ref iid, ClsCtxAll, IntPtr.Zero, out control));
                return (IAudioEndpointVolume)control;
            }
            catch (Exception e)
            {
                App.Log("Windows volume: no sound output (" + e.Message + ")");
                return null;
            }
            finally
            {
                if (device != null)
                {
                    Marshal.ReleaseComObject(device);
                }
                if (enumerator != null)
                {
                    Marshal.ReleaseComObject(enumerator);
                }
            }
        }

        // ───────────────────────── Core Audio (COM) ─────────────────────────

        private const int EDataFlowRender = 0;     // eRender: the output (speakers)
        private const int ERoleMultimedia = 1;     // eMultimedia: music, films, sounds
        private const int ClsCtxAll = 0x17;        // CLSCTX_ALL

        [ComImport]
        [Guid("BCDE0395-E52F-467C-8E3D-C4579291692E")]
        private class MMDeviceEnumerator
        {
        }

        [ComImport]
        [Guid("A95664D2-9614-4F35-A746-DE8DB63617E6")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IMMDeviceEnumerator
        {
            [PreserveSig] int EnumAudioEndpoints(int dataFlow, int stateMask, out IntPtr devices);
            [PreserveSig] int GetDefaultAudioEndpoint(int dataFlow, int role, out IMMDevice device);
        }

        [ComImport]
        [Guid("D666063F-1587-4E43-81F1-B948E807363F")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IMMDevice
        {
            [PreserveSig] int Activate(ref Guid iid, int clsCtx, IntPtr activationParams,
                                       [MarshalAs(UnmanagedType.IUnknown)] out object anInterface);
        }

        [ComImport]
        [Guid("5CDF2C82-841E-4546-9722-0CF74078229A")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IAudioEndpointVolume
        {
            [PreserveSig] int RegisterControlChangeNotify(IntPtr notify);
            [PreserveSig] int UnregisterControlChangeNotify(IntPtr notify);
            [PreserveSig] int GetChannelCount(out uint count);
            [PreserveSig] int SetMasterVolumeLevel(float levelDb, ref Guid context);
            [PreserveSig] int SetMasterVolumeLevelScalar(float level, ref Guid context);
            [PreserveSig] int GetMasterVolumeLevel(out float levelDb);
            [PreserveSig] int GetMasterVolumeLevelScalar(out float level);
            [PreserveSig] int SetChannelVolumeLevel(uint channel, float levelDb, ref Guid context);
            [PreserveSig] int SetChannelVolumeLevelScalar(uint channel, float level, ref Guid context);
            [PreserveSig] int GetChannelVolumeLevel(uint channel, out float levelDb);
            [PreserveSig] int GetChannelVolumeLevelScalar(uint channel, out float level);
            [PreserveSig] int SetMute([MarshalAs(UnmanagedType.Bool)] bool muted, ref Guid context);
            [PreserveSig] int GetMute([MarshalAs(UnmanagedType.Bool)] out bool muted);
        }
    }
}
