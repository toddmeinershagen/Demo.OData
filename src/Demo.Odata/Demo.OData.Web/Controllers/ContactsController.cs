using System.Collections.Generic;
using System.Linq;

using System.Web.Http;
//using System.Web.Http.OData;
using System.Web.OData;

using Demo.OData.Web.Models;
using System.Web.Http.OData.Query;
using System.Web.Http.OData.Extensions;

namespace Demo.OData.Web.Controllers
{
    public class ContactsController : ODataController
    {
        public static readonly IQueryable<Contact> Contacts = new ContactProvider().GetContacts();

        [EnableQuery(PageSize = 10)]
        public IQueryable<Contact> Get()
        {
            return Contacts;
        }

        //public IQueryable<Contact> Get(ODataQueryOptions options)
        //{
        //    options.SelectExpand.Validator = new CustomSelectExpandValidator();
        //    options.Validate(new ODataValidationSettings());

        //    return options.ApplyTo(Contacts) as IQueryable<Contact>;
        //}

        [EnableQuery]
        public SingleResult<Contact> Get([FromODataUri] int key, ODataQueryOptions options)
        {
            var result = Contacts.Where(c => c.Id == key);
            return SingleResult.Create(result);
        }

        [HttpGet]
        public IHttpActionResult Oldest()
        {
            var maxAge = Contacts.Max(c => c.Birthdate.Age());
            var contact = Contacts.First(c => c.Birthdate.Age() == maxAge);

            return Ok(contact);
        }

        [HttpGet]
        public IHttpActionResult OlderThan(int age)
        {
            var contacts = Contacts.Where(c => c.Birthdate.Age() > age);

            return Ok(contacts);
        }

        //public IQueryable<Contact> Post([FromBody] string filterRawValue)
        //{
        //    //var context = new ODataQueryContext(Request.ODataProperties().Model, typeof(Contact));
        //    //var options = new ODataQueryOptions(context, Request);
        //    //return (options.ApplyTo(Contacts) as IQueryable<Contact>);

        //    var context = new ODataQueryContext(Request.ODataProperties().Model, typeof(Contact));
        //    var filterQueryOption = new FilterQueryOption(filterRawValue, context);
        //    //return (filterQueryOption.ApplyTo(Contacts) as IQueryable<Contact>).WithTranslations().Project(MappingEngine).To<ReportModel>().WithTranslations();
        //    return Contacts;
        //}
    }
}