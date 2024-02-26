using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PasswordManager {
    internal class StreamReadAndWrite : IReadAndWriteToFile {
        public string ReadFromFile(string fileName) {
            if (File.Exists(fileName)) {
                using (StreamReader reader = new StreamReader(fileName)) {
                    return reader.ReadToEnd();
                }
            }
            else {
                throw new FileNotFoundException($"File {fileName} not found");
            }
        }

        public void WriteToFile(string data, string fileName) {
            using (StreamWriter writer = new StreamWriter(fileName)) {
                writer.Write(data);
            }
        }
    }
}
