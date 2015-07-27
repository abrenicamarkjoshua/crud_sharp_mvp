using crud_csharp_mvp_BusinessLogicLayer.persistence_model.interfaces;
using crud_csharp_mvp_customDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace crud_csharp_mvp_BusinessLogicLayer.persistence_model.concrete
{
    public class subjectContext_customDAL : dbContextCustom, IsubjectContext
    {
        public subjectContext_customDAL(string connectionName)
            : base(connectionName)
        {

        }
    }
}
