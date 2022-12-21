using System.ComponentModel.DataAnnotations;

namespace lab5.Models
{
    public class Position
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Salary { get; set; }
    }
}
