using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Halcube_Store_Manager_BLL
{
    public class Item 
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public string? ItemName { get; set; }
        public float Discount { get; set; }
        public bool IsItemSold { get; set; }

    }
}