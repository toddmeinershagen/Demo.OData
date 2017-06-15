using Demo.OData.Web.Models;
using System.Linq;
using System.Web.OData;

namespace Demo.OData.Web.Controllers
{
    public class BasicContactsController : ODataController
    {
        [EnableQuery(PageSize = 10)]
        public IQueryable<BasicContact> Get()
        //public IQueryable<BasicContact> Get(ODataQueryOptions options)
        {
            return ContactsController.Contacts.Select(c => new BasicContact(c));
        }
    }
}