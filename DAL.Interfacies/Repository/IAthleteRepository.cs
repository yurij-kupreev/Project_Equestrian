using DAL.Interface.DTO;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Interface.Repository
{
    public interface IAthleteRepository : IRepository<DalAthlete>
    {
        //IQueryable<DalAthlete> GetByName(string term);
        void DeleteById(int key);
    }
}
