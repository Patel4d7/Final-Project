using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamManagementApp.Models
{
    public class TeamMember
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? DOB { get; set; }

        public string Email { get; set; }

        public ICollection<TeamInfo> TeamInfo { get; set; }

        public ICollection<Interest> Interests { get; set; }

        public ICollection<Mark> Marks { get; set; }

    }
}
