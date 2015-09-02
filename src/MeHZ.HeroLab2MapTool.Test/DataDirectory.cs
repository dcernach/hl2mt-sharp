using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeHZ.HeroLab2MapTool.Test {
    public static class DataDirectory {
        static DataDirectory() {
            ROOT_FOLDER         = Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "..", "test_data");
            PORTIFOLIO_FOLDER   = CreateTestDataFolder("");
            PORTRAIT_FOLDER     = CreateTestDataFolder("portraits");
            POG_FOLDER          = CreateTestDataFolder("pogs");
            TOKEN_FOLDER        = CreateTestDataFolder("tokens");
            TEMPORARY_FOLDER    = CreateTestDataFolder("temp");
        }


        public static string ROOT_FOLDER        { get; private set; }
        public static string PORTIFOLIO_FOLDER  { get; private set; }
        public static string PORTRAIT_FOLDER    { get; private set; }
        public static string POG_FOLDER         { get; private set; }
        public static string TOKEN_FOLDER       { get; private set; }
        public static string TEMPORARY_FOLDER   { get; private set; }


        public static string CreateTestDataFolder(string name) {
            var folder = Path.Combine(ROOT_FOLDER, name);

            if(!Directory.Exists(folder)) {
                Directory.CreateDirectory(folder);
            }

            return folder;
        }
    }
}
