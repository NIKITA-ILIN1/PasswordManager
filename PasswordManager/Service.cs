using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager {
    internal class Service {
        public string NameService { get; set; }
        public string LoginService { get; set; }
        public string PasswordService { get; set; }

        public Service(string iNameService, string iLoginService, string iPasswordService)
        {
            this.NameService = iNameService;
            this.LoginService = iLoginService;
            this.PasswordService = iPasswordService;
        }
    }
}
