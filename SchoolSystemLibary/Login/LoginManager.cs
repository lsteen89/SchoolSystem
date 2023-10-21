using Dapper;
using SchoolSystemLibary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;


namespace SchoolSystemLibary.Login
{
    public class LoginManager
    {
        /// <summary>
        /// This manages the Login check.
        /// </summary>
        /// <param name="username">The username supplied in the form</param>
        /// <param name="password">The password supplied in the form</param>
        /// <returns>userModel if true, Null otherwise</returns>
        public UserModel AuthenticateUser(string username, string password)
        {

            using (var connection = GlobalConfig.GetConnection())
            {
                var user = connection.QuerySingleOrDefault<UserModel>("SELECT * FROM Users WHERE LoginName = @LoginName", new { LoginName = username });
                if (user != null)
                {
                    bool PasswordValid = true; //Todo Fix password verification
                    if (PasswordValid)
                    {
                        UserModel UserModel = new UserModel
                        {
                            LoginName = user.LoginName,
                            Role = user.Role,
                            Persoid = user.Persoid,
                        };
                        return user;
                    }
                }
                return null;
            }
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
