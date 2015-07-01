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
    public class AthleteRepository : IAthleteRepository
    {
        private readonly DbContext context;

        public AthleteRepository(DbContext uow)
        {
            this.context = uow;
        }

        public IQueryable<DalAthlete> GetAll()
        {

            return context.Set<Athlete>().Select(athlete => new DalAthlete()
                        {
                            Id = athlete.Id,
                            AthleteName = athlete.AthleteName,
                            HorseName = athlete.HorseName,
                            Points = context.Set<Result>().Where(p => p.AthleteId == athlete.Id).
                                                            OrderByDescending(p => p.Points).
                                                            Select(p => p.Points).
                                                            Take(5).
                                                            Sum()
                        });
        }

        public DalAthlete GetById(int key)
        {
            var ormAthlete = context.Set<Athlete>().FirstOrDefault(athlete => athlete.Id == key);
            return new DalAthlete()
            {
                Id = ormAthlete.Id,
                AthleteName = ormAthlete.AthleteName,
                HorseName = ormAthlete.HorseName,
                Points = context.Set<Result>().Where(p => p.AthleteId == ormAthlete.Id).
                                                OrderByDescending(p => p.Points).
                                                Select(p => p.Points).
                                                Take(5).
                                                Sum()
            };
        }

        public DalAthlete GetByPredicate(System.Linq.Expressions.Expression<Func<DalAthlete, bool>> predicate)
        {
            var param = Expression.Parameter(typeof(Athlete));
            var result = new CustomExpressionVisitor<Athlete>(param).Visit(predicate.Body);
            Expression<Func<Athlete, bool>> lambda = Expression.Lambda<Func<Athlete, bool>>(result, param);

            var athlete = context.Set<Athlete>().Where(lambda).Select(ormAthlete => new DalAthlete()
                {
                    Id = ormAthlete.Id,
                    AthleteName = ormAthlete.AthleteName,
                    HorseName = ormAthlete.HorseName,
                    
                    
                }).FirstOrDefault();
            if (context.Set<Result>().Where(p => p.AthleteId == athlete.Id).Any())
                athlete.Points = context.Set<Result>().Where(p => p.AthleteId == athlete.Id).
                                                        OrderByDescending(p => p.Points).
                                                        Select(p => p.Points).
                                                        Take(5).
                                                        Sum();
            else athlete.Points = 0;
            return athlete;
        }

        //public IQueryable<DalAthlete> GetByName(string term)
        //{
        //    return context.Set<Athlete>().Where(item => item.AthleteName.Contains(term))
        //                .Select(item => new DalAthlete()
        //                {
        //                    Id = item.Id,
        //                    AthleteName = item.AthleteName,
        //                    HorseName = item.HorseName,
        //                    Points = context.Set<Result>().Where(p => p.AthleteId == item.Id).
        //                                                    OrderByDescending(p => p.Points).
        //                                                    Select(p => p.Points).
        //                                                    Take(5).
        //                                                    Sum()
        //                });
        //}

        public void Create(DalAthlete athlete)
        {
            var athleteCheck = context.Set<Athlete>().
                Where(p => p.AthleteName == athlete.AthleteName && p.HorseName == athlete.HorseName).Any();

            if (!athleteCheck)
            {
                context.Set<Athlete>().Add(athlete.ToAthlete());
            }
        }

        public void DeleteById(int athleteId)
        {
            var athlete = context.Set<Athlete>().Where(item => item.Id == athleteId).First();
            context.Set<Athlete>().Remove(athlete);
        }

        public void DeleteAll()
        {
            IEnumerable<Athlete> list = context.Set<Athlete>().Select(ormAthlete => ormAthlete);
            context.Set<Athlete>().RemoveRange(list);
        }

        public void Update(DalAthlete entity)
        {
            var athlete = context.Set<Athlete>().Where(item => item.Id == entity.Id).First();
            athlete.AthleteName = entity.AthleteName;
            athlete.HorseName = entity.HorseName;
        }
    }
}
