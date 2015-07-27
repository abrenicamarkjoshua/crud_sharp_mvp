using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using crud_csharp_mvp_ApplicationController.presenters.interfaces;
using crud_csharp_mvp_BusinessLogicLayer.persistence_model.interfaces;
using crud_csharp_mvp_ApplicationController.views_interface;
using System.ComponentModel;
using crud_csharp_mvp_BusinessLogicLayer.domain_model;
using crud_csharp_mvp_BusinessLogicLayer.persistence_model.concrete;

namespace crud_csharp_mvp_ApplicationController.presenters.concrete {
    public class mainFormPresenter : ImainFormPresenter{
        private IUserContext db;
        private ImainFormView view;
        public mainFormPresenter(ImainFormView view, IUserContext db)
        {
            this.view = view;
            try
            {
                this.db = db;
                
            }
            catch (Exception ex)
            {
                //more error handling here.
                view.error(ex);
            }
        }

        //event added. <-- just a comment for me to notify me that i already added it to the wireEvent()
        public void loadAllUsers_datagridview()
        {
            //i'm just used to using "using". this is how entity framework do it hehe.
            using (var _db = db.createInstance())
            {
                object users = _db.getListOfAllUsers_datasource();
                view.loadAllLUsers_datagridview(users);

            }
        }

        public void loadAllUsers_listview()
        {
            using(var _db = db.createInstance()){
                List<user> users = _db.getListOfAllUsers();
                view.loadAllLUsers_listview(users);
            }
        }



        public user getUserById(int id)
        {
            return db.getUserById(id);
        }


        public void deleteUserById(user user)
        {
            throw new NotImplementedException();
        }
    }
}
