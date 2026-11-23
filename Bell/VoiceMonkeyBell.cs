using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Prunel
{
    /// <summary>
    /// THE ALEXA BELL (step call-bell, part 2), through the Voice Monkey service
    /// (voicemonkey.io, an Alexa skill).
    ///
    /// How it works: in the Voice Monkey console, the user creates a "routine trigger" (a
    /// virtual device). In the Alexa app, a routine starts when this device is "pressed": it
    /// plays a doorbell sound, says a sentence, sends a notification... Prunel only asks Voice
    /// Monkey to press it:
    ///     POST https://api-v3.voicemonkey.io/trigger
    ///     Authorization: Bearer [token]
    ///     { "device": "[VoiceMonkeyDevice]" }
    /// The answer is {"success": true, ...} when the routine was started.
    ///
    /// The request uses HttpClient (System.Net.Http, part of .NET Framework: no extra
    /// library). It gives up after [TimeoutSeconds]. Nothing about the gaze or the typed text
    /// is sent: only "press this device". The token is stored encrypted (see SecretStore) and
    /// never written in the log; it goes in a header, not in the web address.
    /// </summary>
    internal sealed class VoiceMonkeyBell : IBell
    {
        /// <summary>The Voice Monkey address that presses a routine trigger (API version 3).</summary>
        private const string TriggerUrl = "https://api-v3.voicemonkey.io/trigger";

        /// <summary>After this many seconds without an answer, the call counts as failed.</summary>
        private const int TimeoutSeconds = 10;

        // One HttpClient for the whole program (the recommended use: it reuses the connection).
        private static readonly HttpClient Client = CreateClient();

        /// <summary>
        /// The language key of the reason of the last failure (for the settings "Test" button),
        /// or null after a success.
        /// </summary>
        public static string LastErrorKey { get; private set; }

        public string Name
        {
            get { return "Alexa"; }
        }

        /// <summary>On when the setting is on AND a token and a device are filled in.</summary>
        public bool IsOn(AppSettings settings)
        {
            return settings.AlexaBell && IsReady(settings);
        }

        /// <summary>True when a token and a device are filled in.</summary>
        public static bool IsReady(AppSettings settings)
        {
            return !string.IsNullOrEmpty(settings.VoiceMonkeyTokenProtected)
                && !string.IsNullOrEmpty(settings.VoiceMonkeyDevice);
        }

        /// <summary>Stores the token, encrypted ("" removes it).</summary>
        public static void SaveToken(AppSettings settings, string token)
        {
            settings.VoiceMonkeyTokenProtected = SecretStore.Protect((token ?? "").Trim());
        }

        public Task<bool> RingAsync(AppSettings settings)
        {
            return TriggerAsync(settings);
        }

        /// <summary>
        /// Presses the routine trigger. Returns true when Voice Monkey answers that the routine
        /// started. Never throws: a failure returns false and sets LastErrorKey.
        /// </summary>
        public static async Task<bool> TriggerAsync(AppSettings settings)
        {
            string token = SecretStore.Unprotect(settings.VoiceMonkeyTokenProtected);
            string device = (settings.VoiceMonkeyDevice ?? "").Trim();
            if (token.Length == 0 || device.Length == 0)
            {
                LastErrorKey = "bell.alexa.error.notReady";
                return false;
            }

            try
            {
                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, TriggerUrl))
                {
                    request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                    string json = "{\"device\":\"" + JsonEscape(device) + "\"}";
                    request.Content = new StringContent(json, Encoding.UTF8, "application/json");

                    using (HttpResponseMessage response = await Client.SendAsync(request))
                    {
                        string body = await response.Content.ReadAsStringAsync();
                        int code = (int)response.StatusCode;
                        if (response.IsSuccessStatusCode && Regex.IsMatch(body, "\"success\"\\s*:\\s*true"))
                        {
                            LastErrorKey = null;
                            return true;
                        }
                        LastErrorKey = ErrorKey(code);
                        // The answer holds an error code (INVALID_TOKEN...), never the token.
                        App.Log("Bell (Alexa): Voice Monkey answered " + code + " " + Shorten(body));
                        return false;
                    }
                }
            }
            catch (TaskCanceledException)
            {
                LastErrorKey = "bell.alexa.error.network";
                App.Log("Bell (Alexa): no answer after " + TimeoutSeconds + " s");
                return false;
            }
            catch (Exception e)
            {
                LastErrorKey = "bell.alexa.error.network";
                App.Log("Bell (Alexa): request failed (" + e.GetType().Name + ": " + e.Message + ")");
                return false;
            }
        }

        private static HttpClient CreateClient()
        {
            // Old Windows settings may still allow only old TLS versions: TLS 1.2 is asked for
            // explicitly, as the service requires it.
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
            HttpClient client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(TimeoutSeconds);
            return client;
        }

        /// <summary>The language key that explains an HTTP error code of Voice Monkey.</summary>
        private static string ErrorKey(int code)
        {
            switch (code)
            {
                case 401:
                    return "bell.alexa.error.token";
                case 400:
                case 404:
                    return "bell.alexa.error.device";
                case 429:
                    return "bell.alexa.error.quota";
                default:
                    return "bell.alexa.error.other";
            }
        }

        /// <summary>Escapes the quotes and backslashes of a JSON text value.</summary>
        private static string JsonEscape(string text)
        {
            StringBuilder b = new StringBuilder();
            foreach (char c in text)
            {
                if (c == '"' || c == '\\')
                {
                    b.Append('\\');
                }
                if (c >= ' ')
                {
                    b.Append(c);
                }
            }
            return b.ToString();
        }

        /// <summary>At most 200 characters of an answer, on one line, for the log.</summary>
        private static string Shorten(string body)
        {
            string line = (body ?? "").Replace('\r', ' ').Replace('\n', ' ');
            return line.Length <= 200 ? line : line.Substring(0, 200) + "…";
        }
    }
}
