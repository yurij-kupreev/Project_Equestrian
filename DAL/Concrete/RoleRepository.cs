using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using DAL.Mappers;
using ORM;
using System.Linq.Expressions;

namespace DAL.Concrete
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DbContext context;

        public RoleRepository(DbContext uow)
        {
            this.context = uow;
        }

        public IQueryable<DalRole> GetAll()
        {
            return context.Set<Role>().Select(role => new DalRole()
            {
                Id = role.Id,
                Name = role.Name
            });
        }

        public DalRole GetById(int key)
        {
            var ormUser = context.Set<Role>().FirstOrDefault(role => role.Id == key);
            return new DalRole()
            {
                Id = ormUser.Id,
                Name = ormUser.Name
            };
        }
        public DalRole GetByPredicate(System.Linq.Expressions.Expression<Func<DalRole, bool>> predicate)
        {
            var param = Expression.Parameter(typeof(Role));
            var result = new CustomExpressionVisitor<Role>(param).Visit(predicate.Body);
            Expression<Func<Role, bool>> lambda = Expression.Lambda<Func<Role, bool>>(result, param);

            return context.Set<Role>().Where(lambda).Select(ormRole => new DalRole()
            {
                Id = ormRole.Id,
                Name = ormRole.Name,
            }).
                FirstOrDefault();
        }

        public void Create(DalRole e)
        {
            context.Set<Role>().Add(e.ToRole());
        }


        #region NI

        public void Update(DalRole entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }
         #endregion
    }

       

}
