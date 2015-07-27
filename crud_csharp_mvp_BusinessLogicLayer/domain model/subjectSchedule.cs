using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace crud_csharp_mvp_BusinessLogicLayer.domain_model
{
    public class subjectSchedule
    {
        public int id { get; set; }
        public subject subject { get; set; }
        public string schedule_day { get; set; }
        public string schedule_room { get; set; }
        public user professor { get; set; } 
    }
}
