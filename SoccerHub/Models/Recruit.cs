using System;
namespace SoccerHub.Models
{
	public class Recruit
	{
       
            public string FirstName { get; set; }
            public string LastName { get; set; }
        public IEnumerable<Position> Positions { get; set; }
        public string Citizenship { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }
            public string ClubTeam { get; set; }
        public int RecruitID { get; set; }
        public int Position { get; set; }
        public string PositionName { get; set; }


    }
}

