using System;
using SoccerHub.Models;

namespace SoccerHub.Data
{
	public interface IScheduleRepository
	{

		public IEnumerable<Schedule> GetAllGames();
		
	}
}

