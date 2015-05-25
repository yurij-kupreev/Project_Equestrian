using DAL.Interface.DTO;
using System.Collections.Generic;

namespace DAL.Interface.Repository
{
    public interface IAthleteRepository : IRepository<DalAthlete>
    {
        IEnumerable<DalAthlete> GetByName(string term);
        void DeleteById(int key);
    }
}
