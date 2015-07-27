using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using crud_csharp_mvp_customDAL;
using crud_csharp_mvp_BusinessLogicLayer.persistence_model.interfaces;
using crud_csharp_mvp_BusinessLogicLayer.domain_model;
using System.ComponentModel;

namespace crud_csharp_mvp_BusinessLogicLayer.persistence_model.concrete {

    /// <summary>
    /// this is a mapper and not the DAL that's why it is in the business logic layer
    /// </summary>
    public class UserContext_customDAL : dbContextCustom, IUserContext {
        private string connectionName;
        public UserContext_customDAL(string connectionName)
            : base(connectionName)
        {
            this.connectionName = connectionName;
        }
        public IUserContext createInstance()
        {
            return new UserContext_customDAL(connectionName);
        }

        public List<user> getListOfAllUsers()
        {
          
            throw new NotImplementedException();
        }

        public user getUserById(int id)
        {
            user retrievedUser = null;
            query("SELECT * FROM user WHERE id = ?", new Dictionary<string, string> { { "@id", id.ToString() } });
            if (result.Rows.Count > 0)
            {

                retrievedUser = user.mapUser(
                    (int)result.Rows[0]["id"], result.Rows[0]["username"].ToString(),
                    result.Rows[0]["password"].ToString(),
                    result.Rows[0]["accounttype"].ToString()
                );

            }
            return retrievedUser;
        }

        public user getUserByUsernamePassword(string username, string hashedPassword)
        {
            user retrievedUser = null;
            query("SELECT * FROM user WHERE username = ? AND password = ?", new Dictionary<string, string> { { "@username", username }, {"@password", hashedPassword} });
            if (result.Rows.Count > 0)
            {
                retrievedUser = user.mapUser(
                    (int)result.Rows[0]["id"], result.Rows[0]["username"].ToString(),
                    result.Rows[0]["password"].ToString(),
                    result.Rows[0]["accounttype"].ToString()
                );

            }
            return retrievedUser;
        }

        public List<user> searchUserByName(string name)
        {
            throw new NotImplementedException();
        }

        public object getListOfAllUsers_datasource()
        {
            query("SELECT * FROM user");
            return result;
        }

        public object searchUserByName_datasource(string name)
        {
            throw new NotImplementedException();
        }



        public void addUser(user user)
        {
            query("INSERT INTO ser(`username`, `password`, `accounttype`) VALUES (?,?,?)",
               new Dictionary<string, string>()
               {
                   {"@username", user.username},
                   {"@password", user.password},
                   {"@accounttype", user.accountType}
               }
                );

        }


        public void updateUserById(int id, user UpdatedUser)
        {
            query("INSERT INTO ser(`username`, `password`, `accounttype`) VALUES (?,?,?)",
                   new Dictionary<string, string>()
                   {
                       {"@username", UpdatedUser.username},
                       {"@password", UpdatedUser.password},
                       {"@accounttype", UpdatedUser.accountType}
                   }
                );
        }

        public void DeleteUserById(int id)
        {
            query("DELETE FROM USER WHERE id = ?", new Dictionary<string,string>(){{"@id", id.ToString()}}
                  );
        }


        public bool usernameAlreadyUsed(string username, user owner)
        {
            query("SELECT COUNT(`id`) FROM user WHERE username = ? AND id != ?",
                new Dictionary<string, string>()
                {
                    {"@username", username},
                    {"@id", owner.id.ToString()}
                }
                );
            if (int.Parse(result.Rows[0][0].ToString()) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
