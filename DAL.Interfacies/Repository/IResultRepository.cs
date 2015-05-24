using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Repository
{
    public interface IResultRepository : IRepository<DalResult>
    {
        IEnumerable<DalResult> GetItemsByPredicate(System.Linq.Expressions.Expression<Func<DalResult, bool>> predicate);
        void DeleteById(int key);
    }
}
