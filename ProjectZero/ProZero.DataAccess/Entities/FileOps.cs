using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProjectZero.Library
{
    class FileOps
    {
        public static void CheckFileExists(string fileName)
        {
            if (!File.Exists(fileName))
            {
                FileStream fs = File.Create(fileName);
                fs.Close();
            }
        }


    }
}
