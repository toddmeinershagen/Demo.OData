using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using Demo.OData.Web.Controllers;
using Demo.OData.Web.Models;

namespace Demo.OData.Web
{
    [ServiceContract]
    public class ContactsService
    {
        [OperationContract]
        public Contact GetContact(int id)
        {
            return ContactsController.Contacts.FirstOrDefault(c => c.Id == id);
        }
    }
}