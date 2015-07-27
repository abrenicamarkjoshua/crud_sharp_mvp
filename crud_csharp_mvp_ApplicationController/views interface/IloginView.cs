using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using crud_csharp_mvp_BusinessLogicLayer.domain_model;
using crud_csharp_mvp_BusinessLogicLayer.persistence_model.interfaces;

namespace crud_csharp_mvp_ApplicationController.views_interface {
    public interface IloginView {

        bool noErrors();

        void displayErrors();

        string getUsername();

        string getHashedPassword();

        void RedirectToMainForm(user user, IUserContext db);

        void displayUserLoginFailed();

        void clearFields();

        void hide();
    }
}
