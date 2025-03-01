using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Halcube_Store_Manager_BLL
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public string? ProductName { get; set; }
        public int ItemQuantity { get; set; } 
        public int SoldItemQuantity { get; set; } 
        public float Price { get; set; }
        public float Discounts { get; set; }
        public float ProductProfit { get; set; }
        public ICollection<Item>? Items { get; set; }
    }
}
