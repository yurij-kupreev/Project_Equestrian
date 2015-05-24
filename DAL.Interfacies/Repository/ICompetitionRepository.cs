using DAL.Interface.DTO;

namespace DAL.Interface.Repository
{
    public interface ICompetitionRepository : IRepository<DalCompetition>
    {
        void DeleteById(int key);
    }
}
