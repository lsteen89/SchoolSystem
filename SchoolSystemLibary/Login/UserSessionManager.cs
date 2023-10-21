using SchoolSystemLibary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystemLibary.Login
{
    public class UserSessionManager
    {
        private static UserSessionManager instance;
        public UserSession CurrentUserSession { get; private set; }

        private UserSessionManager()
        {
            // Private constructor to prevent external instantiation
        }

        public static UserSessionManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserSessionManager();
                }
                return instance;
            }
        }

        public void SetUserSession(UserModel userModel)
        {
            CurrentUserSession = new UserSession
            {
                Username = userModel.LoginName,
                Roles = userModel.Roles,  
                Persoid = userModel.Persoid,
            };
        }

        // Add other methods to access or manage the user session as needed
    }
}
