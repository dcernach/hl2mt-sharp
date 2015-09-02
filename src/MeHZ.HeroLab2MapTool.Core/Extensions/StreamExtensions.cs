using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MeHZ.HeroLab2MapTool.Core.Extensions {
    public static class StreamExtensions {

        public static string ComputeMD5(this Stream stream) {
            if(!stream.CanSeek) {
                throw new InvalidOperationException("Stream is not seekable.");
            }
            using (var md5 = MD5.Create()) {
                var hash = md5.ComputeHash(stream);
                var md5str = BitConverter.ToString(hash);
                stream.Position = 0;
                return md5str.Replace("-", "");
            }
        }
    }
}
