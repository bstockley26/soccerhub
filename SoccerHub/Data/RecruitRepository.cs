using System;
using SoccerHub.Models;
using System.Data;
using Dapper;
using System.Data.Common;
using System.Numerics;

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
            return _connection.Query<Recruit>("SELECT r.RecruitID, r.FirstName, r.LastName, r.Position, pos.PositionName FROM recruit r JOIN position pos ON r.Position = pos.PositionID;");
        }

        public Recruit GetRecruit(int recruitid)
        {
            return _connection.QuerySingle<Recruit>("SELECT r.RecruitID, r.FirstName,r.LastName, r.Position,r.Citizenship,r.PhoneNumber, r.Email,r.ClubTeam, pos.PositionName FROM recruit r JOIN position pos ON r.Position = pos.PositionID WHERE r.RecruitID = @recruitid;", new { recruitid = recruitid });
        }



        //public IEnumerable<Recruit> GetRecruits()
        //{
        //    return _connection.Query<Recruit>("SELECT * FROM recruit;");
        //}
        //public Recruit GetRecruit(int recruitid)
        //{
        //    return _connection.QuerySingle<Recruit>("SELECT * FROM recruit WHERE RECRUITID = @recruitid", new { recruitid = recruitid });
        //}

        public void InsertRecruit(Recruit recruitToInsert)
        {
            _connection.Execute("INSERT INTO recruit (FIRSTNAME, LASTNAME, POSITION, CITIZENSHIP,PhoneNumber, Email, CLUBTEAM, RECRUITID) VALUES (@firstname, @lastname,@position, @citizenship,@phonenumber,@email, @clubteam, @recruitid);",
        new { recruitid = recruitToInsert.RecruitID, firstname = recruitToInsert.FirstName, lastname = recruitToInsert.LastName, position = recruitToInsert.Position, citizenship = recruitToInsert.Citizenship, phonenumber = recruitToInsert.PhoneNumber, email = recruitToInsert.Email, clubteam = recruitToInsert.ClubTeam });

        }


        public IEnumerable<Position> GetPositions()
        {
            return _connection.Query<Position>("SELECT * FROM position;");
        }

        public Recruit AssignPosition()
        {
            var positionList = GetPositions();
            var recruit = new Recruit();
            recruit.Positions = positionList;
            return recruit;
        }

        public void UpdateRecruit(Recruit recruit)
        {
            _connection.Execute("UPDATE recruit SET FirstName =@firstname,LastName= @lastname,Position= @position,Active= @active,Citizenship= @citizenship,PhoneNumber= @phonenumber, Email = @email,ClubTeam = @clubteam WHERE RecruitID = @recruitid ;",
        new {firstname = recruit.FirstName, lastname = recruit.LastName, position = recruit.Position, citizenship = recruit.Citizenship, phonenumber = recruit.PhoneNumber, email = recruit.Email, clubteam = recruit.ClubTeam, recruitid = recruit.RecruitID });

        }

        public void DeleteRecruit(Recruit recruit)
        {
            _connection.Execute("DELETE FROM Recruit WHERE RecruitID = @recruitid;", new { recruitid = recruit.RecruitID });

        }



    }



}




