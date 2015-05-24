using DAL.Interface.DTO;

namespace DAL.Interface.Repository
{
    public interface IAthleteRepository : IRepository<DalAthlete>
    {
        void DeleteById(int key);
    }
}
