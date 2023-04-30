using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IesaNews.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /*Titlt is an photo*/
        [Required]
        [MaxLength(50)]
        [MinLength(5)]
        public string title { get; set; }

        [Required]
        public string description { get; set; }

        
        public string image { get; set; }
        List<News> news { get; set; }

    }
}
