using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystemLibary.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string LoginName { get; set; }
        public string Role { get; set; }
        public string Persoid { get; set; }
        public string Regsign { get; set; }
        public DateTime Regtime { get; set; }

    }
}
