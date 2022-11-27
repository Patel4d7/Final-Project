using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamManagementApp.Models
{
    public class Interest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(50)]
        public string FavoriteDish { get; set; }


        [StringLength(50)]
        public string Skills { get; set; }

        [StringLength(50)]
        public string Hobby1 { get; set; }

        [StringLength(50)]
        public string Hobby2 { get; set; }

        public TeamMember TeamMembers { get; set; }
    }
}
