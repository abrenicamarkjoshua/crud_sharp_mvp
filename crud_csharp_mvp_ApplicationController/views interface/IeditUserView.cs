using crud_csharp_mvp_BusinessLogicLayer.domain_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace crud_csharp_mvp_ApplicationController.views_interface
{
    public interface IeditUserView
    {
        user getUser();

        bool hasNoErrors();

        void showErrors();

        user getUpdatedUser();

        void showErrors(string p);

        void confirmAndClose();

        string getInputUsername();
    }
}
