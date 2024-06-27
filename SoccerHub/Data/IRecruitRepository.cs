using System;
using SoccerHub.Models;

namespace SoccerHub.Data
{
	public interface IRecruitRepository
	{
        public IEnumerable<Recruit> GetRecruits();
    }
}

