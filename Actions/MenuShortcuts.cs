using System;

namespace Prunel
{
    /// <summary>
    /// The buttons that can be placed in the SHORTCUTS COLUMN of the menu (step shortcuts-menu,
    /// issue #147). The column has four places; each one holds one of these buttons, or nothing.
    /// They are chosen in the settings ("Actions" category, "Shortcuts" tab), see
    /// AppSettings.Shortcut1 … Shortcut4 and MenuMode.PlaceShortcuts.
    ///
    /// Each button has:
    ///   - its NAME, saved in the settings file ("applications", "game"…): a word rather than a
    ///     number, so that adding a button later does not shift the saved choices;
    ///   - its TEXT KEY in the language files ("shortcut.applications" → "Applications"), for
    ///     the settings.
    /// The list grows over time: add the name here, its text in en.json and fr.json, and its
    /// button in MenuMode.AddShortcut.
    /// </summary>
    internal static class MenuShortcuts
    {
        /// <summary>No button: the place stays empty (the column is then shorter).</summary>
        public const string None = "none";

        public const string Applications = "applications";
        public const string Game = "game";
        public const string Bell = "bell";
        public const string MouseTracking = "mouseTracking";
        public const string Quit = "quit";

        /// <summary>The names, in the order of the settings choice.</summary>
        private static readonly string[] Names =
        {
            None, Applications, Game, Bell, MouseTracking, Quit
        };

        /// <summary>The text keys, same order as Names (for Setting.Choice).</summary>
        public static readonly string[] TextKeys =
        {
            "shortcut.none", "shortcut.applications", "shortcut.game", "shortcut.bell",
            "shortcut.mouseTracking", "shortcut.quit"
        };

        /// <summary>The place of a name in the list; 0 (no button) if the name is unknown.</summary>
        public static int IndexOf(string name)
        {
            int index = Array.IndexOf(Names, name ?? "");
            return index < 0 ? 0 : index;
        }

        /// <summary>The name at a place of the list (brought back within the list).</summary>
        public static string NameAt(int index)
        {
            return Names[Math.Max(0, Math.Min(Names.Length - 1, index))];
        }

        /// <summary>The name itself if it is known, "none" otherwise (typo in the file…).</summary>
        public static string Known(string name)
        {
            return NameAt(IndexOf((name ?? "").Trim()));
        }
    }
}
