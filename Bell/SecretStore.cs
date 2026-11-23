using System;
using System.Security.Cryptography;
using System.Text;

namespace Prunel
{
    /// <summary>
    /// Keeps a secret (the Voice Monkey token) in the settings file without writing it in clear.
    ///
    /// It uses the Windows "data protection" (DPAPI, ProtectedData class of .NET Framework,
    /// assembly System.Security: no extra library). The secret is encrypted for the current
    /// Windows account of this computer: another account, or another computer, cannot read
    /// it. That is why a profile does not carry the token (see SettingsProfiles).
    /// The secret is never written in the log.
    /// </summary>
    internal static class SecretStore
    {
        // A fixed extra key: a value encrypted by another program with DPAPI cannot be mixed up
        // with ours.
        private static readonly byte[] Entropy = Encoding.UTF8.GetBytes("Prunel.SecretStore.v1");

        /// <summary>Encrypts the secret; returns "" for an empty secret.</summary>
        public static string Protect(string secret)
        {
            if (string.IsNullOrEmpty(secret))
            {
                return "";
            }
            byte[] data = ProtectedData.Protect(Encoding.UTF8.GetBytes(secret), Entropy, DataProtectionScope.CurrentUser);
            return Convert.ToBase64String(data);
        }

        /// <summary>
        /// Decrypts a value written by Protect. Returns "" when there is none, or when it cannot
        /// be read (written by another Windows account, damaged file...).
        /// </summary>
        public static string Unprotect(string stored)
        {
            if (string.IsNullOrEmpty(stored))
            {
                return "";
            }
            try
            {
                byte[] data = ProtectedData.Unprotect(Convert.FromBase64String(stored), Entropy, DataProtectionScope.CurrentUser);
                return Encoding.UTF8.GetString(data);
            }
            catch (Exception e)
            {
                App.Log("Secret store: cannot read a stored secret (" + e.GetType().Name + ")");
                return "";
            }
        }
    }
}
