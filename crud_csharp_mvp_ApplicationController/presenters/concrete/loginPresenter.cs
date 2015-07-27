using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using crud_csharp_mvp_ApplicationController.presenters.interfaces;
using crud_csharp_mvp_ApplicationController.views_interface;
using crud_csharp_mvp_ApplicationController.services.interfaces;
using crud_csharp_mvp_BusinessLogicLayer.domain_model;
using crud_csharp_mvp_BusinessLogicLayer.persistence_model.interfaces;

namespace crud_csharp_mvp_ApplicationController.presenters.concrete {
    public class loginPresenter :IloginPresenter{
        private IloginView view;
        private IUserContext userContext;
        public loginPresenter(IloginView view, IUserContext userContext)
        {
            this.view = view;
            this.userContext = userContext;
        }
        #region IloginPresenter Members

        public void login()
        {
            if (view.noErrors()) //check for front end errors
            {
                using (var db = userContext.createInstance()) //usually i just call service.login.authenticate(username, password) and service.login.loginResults...
                //but this would do because it's simple (one database table). we'll refactor it if it becomes complex (like multiple database tables are to be used or other cross cutting concerns)
                {
                    user user = db.getUserByUsernamePassword(view.getUsername(), view.getHashedPassword());
                    if (user != null)
                    {
                        view.hide();
                        view.RedirectToMainForm(user, userContext);
                    }
                    else
                    {
                        view.displayUserLoginFailed();
                    }
                }
            }
            else
            {
                view.displayErrors();
            }
            view.clearFields();
        }

        #endregion
    }
}
