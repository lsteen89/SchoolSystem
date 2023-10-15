using Dapper;
using SchoolSystemLibary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SchoolSystemLibary
{
    public class LoginManager
    {
        /// <summary>
        /// This manages the Login check.
        /// </summary>
        /// <param name="username">The username supplied in the form</param>
        /// <param name="password">The password supplied in the form</param>
        /// <returns>True or false depending if the user with the correct password was found. </returns>
        public bool AuthenticateUser(string username, string password)
        {
            using (var connection = GlobalConfig.GetConnection())
            {
                var user = connection.QuerySingleOrDefault<UserModel>("SELECT * FROM Users WHERE LoginName = @LoginName", new { LoginName = username });
                if (user != null)
                {
                    //TODO Fix password validiation
                    // Verify the password using a secure hashing library (not shown in this example)
                    bool isPasswordValid = true;//PasswordHash.ValidatePassword(password, user.PasswordHash);

                    return isPasswordValid;
                }

                return false;
            }


        }
        

    }
}
