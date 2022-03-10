using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DiscordWSS {
    public class DLImage {

        public static async Task DownloadImageAsync(string directoryPath, string fileName,string ServerName, Uri uri) {
            try {
                Logger.Log(Logger.LogLevel.info, $"Download size: {SizeSuffix(uri.ToString(), 2)}");
                using var httpClient = new HttpClient();

                var uriWithoutQuery = uri.GetLeftPart(UriPartial.Path);
                var fileExtension = Path.GetExtension(uriWithoutQuery);

                if(Save.SaveData(Path.GetFileNameWithoutExtension(uriWithoutQuery)))
                    fileName = Path.GetFileNameWithoutExtension(uriWithoutQuery) + $" ({RandomNumber(0, 5000)})";
                else
                    fileName = Path.GetFileNameWithoutExtension(uriWithoutQuery);

                var path = Path.Combine(directoryPath + "/" + ServerName, $"{fileName}{fileExtension}");

                if(!Directory.Exists(directoryPath + "/" + ServerName)) {
                    try {
                        Directory.CreateDirectory(directoryPath + "/" + ServerName);
                    }
                    catch { }
                }

                var imageBytes = await httpClient.GetByteArrayAsync(uri);
                await File.WriteAllBytesAsync(path, imageBytes);
            }
            catch(WebException e) {
                Logger.Log(Logger.LogLevel.error, "This program is expected to throw WebException on successful run. \n\nException Message :" + e.Message);
            }
        }

        public static readonly string[] SizeSuffixes = { "bytes", "KB", "MB", "GB" };
        public static string SizeSuffix(string url, int decimalPlaces = 1) {

            long result = -1;

            System.Net.WebRequest req = System.Net.WebRequest.Create(url);
            req.Method = "HEAD";
            using(System.Net.WebResponse resp = req.GetResponse()) {
                if(long.TryParse(resp.Headers.Get("Content-Length"), out long ContentLength)) {
                    result = ContentLength;
                }
            }


            //if(decimalPlaces < 0) { throw new ArgumentOutOfRangeException("decimalPlaces"); }
            if(result == 0) { return string.Format("{0:n" + decimalPlaces + "} bytes", 0); }

            int mag = (int)Math.Log(result, 1024);

            decimal adjustedSize = (decimal)result / (1L << (mag * 10));

            if(Math.Round(adjustedSize, decimalPlaces) >= 1000) {
                mag += 1;
                adjustedSize /= 1024;
            }
            
            return string.Format("{0:n" + decimalPlaces + "} {1}", adjustedSize, SizeSuffixes[mag]);

        }

        private static readonly Random _random = new Random();

        public static int RandomNumber(int min, int max) {
            return _random.Next(min, max);
        }
    }
}
