using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using crud_csharp_mvp_BusinessLogicLayer.persistence_model.interfaces;

namespace crud_csharp_mvp_ApplicationController.services.interfaces {
    public interface IService {
        IUserContext db { get; set; }

        //add here some more complex and multiple data access. or maybe, just add another interface that inherits from IService
    }
}
