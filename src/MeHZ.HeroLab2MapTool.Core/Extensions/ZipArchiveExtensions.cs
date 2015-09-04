using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeHZ.HeroLab2MapTool.Core.Extensions {
    public static class ZipArchiveExtensions {
        public static Stream GetEntryAsStream(this ZipArchive zip, string entryName) {
            var zipEntry = zip.GetEntry(entryName);
            var stream = zipEntry.Open();
            return stream;
        }

        public static string GetEntryAsString(this ZipArchive zip, string entryName) {
            var zipEntry = zip.GetEntry(entryName);
            var streamReader = new StreamReader(zipEntry.Open());
            var contents = streamReader.ReadToEnd();
            return contents;
        }

        public static MemoryStream OpenAsMemoryStream(this ZipArchiveEntry entry) {
            var memoStream = new MemoryStream();
            var gzipStream = entry.Open();
            gzipStream.CopyTo(memoStream);
            memoStream.Position = 0;
            return memoStream;
        }
    }
}
