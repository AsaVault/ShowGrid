using ShowGrid.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowGrid.ViewModel
{
    public class SearchViewModel
    {
        public int Id { get; set; }
        [Required]
        public string TransactionId { get; set; }
        [Required]
        [Display(Name = "Email", Prompt = "Enter Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public List<UserUpload> Files { get; set; }
    }
}
