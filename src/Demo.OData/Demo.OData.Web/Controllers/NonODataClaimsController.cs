using System.Web.Http;
using Demo.OData.Web.Models;

namespace Demo.OData.Web.Controllers
{
    public class NonODataClaimsController : ApiController
    {
        [HttpPost]
        [Route("odata/Claims/SearchByCriteria")]
        public IHttpActionResult SearchByCriteria([FromBody]ClaimsCriteria criteria)
        {
            return Ok(ClaimsController.Claims);
        }

        [HttpGet]
        [Route("odata/Claims/SearchByCriteriaLikeFunction")]
        public IHttpActionResult SearchByCriteriaLikeFunction([FromUri]ClaimsCriteria criteria)
        {
            return Ok(ClaimsController.Claims);
        }
    }
}