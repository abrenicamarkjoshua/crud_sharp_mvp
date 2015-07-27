using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using crud_csharp_mvp_ApplicationController.services.interfaces;
using crud_csharp_mvp_BusinessLogicLayer.persistence_model.interfaces;

namespace crud_csharp_mvp_ApplicationController.services.concrete {
    public class Service : IService {
        private IUserContext _db;
        public Service(IUserContext db)
        {
            _db = db;
        }
        public IUserContext db
        {
            get
            {
                return _db;
            }
            set
            {
                _db = value;
            }
        }

    }
}
