﻿using System.Linq;
using System.Web.OData;

using Demo.OData.Web.Models;
using System.Web.Http.OData.Query;

namespace Demo.OData.Web.Controllers
{
    public class BasicContactsController : ODataController
    {
        [EnableQuery(PageSize = 10)]
        public IQueryable<BasicContact> Get(ODataQueryOptions options)
        {
            return ContactsController.Contacts.Select(c => new BasicContact(c));
        }
    }
}