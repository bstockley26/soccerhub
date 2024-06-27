using System;
using SoccerHub.Models;

namespace SoccerHub.Data
{
	public interface IPlayerRepository
	{
        public IEnumerable<Player> GetPlayers();
        Player GetPlayer(int playerNumber);
        public void InsertPlayer(Player playerToInsert);
        public IEnumerable<Position> GetPositions();
        public Player AssignPosition();
        void UpdatePlayer(Player player);
        public void DeletePlayer(Player player);

    }
}

