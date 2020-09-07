using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowGrid.Models
{
    public class UploadList
    {
        public int Id { get; set; }
        public string TransactionId { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
    }
}
