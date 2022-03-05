using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordWSS {
    public class Save {

        public static bool SaveData(string name) {

            string currentDirName = Directory.GetCurrentDirectory() + Program.Save_dir_name;
            string[] files = Directory.GetFiles(currentDirName, "*.*");

            foreach(string fis in files) {
                FileInfo fi = null;
                try {
                    fi = new FileInfo(fis);
                }
                catch(FileNotFoundException e) {
                    Console.WriteLine(e.Message);
                    continue;
                }
                if(fi.Name == name)
                    return true;
                else
                    return false;
            }
            return false;
        }
    }
}
