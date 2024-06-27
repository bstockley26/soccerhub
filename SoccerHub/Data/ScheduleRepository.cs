using System;
using System.Data;
using Dapper;
using SoccerHub.Models;

namespace SoccerHub.Data
{
	public class ScheduleRepository : IScheduleRepository
	{
        private readonly IDbConnection _connection;

        public ScheduleRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Schedule> GetAllGames()
        {
            return _connection.Query<Schedule>("SELECT * FROM schedule;");
        }
    }
}

