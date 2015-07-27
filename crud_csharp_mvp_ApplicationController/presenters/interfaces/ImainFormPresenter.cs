using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace crud_csharp_mvp_ApplicationController.presenters.interfaces {
    public interface ImainFormPresenter {

        void loadAllUsers_datagridview();

        void loadAllUsers_listview();

        crud_csharp_mvp_BusinessLogicLayer.domain_model.user getUserById(int p);

        void deleteUserById(crud_csharp_mvp_BusinessLogicLayer.domain_model.user user);
    }
}
