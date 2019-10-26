using System.Web.Mvc;

namespace CodeFirstApproach.Areas.ContactUsPage
{
    public class ContactUsPageAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ContactUsPage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ContactUsPage_default",
                "ContactUsPage/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}