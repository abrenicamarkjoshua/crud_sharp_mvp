using crud_csharp_mvp_BusinessLogicLayer.domain_model;
using crud_csharp_mvp_BusinessLogicLayer.persistence_model.interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace crud_csharp_mvp_BusinessLogicLayer.persistence_model.concrete
{
    public class subjectContext_framework : DbContext, IsubjectContext
    {

        public DbSet<subject> subject { get; set; }
        public subjectContext_framework(string connectionName)
            : base(connectionName)
        {

        }
    }
}
