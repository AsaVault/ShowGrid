using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShowGrid.Models
{
    public class UploadUser
    {
        public int UploadUserId { get; set; }
        public string TransactionId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<UserUpload> UserUploads { get; set; }
    }
}
