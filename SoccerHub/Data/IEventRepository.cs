using System;
using SoccerHub.Models;

namespace SoccerHub.Data
{
	public interface IEventRepository
	{

		public IEnumerable<Event> GetAllEvents();
		
	}
}

