using System.Linq;
using System.Web.Http;
using System.Web.OData;
using Demo.OData.Web.Models;

namespace Demo.OData.Web.Controllers
{
    public class EAlertsController : ODataController
    {
        public static readonly IQueryable<EAlert> EAlerts = new EAlertProvider().GetEAlerts();

        [EnableQuery(PageSize = 10)]
        public IQueryable<EAlert> Get()
        {
            return EAlerts;
        }

        [EnableQuery]
        public SingleResult<EAlert> Get([FromODataUri] string key)
        {
            var result = EAlerts.Where(a => a.KeyColumn == key);
            return SingleResult.Create(result);
        }
    }
}