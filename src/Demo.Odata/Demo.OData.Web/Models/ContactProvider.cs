using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace Demo.OData.Web.Models
{
    public class ContactProvider
    {
        public IQueryable<Contact> GetContacts()
        {
            var path = Path.Combine(@"C:\Users\todd\Documents\Visual Studio 2017\Projects\Demo.Odata\Demo.OData.Web", "mock-contact-data.json");
            var json = File.ReadAllText(path);

            return JsonConvert.DeserializeObject<ContactData[]>(json).Select(x => 
                new Contact {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    Gender = x.Gender,
                    Birthdate = x.Birthdate,
                    Address = new Address {
                        AddressLine1 = x.AddressLine1,
                        City = x.City,
                        State = x.State,
                        PostalCode = x.PostalCode
                    }
                }).AsQueryable<Contact>();
        }
    }
}

