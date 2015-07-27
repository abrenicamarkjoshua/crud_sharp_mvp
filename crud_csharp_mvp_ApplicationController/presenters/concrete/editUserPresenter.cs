using crud_csharp_mvp_ApplicationController.presenters.interfaces;
using crud_csharp_mvp_ApplicationController.services.interfaces;
using crud_csharp_mvp_ApplicationController.views_interface;
using crud_csharp_mvp_BusinessLogicLayer.persistence_model.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace crud_csharp_mvp_ApplicationController.presenters.concrete
{
    public class editUserPresenter : IeditUserPresenter
    {
        private IeditUserView view;
        private IUserContext userContext;
        public editUserPresenter(IeditUserView view, IUserContext userContext)
        {
            this.view = view;
            this.userContext = userContext;

        }

        public void saveChangesToUser()
        {
            if (view.hasNoErrors())
            {

                if (userContext.usernameAlreadyUsed(view.getInputUsername(), view.getUser()))
                {
                    view.showErrors("Username already taken");

                    return;
                }
                userContext.updateUserById(view.getUser().id, view.getUpdatedUser());
                view.confirmAndClose();
            }
            else
            {
                view.showErrors();
            }
        }
    }
}
