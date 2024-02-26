using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PasswordManager {
    internal class FileReadAndWrite : IReadAndWriteToFile {
        public string ReadFromFile(string fileName) {
            if (File.Exists(fileName)) {
                return File.ReadAllText(fileName);
            }
            else {
                throw new FileNotFoundException($"File {fileName} not found");
            }
        }

        public void WriteToFile(string data, string fileName) {
            File.WriteAllText(fileName, data);
        }
    }
}
