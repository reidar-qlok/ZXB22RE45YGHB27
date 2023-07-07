using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZXB22RE45YGHB27.Models
{
    public class ProjectList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectListId { get; set; }
        public DateTime Start { get; set; }
        public DateTime Stop { get; set; }
        public int FK_EmployeeId { get; set; }
        internal virtual Employee Employees { get; set; }
        public int FK_ProjectId { get; set; }
        public string Comments { get; set; }
        internal virtual Project Projects { get; set; }
    }
}
