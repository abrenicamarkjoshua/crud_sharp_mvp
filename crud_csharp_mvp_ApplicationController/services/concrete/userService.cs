using crud_csharp_mvp_BusinessLogicLayer.domain_model;
using crud_csharp_mvp_BusinessLogicLayer.persistence_model.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace crud_csharp_mvp_ApplicationController.services.concrete
{
    public class userService : Service
    {
        public userService(IUserContext db)
            : base(db)
        {

        }
        public void addUser(user user){
            db.addUser(user);
        }
        public void editUser(user user){
            db.updateUserById(user.id, user);
        }
    }
}
