using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace ZXB22RE45YGHB27.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; } = 0;
        [Required]
        [StringLength(50)]
        public string FirstMidName { get; set; } = default!;
        [Required]
        [StringLength(30)]
        public string LastName { get; set; } = default!;
        [StringLength(25)]
        public string Address { get; set; } = default!;
        [StringLength(25)]
        public string City { get; set; } = default!;
        [StringLength(25)]
        public string PostalCode { get; set; } = default!;
        [StringLength(35)]
        public string Password { get; set; }
        [StringLength(35)]
        public string Role { get; set; } = default!;
        internal List<ProjectList> ProjectLists { get; set; }
    }
}
