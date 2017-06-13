using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.OData.Web.Models
{
    public class ClaimsCriteria
    {
        public ClaimType Type { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ThruDate { get; set; }
    }
}