using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShowGrid.Data;
using ShowGrid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowGrid.Repository
{
    public class UploadUserRepo
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<UploadUserRepo> _logger;

        public UploadUserRepo(ApplicationDbContext db, ILogger<UploadUserRepo> logger)
        {
            _db = db;
            _logger = logger;
        }

        public  void AddUser(UploadUser model)
        {
            _db.UploadUser.Add(model);
           // SaveChanges();
        }

        public  void AddUserUpload(UserUpload model)
        {
             _db.UserUpload.Add(model);
            //SaveChanges();
        }

        public void AddUploadList(UploadList model)
        {

            _db.UploadList.Add(model);
            //SaveChanges();
        }

        public IEnumerable<UploadUser> GetAllUsers()
        {
           return  _db.UploadUser.ToList();
        }

        public  void SaveChanges()
        {
             _db.SaveChanges() ;
        }

        public UploadUser GetUserUploads(string transId, string email)
        {
           return _db.UploadUser.Include(x=>x.UserUploads).FirstOrDefault(x => x.TransactionId == transId && x.Email ==email);
        }
    }
}
  