using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MSIT150Site.Models;
using MSIT150Site.ViewModels;
using Microsoft.Extensions.Hosting;

namespace MSIT150Site.Controllers
{
    public class apiController : Controller
    {
        //https://github.com/HsiaoHungWang/MSIT150Site
        private DemoContext _dbContext;
        //建構子
        public apiController(DemoContext db, IWebHostEnvironment host) {

            _dbContext = db;
            _host = host;
        }
        public IActionResult Index()
        {
            System.Threading.Thread.Sleep(5000);
            return Content("學習如何抓到api裡面的文字");
        }
        public IActionResult GetDemo(UserViewModel uvm)
        {
            if (string.IsNullOrEmpty(uvm.name))
            {
                uvm.name = "guest";
            }
            return Content($"哈摟，{uvm.name}，你怎麼就{uvm.old}歲了!");




        }
        
        private readonly IWebHostEnvironment _host;

        public IActionResult Register(Members members,IFormFile file)
        {
            //_dbContext.Members.Add(members);
            //_dbContext.SaveChanges();
            //return Content($"新增成功");

            //第一種上傳到資料夾寫法:
            
            string filePath = Path.Combine(_host.WebRootPath, "uploads", file.FileName);
            
            using (var fileStream=new FileStream(filePath, FileMode.Create ))
            {

                file.CopyTo(fileStream);
               

            }
            return Content($"上傳檔案到 {filePath}");


            //第二種二進位寫法:
            byte[]? bytes= null;
            using (var ms=new MemoryStream()) { 
            
            
            
            }


        }
    }
}
