using System;
using System.Data;
using Dapper;
using SoccerHub.Models;

namespace SoccerHub.Data
{
	public class EventRepository : IEventRepository
	{
        private readonly IDbConnection _connection;

        public EventRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return _connection.Query<Event>("SELECT * FROM event;");
        }
    }
}

