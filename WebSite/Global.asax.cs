
using System.Web.Routing;
using SvcFramework.servicebase;
using WebSite.Services.Contracts;
using WebSite.Services.Impl;
using System.ServiceModel.Activation;

namespace WebSite
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication: System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Config.RegisterService<QuotesService>("api-svc/quotes", new QuotesService());

            RouteTable.Routes.Add(new ServiceRoute("api-wcf/quotes", new WebServiceHostFactory(), typeof(QuotesService)));
        }
    }
}