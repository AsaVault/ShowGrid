using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowGrid.Models
{
    public class UserUpload
    {
        public int UserUploadId { get; set; }
        public string TransactionId { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public int UploadUserId { get; set; }
       public UploadUser UploadUser { get; set; }
    }
}
