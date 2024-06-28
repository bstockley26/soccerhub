using System;
using SoccerHub.Models;

namespace SoccerHub.Data
{
	public interface IRecruitRepository
	{
        public IEnumerable<Recruit> GetRecruits();
        Recruit GetRecruit(int recruitNumber);
        public void InsertRecruit(Recruit recruitToInsert);
        public IEnumerable<Position> GetPositions();
        public Recruit AssignPosition();
        void UpdateRecruit(Recruit recruit);
        public void DeleteRecruit(Recruit recruit);
    }
}

