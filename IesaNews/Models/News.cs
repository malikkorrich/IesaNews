using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IesaNews.Models
{
    public class News
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string title { get; set; }
        [Required]
        public DateTime date { get; set; }
        [Required]
        public string image { get; set; }
        [Required]
        public string topic { get; set; }

         public int categoryId { get; set; }
        public Category category { get; set; }

        public int usuarioId { get; set; }
        public User usuario { get; set; }
             
    }
}
