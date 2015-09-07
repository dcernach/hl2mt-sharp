using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;
using Newtonsoft.Json;
using MeHZ.HeroLab2MapTool.Core.Configuration;
using Newtonsoft.Json.Linq;

namespace MeHZ.HeroLab2MapTool.Core {
    public static class ConfigurationManager {
        private const string DEFAULT_EMBEDDED_CONFIG = "MeHZ.HeroLab2MapTool.Core.Configuration.DefaultConfig.json";
        private const string DEFAULT_FILENAME_CONFIG = "HeroLab2MapTool.hl2mt";


        static ConfigurationManager() {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            ConfigurationFile = Path.Combine(path, DEFAULT_FILENAME_CONFIG);
            Read();
        }


        public static string ConfigurationFile { get; private set; }


        public static GlobalConfig Settings { get; private set; }


        public static void Export(string outputPath) {
            if (Settings == null) {
                Read();
            }

            var json = JsonConvert.SerializeObject(Settings, Formatting.Indented);
            File.WriteAllText(outputPath, json, Encoding.UTF8);
        }


        public static void Import(string inputPath) {
            if (Settings == null) {
                Read();
            }

            var originalFile = File.ReadAllText(ConfigurationFile, Encoding.UTF8);
            var exportedFile = File.ReadAllText(inputPath, Encoding.UTF8);


            var obj1 = JObject.Parse(originalFile);
            var obj2 = JObject.Parse(exportedFile);


            obj1.Merge(obj2, new JsonMergeSettings() {
                MergeArrayHandling = MergeArrayHandling.Union
            });

            Settings = JsonConvert.DeserializeObject<GlobalConfig>(obj1.ToString(Formatting.Indented));
        }


        public static void Read() {
            if (!File.Exists(ConfigurationFile)) {
                Reset();
                Save();
            }

            var json = File.ReadAllText(ConfigurationFile, Encoding.UTF8);
            Settings = JsonConvert.DeserializeObject<GlobalConfig>(json);
        }


        public static void Reset() {
            var assembly = typeof(ConfigurationManager).Assembly;
            var config = string.Empty;

            using (var stream = assembly.GetManifestResourceStream(DEFAULT_EMBEDDED_CONFIG)) {
                using (var reader = new StreamReader(stream)) {
                    config = reader.ReadToEnd();
                }
            }

            Settings = JsonConvert.DeserializeObject<GlobalConfig>(config);
        }


        public static void Save() {
            if (Settings == null || !File.Exists(ConfigurationFile)) {
                Reset();
            }

            var json = JsonConvert.SerializeObject(Settings, Formatting.Indented);
            File.WriteAllText(ConfigurationFile, json, Encoding.UTF8);
        }
    }
}