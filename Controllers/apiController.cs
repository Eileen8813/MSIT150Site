using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MSIT150Site.Models;
using MSIT150Site.ViewModels;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace MSIT150Site.Controllers
{
    public class apiController : Controller
    {
       
        private DemoContext _dbContext;
        //建構子
        public apiController(DemoContext db, IWebHostEnvironment host) {

            _dbContext = db;
            _host = host;
        }
        public IActionResult Index()
        {
            System.Threading.Thread.Sleep(1000);
            return Content("學習如何抓到Fetch裡面的文字");
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

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {

                file.CopyTo(fileStream);


                }
            //return Content($"上傳檔案到 {filePath}");


            //第二種二進位寫法:
            byte[]? bytes = null;
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                bytes = ms.ToArray();


            }
            members.FileName = file.FileName;
            members.FileData = bytes;
            _dbContext.Members.Add(members);
            _dbContext.SaveChanges();

            return Content("新增成功!!");

        }
        public IActionResult GetImageByte(int id = 1)
        {
            Members? member = _dbContext.Members.Find(id);
            byte[]? img = member.FileData;
            if (img!=null)
            {
                return File(img, "image/jpeg");
            }
            else
            {
                return Content("沒圖片");
            }

        }
        public IActionResult Cities()
        {
            // var cities= _dbContext.Address.Select(c => c.City).Distinct();
            //return Json(cities);
            var cities = _dbContext.Address.Select(c => c.City).Distinct();
            //var cities = _context.Address.Select(c => new
            //{
            //    c.City
            //}).Distinct();
            return Json(cities);

        }
       
        public IActionResult Districts(string city)
        {
            var districts = _dbContext.Address.Where(c=>c.City==city).Select(c => c.SiteId).Distinct();
            return Json(districts);

        }

        public IActionResult Roads(string districts)
        {

            var roads = _dbContext.Address.Where(a=>a.SiteId== districts).Select(c => c.Road).Distinct();
            return Json(roads);

        }

        //作業3
        public IActionResult Check(string name)
        {
            var checkname = _dbContext.Members.FirstOrDefault( x=> x.Name == name);

            if (checkname == null)
            { return Content("沒有註冊過喔"); }
            else
            { return Content("有註冊了"); }
        }

    }
}
