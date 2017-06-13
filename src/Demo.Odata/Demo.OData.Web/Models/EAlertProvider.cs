using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using Newtonsoft.Json;

namespace Demo.OData.Web.Models
{
    public class EAlertProvider
    {
        public IQueryable<EAlert> GetEAlerts()
        {
            var path1 = HostingEnvironment.MapPath("~/");
            var path = Path.Combine(path1, "mock-ealert-data.json");
            var json = File.ReadAllText(path);

            return JsonConvert.DeserializeObject<EAlert[]>(json).AsQueryable();
        }
    }

    public class EAlert
    {
        public string VersionName { get; set; }
        public string VersionComparison { get; set; }
        public string Entity { get; set; }
        public string DataElement { get; set; }
        [Key]
        public string KeyColumn { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public string AdditionalDisplayInformation { get; set; }
        public string ChangeType { get; set; }
        public string ChangeSource { get; set; }
        public DateTime ChangeDate { get; set; }
    }
}