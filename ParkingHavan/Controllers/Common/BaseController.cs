using Microsoft.AspNetCore.Mvc;

namespace ParkingHavan.Controllers.Common
{
    public class BaseController : ControllerBase
    {
        protected ActionResult Result(object value = null)
        {
            return new JsonResult(value);
        }
    }
}
