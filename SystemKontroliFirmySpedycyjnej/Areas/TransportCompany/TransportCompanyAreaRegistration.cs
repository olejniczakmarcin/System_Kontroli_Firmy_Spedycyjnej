using System.Web.Mvc;

namespace SystemKontroliFirmySpedycyjnej.Areas.TransportCompany
{
    public class TransportCompanyAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "TransportCompany";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "TransportCompany_default",
                "TransportCompany/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}