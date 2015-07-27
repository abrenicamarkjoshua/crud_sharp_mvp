using crud_csharp_mvp_BusinessLogicLayer.domain_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace crud_csharp_mvp_ApplicationController.views_interface {
    public interface ImainFormView {
        void loadAllLUsers_datagridview(object users);

        void error(Exception ex);

        void loadAllLUsers_listview(List<user> users);
    }
}
