using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeHZ.HeroLab2MapTool.Core {
    public class FileEntryEventArgs: EventArgs {

        public FileEntryEventArgs() {
        }

        public FileEntryEventArgs(string path) {
            FilePath = Path.GetDirectoryName(path);
            FileName = Path.GetFileName(path);
            FileExtension = Path.GetExtension(path);
            FullPath = path;

            switch (FileExtension) {
                case ".por":
                    FileType = FileEntryType.Portifolio;
                    break;
                case ".jpg":
                case ".png":
                case ".gif":
                case ".jpeg":
                    FileType = FileEntryType.Image;
                    break;
                default:
                    FileType = FileEntryType.All;
                    break;
            }
        }

        public string FilePath          { get; internal set; }
        public string FileName          { get; internal set; }
        public string FileExtension     { get; internal set; }
        public FileEntryType FileType   { get; internal set; }
        public string FullPath          { get; internal set; }
    }
}
