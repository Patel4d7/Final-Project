using System;

namespace TeamManagementApp.DTOs
{
    public class MemberDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }    
        public string Email { get; set; }
        public string Skills { get; set; }

        public string Hobby1 { get; set; }
        public string Hobby2 { get; set; }

        public string FavoriteDish { get; set; }

        public DateTime DOB { get; set; }
    }
}
