using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Halcube_Store_Manager_BLL
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Competition")]
        public int CompetitionId { get; set; }
        public Competition? Competition { get; set; }
        public string? CategoryName { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
