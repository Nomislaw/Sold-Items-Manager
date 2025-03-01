using System.ComponentModel.DataAnnotations;

namespace Halcube_Store_Manager_BLL
{
    public class Competition
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public float Profit { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public ICollection<Category>? Categories { get; set; }
    }
}
