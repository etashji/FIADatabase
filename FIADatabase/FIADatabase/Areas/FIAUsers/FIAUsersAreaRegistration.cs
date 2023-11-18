using System.Web.Mvc;

namespace FIADatabase.Areas.FIAUsers
{
    public class FIAUsersAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "FIAUsers";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "FIAUsers_default",
                "FIAUsers/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}