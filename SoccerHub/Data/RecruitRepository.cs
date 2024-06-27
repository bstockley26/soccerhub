using System;
using SoccerHub.Models;
using System.Data;
using Dapper;
using System.Data.Common;

namespace SoccerHub.Data
{
	public class RecruitRepository: IRecruitRepository
	{
		
		    
        private readonly IDbConnection _connection;

        public RecruitRepository(IDbConnection connection)
        {
            _connection = connection;
        }


        public IEnumerable<Recruit> GetRecruits()
        {
            return _connection.Query<Recruit>("SELECT * FROM recruit;");
        }
        

        
    }

        

 }




