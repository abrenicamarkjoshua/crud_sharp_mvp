using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using crud_csharp_mvp_BusinessLogicLayer.domain_model;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace crud_csharp_mvp_BusinessLogicLayer.persistence_model.interfaces {
    public interface IUserContext : IDisposable {
        IUserContext createInstance();
        List<user> getListOfAllUsers();
        user getUserById(int id);
        user getUserByUsernamePassword(string username, string hashedPassword);
        List<user> searchUserByName(string name);
        /* for datasource */
        object getListOfAllUsers_datasource();
        object searchUserByName_datasource(string name);
        /* end - for datasource */


        void addUser(user user);
        void updateUserById(int id, user UpdatedUser);
        void DeleteUserById(int id);

        bool usernameAlreadyUsed(string username, user owner);
    }
}
