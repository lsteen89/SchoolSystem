using SchoolSystemLibary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystemLibary.Login
{
    public class UserSession
    {
        public string Username { get; set; }
        public string Roles { get; set; }
        public string Persoid{ get; set; }

        public List<string> RoleList
        {
            get
            {
                if (string.IsNullOrEmpty(Roles))
                {
                    return new List<string>();
                }
                return Roles.Split(',').Select(role => role.Trim()).ToList();
            }
        }
    }

}
