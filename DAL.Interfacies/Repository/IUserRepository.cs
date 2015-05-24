using DAL.Interface.DTO;

namespace DAL.Interface.Repository
{
    public interface IUserRepository : IRepository<DalUser>
    {
        bool Any(string email);
    }
}