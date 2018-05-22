using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BakeryProject.Models
{
    public class NewPerson
    {
        public string PersonLastName { get; set; }
        public string PersonFirstName { get; set; }
        public string PersonEmail { get; set; }
        public string PersonPhone { get; set; }
        public string PersonDateAdded{ get; set; }
        public string PersonPassword { get; set; }
        public string PersonIdentityCode { get; set; }
    }
}