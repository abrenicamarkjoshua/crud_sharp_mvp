using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace crud_csharp_mvp_BusinessLogicLayer.domain_model {
    [Table("user")] //this is important so that it will not be difficult when renaming from the backend database or from the code
    public class user {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string accountType { get; set; }

        
        
        
        //don't create user with no properties. we'll use factory method
        private user()
        {

        }
        public static user mapUser(int id, string username, string hashedPassword, string accountType)
        {
            return new user()
            {
                id = id,
                username = username,
                password = hashedPassword,
                accountType = accountType

            };
        }
        public static user newUser(string username, string hashedPassword, string accountType)
        {
            user newUser = new user()
            {
                username = username,
                password = hashedPassword,
                accountType = accountType
            };
            return newUser;
        }
        //business logics:
        public void changePassword(string newHashedPassword)
        {
            password = newHashedPassword;
        }
        public void updateUsername(string newUsername){
            username = newUsername;
        }
        public bool isAdmin()
        {
            if (accountType.ToLower() == "admin")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void updateAccountType(string accountType)
        {
            this.accountType = accountType;
        }
    }
}
