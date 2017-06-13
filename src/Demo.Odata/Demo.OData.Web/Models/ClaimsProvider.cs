using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace Demo.OData.Web.Models
{
    public class ClaimsProvider
    {
        public IQueryable<Claim> GetClaims()
        {
            var path = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/"), "mock-claim-data.json");
            var json = File.ReadAllText(path);

            return JsonConvert.DeserializeObject<Claim[]>(json).AsQueryable();
        }
    }
}

