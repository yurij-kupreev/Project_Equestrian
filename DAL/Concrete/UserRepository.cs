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
    public class UserRepository : IUserRepository
    {
        private readonly DbContext context;

        public UserRepository(DbContext uow)
        {
            this.context = uow;
        }

        public IQueryable<DalUser> GetAll()
        {
            return context.Set<User>().Select(user => new DalUser()
                        {
                            Id = user.Id,
                            Email = user.Email,
                            Password = user.Password,
                            AddedDate = user.AddedDate,
                            RoleId = user.RoleId
                        });
        }

        public DalUser GetById(int key)
        {
            var ormUser = context.Set<User>().FirstOrDefault(user => user.Id == key);
            return new DalUser()
            {
                Id = ormUser.Id,
                Email = ormUser.Email,
                Password = ormUser.Password,
                AddedDate = ormUser.AddedDate,
                RoleId = ormUser.RoleId
            };
        }

        public DalUser GetByPredicate(System.Linq.Expressions.Expression<Func<DalUser, bool>> predicate)
        {
            var param = Expression.Parameter(typeof(User));
            var result = new CustomExpressionVisitor<User>(param).Visit(predicate.Body);
            Expression<Func<User, bool>> lambda = Expression.Lambda<Func<User, bool>>(result, param);

            return context.Set<User>().Where(lambda).Select(ormUser => new DalUser()
                {
                    Id = ormUser.Id,
                    Email = ormUser.Email,
                    Password = ormUser.Password,
                    AddedDate = ormUser.AddedDate,
                    RoleId = ormUser.RoleId
                }).
                FirstOrDefault();
        }

        public bool Any(string email)
        {
            return context.Set<User>().Where(item => item.Email == email).Any();
        }

        public void Create(DalUser e)
        {
            context.Set<User>().Add(e.ToUser());
        }

        #region NI

        public void Update(DalUser entity)
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
