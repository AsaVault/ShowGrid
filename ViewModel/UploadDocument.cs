using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShowGrid.ViewModel
{
    public class UploadDocument
    {
        public int Id { get; set; }
        public string TransactionId { get; set; }
        [Required]
        [Display(Name = "Full Name", Prompt = "Enter Full Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Email", Prompt = "Enter Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [NotMapped]
        public IFormFileCollection FormFiles { get; set; }
    }
}
