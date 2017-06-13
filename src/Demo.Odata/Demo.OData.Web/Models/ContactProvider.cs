using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace Demo.OData.Web.Models
{
    public class ContactProvider
    {
        public IQueryable<Contact> GetContacts()
        {
            var path = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/"), "mock-contact-data.json");
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
                }).AsQueryable();
        }
    }
}

