using System;
namespace SoccerHub.Models
{
	public class Player
	{
        public int PlayerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Active{ get; set; }
        public string Citizenship { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int JerseyNumber { get; set; }
        public IEnumerable<Position> Position { get; set; } 



    }
}

