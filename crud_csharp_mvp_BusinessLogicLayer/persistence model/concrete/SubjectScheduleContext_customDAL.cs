using crud_csharp_mvp_BusinessLogicLayer.persistence_model.interfaces;
using crud_csharp_mvp_customDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace crud_csharp_mvp_BusinessLogicLayer.persistence_model.concrete
{
    public class SubjectScheduleContext_customDAL : dbContextCustom, IsubjectScheduleContext
    {
        public SubjectScheduleContext_customDAL(string connectionName)
            : base(connectionName)
        {

        }
    }
}
