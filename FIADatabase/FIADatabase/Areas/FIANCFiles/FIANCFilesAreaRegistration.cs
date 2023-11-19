using System.Web.Mvc;

namespace FIADatabase.Areas.FIANCFiles
{
    public class FIANCFilesAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "FIANCFiles";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "FIANCFiles_default",
                "FIANCFiles/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}