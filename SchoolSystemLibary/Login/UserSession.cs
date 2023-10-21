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
        public SecureString LoginName { get; set; }
        public SecureString Role { get; set; }
        public SecureString Persoid { get; set; }
    }

    public class UserSessionManager
    {
        public UserSession CreateCurrentUserSession(UserModel userModel)
        {
            UserSession currentUserSession = new UserSession
            {
                LoginName = CreateSecureString(userModel.LoginName),
                Role = CreateSecureString(userModel.Role),
                Persoid = CreateSecureString(userModel.Persoid)
            };
            return currentUserSession;
        }

        private SecureString CreateSecureString(string value)
        {
            SecureString secureString = new SecureString();
            foreach (char c in value)
            {
                secureString.AppendChar(c);
            }
            secureString.MakeReadOnly();
            return secureString;
        }
    }
}
