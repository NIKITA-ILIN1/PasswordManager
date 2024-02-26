using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager {
    internal interface IReadAndWriteToFile {
        public string ReadFromFile(string fileName);
        public void WriteToFile(string data, string fileName);
    }
}
