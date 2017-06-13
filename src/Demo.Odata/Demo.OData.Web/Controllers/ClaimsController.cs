using Demo.OData.Web.Models;
using System.Linq;
using System.Web.Http;
using System.Web.OData;

namespace Demo.OData.Web.Controllers
{
    public class ClaimsController : ODataController
    {
        public static readonly IQueryable<Claim> Claims = new ClaimsProvider().GetClaims();

        [EnableQuery(PageSize = 10)]
        public IQueryable<Claim> Get()
        {
            return Claims;
        }

        [HttpPost]
        public IHttpActionResult SearchByCriteriaAction(ODataActionParameters parameters)
        {
            if (parameters == null)
                return BadRequest();

            var criteria = parameters["criteria"] as ClaimsCriteria;

            return Ok(Claims);
        }

        [HttpGet]
        public IHttpActionResult SearchByCriteriaFunction([FromODataUri]ClaimsCriteria criteria)
        {
            return Ok(Claims);
        }
    }

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