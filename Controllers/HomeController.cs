using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShowGrid.Models;
using ShowGrid.Repository;
using ShowGrid.ViewModel;

namespace ShowGrid.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UploadUserRepo _repo;

        public HomeController(
            ILogger<HomeController> logger,
            IWebHostEnvironment webHostEnvironment,
            UploadUserRepo repo)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
            _repo = repo;
        }

        public IActionResult Index()
        {
            var result = _repo.GetAllUsers();
            ViewBag.Success = TempData["Alert"];
            ViewBag.User = TempData["User"];
            return View(result);
        }


        //Add Get
        [HttpGet]
        public IActionResult Add()
        {
            var model = new UploadDocument();
            
            return View(model);
        }

        //Add Post
        [HttpPost]
        public async Task<IActionResult> Add(UploadDocument model)
        {
            if (ModelState.IsValid)
            {
                var user = new UploadUser()
                {
                    Email = model.Email,
                    Name = model.Name,
                    TransactionId = "Upload-" + Guid.NewGuid().ToString(),
                    UploadUserId = model.Id
                };
                //var transId = _repo.AddUser(model);
                _repo.AddUser(user);
                _repo.SaveChanges();
                var files = model.FormFiles;
                var userId = user.UploadUserId;

                var attachment = new List<string>();
                for (var i = 0; i < files.Count(); i++)
                {
                    UserUpload userUpload = new UserUpload();
                    string folder = "Upload/";
                    var filePath = await UploadImage(folder, files[i]);
                    userUpload.FilePath = filePath;
                    userUpload.UploadUserId = userId;
                    userUpload.TransactionId = user.TransactionId;
                    userUpload.FileName = files[i].FileName;
                    attachment.Add(filePath);
                    _repo.AddUserUpload(userUpload);
                    _repo.SaveChanges();
                }

                //#region Mail

                MailMessage msg = new MailMessage  // instance Mail sender service
                {
                    From = new MailAddress("asamoja9100@gmail.com"),  // Server Email Address
                };


                msg.To.Add(user.Email); // receiver Email

                msg.Subject = "Document Successfully Uploaded";
                msg.Body = $"Hello {user.Name},  your documents was successfully uploaded. Here is your Transaction ID {user.TransactionId}. Kindly find the attached documents.";  // Message Body

                for (var i = 0; i < files.Count(); i++)
                {
                    string fileName = Path.GetFileName(files[i].FileName);

                    msg.Attachments.Add(new Attachment(files[i].OpenReadStream(),fileName));
                }

                SmtpClient client = new SmtpClient
                {
                    Host = "smtp.gmail.com"
                };
                NetworkCredential credential = new NetworkCredential
                {  // Server Email credentisal
                    UserName = "asamoja9100@gmail.com",
                    Password = "AsaVault7323"
                };
                client.Credentials = credential;
                client.EnableSsl = true;
                client.Port = 587;
                client.Send(msg);


                TempData["User"] = user.Name;
                TempData["Alert"] = true;

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        //Search Get
        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }

        //Search Post
        [HttpPost]
        public IActionResult Search(SearchViewModel model)
        {
            var data = _repo.GetUserUploads(model.TransactionId, model.Email);
            var result = new SearchViewModel()
            {
                Email = model.Email,
                TransactionId = model.TransactionId,
                Files = data.UserUploads
            };
            return View(result);
        }

        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {

            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
