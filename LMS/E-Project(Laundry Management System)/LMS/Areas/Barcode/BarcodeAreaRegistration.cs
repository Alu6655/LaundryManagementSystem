using System.Web.Mvc;

namespace LMS.Areas.Barcode
{
    public class BarcodeAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Barcode";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Barcode_default",
                "Barcode/{controller}/{action}/{id}",
                new { action = "BarcodeList", id = UrlParameter.Optional }
            );
        }
    }
}