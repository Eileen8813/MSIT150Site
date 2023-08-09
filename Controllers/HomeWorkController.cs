using Microsoft.AspNetCore.Mvc;

namespace MSIT150Site.Controllers
{
    public class HomeWorkController : Controller
    {
        public IActionResult homework1()
        {//作業一 改用 jQuery 完成JSON資料讀取並顯示在表格中的練習
            return View();
            
        }
        public IActionResult homework2()
        {//作業二 引用 datas/Travel.js 中的JSON，讀取資料後，透過 bootstrap cards component 顯示在網頁上
            return View();

        }
        public IActionResult homework3()
        {//作業二 引用 datas/Travel.js 中的JSON，讀取資料後，透過 bootstrap cards component 顯示在網頁上
            return View();

        }
    }
}
