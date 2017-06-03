using System.Linq;

using System.Web.Http;
using System.Web.OData;

using Demo.OData.Web.Models;
using System.Web.Http.OData.Query;


namespace Demo.OData.Web.Controllers
{
    public class ContactsController : ODataController
    {
        private static readonly IQueryable<Contact> _contacts = new ContactProvider().GetContacts();

        [EnableQuery(PageSize = 10)]
        public IQueryable<Contact> Get()
        {
            return _contacts;
        }

        [EnableQuery]
        public SingleResult<Contact> Get([FromODataUri] int key)
        {
            var result = _contacts.Where(c => c.Id == key);
            return SingleResult.Create(result);
        }

        [HttpGet]
        public IHttpActionResult Oldest()
        {
            var maxAge = _contacts.Max(c => c.Birthdate.Age());
            var contact = _contacts.Where(c => c.Birthdate.Age() == maxAge).First();

            return Ok(contact);
        }

        [HttpGet]
        public IHttpActionResult OlderThan(int age)
        {
            var contacts = _contacts.Where(c => c.Birthdate.Age() > age);

            return Ok(contacts);
        }
    }

}