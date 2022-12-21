using System.ComponentModel.DataAnnotations;

namespace lab5.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
