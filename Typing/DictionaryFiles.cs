using System;
using System.Collections.Generic;
using System.IO;

namespace Prunel
{
    /// <summary>An exported dictionary found in the dictionaries folder (issue #164).</summary>
    internal sealed class FoundDictionary
    {
        public string Name;
        public string Path;
        public DateTime Date;

        /// <summary>True for the automatic backup made before each "Replace".</summary>
        public bool IsBackup
        {
            get { return string.Equals(Name, DictionaryFiles.BackupName, StringComparison.OrdinalIgnoreCase); }
        }

        /// <summary>The name shown to the user: the file name, or "Automatic backup" for the backup.</summary>
        public string DisplayName
        {
            get { return IsBackup ? Texts.Get("dictionaries.backupName") : Name; }
        }
    }

    /// <summary>
    /// EXPORTED DICTIONARIES (issue #164). The predictive keyboard learns as it is used
    /// ("My words", usage counts, next words: personal-dictionary.json). To keep this
    /// learning (another computer, a backup), the "Prediction" tab of the settings can:
    ///   - EXPORT: write a dated copy in Documents\Prunel\Dictionaries;
    ///   - MERGE: choose an exported copy in a list; its words and counts are added to the
    ///     current ones (nothing is lost);
    ///   - REPLACE: choose a copy, confirm with "Yes"; the personal dictionary becomes that
    ///     copy. The current one is first kept as "auto-backup" in the same folder
    ///     (replaced on each "Replace"), so one can go back by replacing with it.
    /// Like the profiles, the files stay on the user's computer, never in the repository, and
    /// no word is written to the log. Deleting old copies is done in Explorer.
    /// </summary>
    internal static class DictionaryFiles
    {
        /// <summary>
        /// The FILE name of the copy written before each "Replace". It does not depend on
        /// the language; the user sees "dictionaries.backupName" instead.
        /// </summary>
        public const string BackupName = "auto-backup";

        /// <summary>The dictionaries folder: Documents\Prunel\Dictionaries.</summary>
        public static string Folder
        {
            get
            {
                string documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                return Path.Combine(documents, "Prunel", "Dictionaries");
            }
        }

        /// <summary>The .json files of the folder, the most recent first (empty if none).</summary>
        public static List<FoundDictionary> List()
        {
            List<FoundDictionary> found = new List<FoundDictionary>();
            try
            {
                if (!Directory.Exists(Folder))
                {
                    return found;
                }
                foreach (string path in Directory.GetFiles(Folder, "*.json"))
                {
                    FoundDictionary d = new FoundDictionary();
                    d.Path = path;
                    d.Name = Path.GetFileNameWithoutExtension(path);
                    d.Date = File.GetLastWriteTime(path);
                    found.Add(d);
                }
            }
            catch (Exception ex)
            {
                App.Log("Dictionaries: unreadable folder: " + ex.Message);
            }
            found.Sort((a, b) => b.Date.CompareTo(a.Date));
            return found;
        }

        /// <summary>
        /// "Export": writes a dated copy, for example "Dictionnaire 2026-11-25 20h15.json" (name
        /// in the interface language). Returns the message to show (where it went, or the
        /// failure).
        /// </summary>
        public static string Export(WordPredictor predictor)
        {
            string name = Texts.Format("dictionaries.fileName", DateTime.Now.ToString("yyyy-MM-dd HH'h'mm"));
            string path = Path.Combine(Folder, name + ".json");
            return predictor.ExportTo(path)
                ? Texts.Format("dictionaries.exported", path)
                : Texts.Get("dictionaries.exportFailed");
        }

        /// <summary>"Merge": adds the chosen copy to the personal dictionary. Returns the message to show.</summary>
        public static string Merge(WordPredictor predictor, FoundDictionary dictionary)
        {
            return predictor.ImportFrom(dictionary.Path, false)
                ? Texts.Format("dictionaries.merged", dictionary.DisplayName)
                : Texts.Get("dictionaries.unreadable");
        }

        /// <summary>
        /// "Replace" (after "Yes"): first keeps the current dictionary as "auto-backup" (unless
        /// the backup itself is the chosen file), then replaces it with the chosen copy. Without
        /// a backup nothing is replaced. Returns the message to show.
        /// </summary>
        public static string Replace(WordPredictor predictor, FoundDictionary dictionary)
        {
            if (!dictionary.IsBackup && !predictor.ExportTo(Path.Combine(Folder, BackupName + ".json")))
            {
                return Texts.Get("dictionaries.backupFailed");
            }
            return predictor.ImportFrom(dictionary.Path, true)
                ? Texts.Format("dictionaries.replaced", dictionary.DisplayName)
                : Texts.Get("dictionaries.unreadable");
        }
    }
}
