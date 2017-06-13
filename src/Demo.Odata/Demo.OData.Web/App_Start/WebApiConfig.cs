using Demo.OData.Web.Models;

using System.Web.Http;
using System.Web.OData.Extensions;
using System.Web.OData.Builder;
using System.Web.OData.Batch;
using Swashbuckle.Application;
using Swashbuckle.OData;

namespace Demo.OData.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services            

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            ODataModelBuilder builder = new ODataConventionModelBuilder();

            var contactsResource = "Contacts";
            builder.EntitySet<Contact>(contactsResource);
            builder.EntitySet<BasicContact>("Basic" + contactsResource);

            builder
                .EntityType<Contact>()
                .Collection
                .Function("Oldest")
                .ReturnsFromEntitySet<Contact>(contactsResource);

            builder
                .EntityType<Contact>()
                .Collection
                .Function("OlderThan")
                .ReturnsCollectionFromEntitySet<Contact>(contactsResource)
                .Parameter<int>("age");

            var claimsResource = "Claims";
            builder.EntitySet<Claim>(claimsResource);

            builder
                .EntityType<Claim>()
                .Collection
                .Function("SearchByCriteriaFunction")
                .ReturnsCollectionFromEntitySet<Claim>(claimsResource)
                .Parameter<ClaimsCriteria>("criteria");
                //.Parameter<ClaimType>("type");

            builder
                .EntityType<Claim>()
                .Collection
                .Action("SearchByCriteriaAction")
                .ReturnsCollectionFromEntitySet<Claim>(claimsResource)
                .Parameter<ClaimsCriteria>("criteria");

            var ealertsResource = nameof(EAlert) + "s";
            builder.EntitySet<EAlert>(ealertsResource);

            config
                .Count()
                .Filter()
                .OrderBy()
                .Expand()
                .Select()
                .MaxTop(null);

            var odataBatchHandler = new DefaultODataBatchHandler(GlobalConfiguration.DefaultServer);
            odataBatchHandler.MessageQuotas.MaxOperationsPerChangeset = 10;
            odataBatchHandler.MessageQuotas.MaxPartsPerBatch = 10;

            config.MapODataServiceRoute(
                routeName: "odata",
                routePrefix: "odata",
                model: builder.GetEdmModel(),
                batchHandler: odataBatchHandler);

            config.EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "OData Endpoint");
                    c.CustomProvider(defaultProvider => new ODataSwaggerProvider(defaultProvider, c,
                        GlobalConfiguration.Configuration));
                })
                .EnableSwaggerUi();
            

            //config.MapODataServiceRoute(
            //    routeName: "odata",
            //    routePrefix: "odata",
            //    model: builder.GetEdmModel());
        }
    }
}



/*
    var odataBatchHandler = new DefaultODataBatchHandler(GlobalConfiguration.DefaultServer);
    odataBatchHandler.MessageQuotas.MaxOperationsPerChangeset = 10;
    odataBatchHandler.MessageQuotas.MaxPartsPerBatch = 10;

    config.MapODataServiceRoute(
        routeName: "odata",
        routePrefix: "odata",
        model: builder.GetEdmModel(),
        batchHandler: odataBatchHandler);
*/