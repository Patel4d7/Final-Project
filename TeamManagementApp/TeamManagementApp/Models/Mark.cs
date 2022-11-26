using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamManagementApp.Models
{
    public class Mark
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int DBMS { get; set; }

        public int NanoMechanics { get; set; }

        public int DataStructure { get; set; }

        public int Java { get; set; }

        public TeamMember TeamMembers { get; set; }
    }
}
