using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamManagementApp.Models
{
    public class TeamInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public string College { get; set; }
        public string CollegeProgram { get; set; }
        public string YearInProgram { get; set; }

        [Required]
        public string CollegeEmail { get; set; }
        public TeamMember TeamMembers { get; set; }
    }
}
