using System;

namespace Demo.OData.Web.Controllers
{
    public static class DateTimeExtensions
    {
        public static int Age(this DateTime birthdate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthdate.Year;

            if (birthdate > today.AddYears(-age)) age--;
            return age;
        }
    }
}