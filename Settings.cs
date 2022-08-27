using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Newtonsoft.Json;

namespace AttendanceTracker
{
    public class Settings
    {
        public static readonly string SETTINGS_FOLDER_PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Attendance");
        public static readonly string SETTINGS_FILE_PATH = Path.Combine(SETTINGS_FOLDER_PATH, "settings.set");

        private static readonly string DEFAULT_MENTOR_CODE  = "0000";

        [JsonProperty("mentorCode")]
        public Setting MentorCode { get; } = new Setting(DEFAULT_MENTOR_CODE);

        [JsonProperty("studentFile")]
        public Setting StudentFile { get; } = new Setting(AttendanceTracker.StudentFile.DEFAULT_STUDENT_FILE);

        public IEnumerable<Setting> GetAllSettings()
        {
            yield return MentorCode;
            yield return StudentFile;
        }

        public bool Changed()
        {
            return GetAllSettings().Any(s => s.Changed);
        }

        public void Reset()
        {
            GetAllSettings().ToList().ForEach(s => s.Reset());
        }

        public void Save()
        {
            GetAllSettings().ToList().ForEach(s => s.Save());
        }

        public static Settings Load()
        {
            Settings settings = null;

            if (File.Exists(SETTINGS_FILE_PATH))
            {
                settings = File.ReadAllText(SETTINGS_FILE_PATH).Decrypt<Settings>();
            }

            return settings;
        }

        public void Write()
        {
            File.WriteAllText(SETTINGS_FILE_PATH, this.Encrypt());
        }
    }
}
