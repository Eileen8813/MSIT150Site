using Microsoft.AspNetCore.Mvc;

namespace MSIT150Site.Controllers
{
    public class apiController : Controller
    {
        public IActionResult Index()
        {
            return Content("學習如何抓到api裡面的文字");
        }
    }
}
