using System;
using SoccerHub.Models;
using System.Data;
using Dapper;
using System.Data.Common;
using Mysqlx.Crud;

namespace SoccerHub.Data
{
	public class PlayerRepository: IPlayerRepository
	{
		
		    
        private readonly IDbConnection _connection;

        public PlayerRepository(IDbConnection connection)
        {
            _connection = connection;
        }


        public IEnumerable<Player> GetPlayers()
        {
            return _connection.Query<Player>("SELECT p.PlayerID, p.FirstName, p.LastName, p.Position, p.JerseyNumber, pos.PositionName FROM player p JOIN position pos ON p.Position = pos.PositionID;");
        }

        public Player GetPlayer(int playerid)
        {
            return _connection.QuerySingle<Player>("SELECT p.PlayerID, p.FirstName, p.LastName, p.Position, p.JerseyNumber,p.Active,p.Citizenship,p.Email,p.PhoneNumber, pos.PositionName FROM player p JOIN position pos ON p.Position = pos.PositionID WHERE p.PlayerID = @playerid;", new { playerid = playerid });
        }

        public void InsertPlayer(Player playerToInsert)
        {
            _connection.Execute("INSERT INTO player (PLAYERID, FIRSTNAME, LASTNAME, POSITION, ACTIVE, CITIZENSHIP, Email, PhoneNumber, JerseyNumber) VALUES (@playerid, @firstname, @lastname,@position, @active, @citizenship,@email, @phonenumber, @jerseynumber);",
        new { playerid = playerToInsert.PlayerID, firstname = playerToInsert.FirstName, lastname = playerToInsert.LastName, position = playerToInsert.Position, active = playerToInsert.Active, citizenship = playerToInsert.Citizenship, email = playerToInsert.Email, phonenumber = playerToInsert.PhoneNumber, jerseynumber = playerToInsert.JerseyNumber });

        }
        

        public IEnumerable<Position> GetPositions()
        {
            return _connection.Query<Position>("SELECT * FROM position;");
        }

        public Player AssignPosition()
        {
            var positionList = GetPositions();
            var player = new Player();
            player.Positions = positionList;
            return player;
        }

        public void UpdatePlayer(Player player)
        {
            _connection.Execute("UPDATE player SET FirstName =@firstname,LastName= @lastname,Position= @position,Active= @active,Citizenship= @citizenship,Email = @email,PhoneNumber= @phonenumber,JerseyNumber = @jerseynumber WHERE PlayerID = @playerid ;",
        new { playerid = player.PlayerID, firstname = player.FirstName, lastname = player.LastName, position = player.Position, active = player.Active, citizenship = player.Citizenship, email = player.Email, phonenumber = player.PhoneNumber, jerseynumber = player.JerseyNumber });

        }

        public void DeletePlayer(Player player)
        {
            _connection.Execute("DELETE FROM Player WHERE PlayerID = @playerid;", new { playerid = player.PlayerID });
            
        }

    }

        

 }




