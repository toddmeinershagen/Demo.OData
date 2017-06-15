using System;

namespace Demo.OData.Web.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime Birthdate { get; set; }
        public Address Address { get; set; }
    }
}