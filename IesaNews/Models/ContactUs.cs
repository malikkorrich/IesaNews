using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IesaNews.Models
{
    public class ContactUs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string firstname { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string lastname { get; set; }
        [Required]
        [MaxLength(50)]
        public string email { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string subject { get; set; }
        [Required]
        [MinLength(5)]
        public string message { get; set; }

       
    }
}
