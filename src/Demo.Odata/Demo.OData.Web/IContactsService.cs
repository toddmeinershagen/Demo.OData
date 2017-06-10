using Demo.OData.Web.Models;

namespace Demo.OData.Web
{
    public interface IContactsService
    {
        Contact GetContact(int id);
    }
}