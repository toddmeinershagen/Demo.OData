using System.Web.Http.OData.Query;
using System.Web.Http.OData.Query.Validators;
using Microsoft.OData;

namespace Demo.OData.Web.Controllers
{
    public class CustomSelectExpandValidator : SelectExpandQueryValidator
    {
        public override void Validate(SelectExpandQueryOption selectExpandQueryOption, ODataValidationSettings validationSettings)
        {
            if (selectExpandQueryOption.RawSelect.Contains("Address"))
            {
                throw new ODataException("You cannot access the Address for Contacts.");
            }

            base.Validate(selectExpandQueryOption, validationSettings);
        }
    }
}