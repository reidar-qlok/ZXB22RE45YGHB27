using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZXB22RE45YGHB27.Models
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectId { get; set; }
        [StringLength(50)]
        public string ProjectName { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        [StringLength(50)]
        public string Status { get; set; }
        public DateTime Start { get; set; }
        public DateTime Stop { get; set; }
        internal List<ProjectList> ProjectLists { get; set; }
    }
}
