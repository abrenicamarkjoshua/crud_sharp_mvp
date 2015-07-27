using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using crud_csharp_mvp_BusinessLogicLayer.persistence_model.interfaces;
using System.Data.Entity;
using crud_csharp_mvp_BusinessLogicLayer.domain_model;
using System.ComponentModel;

namespace crud_csharp_mvp_BusinessLogicLayer.persistence_model.concrete {
    public class UserContext_framework : DbContext, IUserContext {
        public string connectionString{get;set;}
        public UserContext_framework(string con)
            : base(con)
        {
            connectionString = con;
            user.Load();
        }
       
        public IUserContext createInstance()
        {
            return new UserContext_framework(connectionString);
            
        }
        public DbSet<user> user { get; set; }

        public List<user> getListOfAllUsers()
        {
            user.Load();
            return user.ToList();
        }

        public user getUserById(int id)
        {
            return user.FirstOrDefault(u => u.id == id);
        }

        public user getUserByUsernamePassword(string username, string hashedPassword)
        {
            try
            {
                return user.FirstOrDefault(u => u.username == username && u.password == hashedPassword);
            }
            catch (Exception ex)
            {

            }
            return user.FirstOrDefault(u => u.username == username && u.password == hashedPassword);
        }


        public object getListOfAllUsers_datasource()
        {
            user.Load();
            return user.Local.ToBindingList();
        }

        public List<user> searchUserByName(string name)
        {
            return user.Where(u => u.username.Contains(name)).ToList();
        }

        public object searchUserByName_datasource(string name)
        {
            user.Where(u => u.username.Contains(name)).Load();
            return user.Local.ToBindingList();
        }



        public void addUser(user user)
        {
            Entry(user).State = EntityState.Added;
            SaveChanges();
        }


        public void updateUserById(int id, user UpdatedUser)
        {
            user user = getUserById(id);
            user.username = UpdatedUser.username;
            user.accountType = UpdatedUser.accountType;
            Entry(user).State = EntityState.Modified;
            SaveChanges();
        }

        public void DeleteUserById(int id)
        {
            user user = getUserById(id);
            Entry(user).State = EntityState.Deleted;
            SaveChanges();
        }


        public bool usernameAlreadyUsed(string username, user owner)
        {
            user output = user.FirstOrDefault(u => u.username == username && 
                u.id != owner.id);
            if (output == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
