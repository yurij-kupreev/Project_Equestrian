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
    public class ResultRepository : IResultRepository
    {
        private readonly DbContext context;

        public ResultRepository(DbContext uow)
        {
            this.context = uow;
        }

        public IQueryable<DalResult> GetAll()
        {
            return context.Set<Result>().Select(result =>  new DalResult()
                    {
                        Id = result.Id,
                        Place = result.Place,
                        Points = result.Points,
                        AthleteId = result.AthleteId,
                        CompetitionId = result.CompetitionId,
                        AthleteName = result.Athlete.AthleteName,
                        CompetitionTitle = result.Competition.Title,
                        CompetitionProgram = result.Competition.Program
                    });
        }

        public DalResult GetById(int key)
        {
            var ormResult = context.Set<Result>().FirstOrDefault(result => result.Id == key);
            return new DalResult()
            {
                Id = ormResult.Id,
                Place = ormResult.Place,
                Points = ormResult.Points,
                AthleteId = ormResult.AthleteId,
                CompetitionId = ormResult.CompetitionId,
                AthleteName = ormResult.Athlete.AthleteName,
                CompetitionTitle = ormResult.Competition.Title
            };
        }

        public DalResult GetByPredicate(System.Linq.Expressions.Expression<Func<DalResult, bool>> predicate)
        {
            var param = Expression.Parameter(typeof(Result));
            var result = new CustomExpressionVisitor<Result>(param).Visit(predicate.Body);
            Expression<Func<Result, bool>> lambda = Expression.Lambda<Func<Result, bool>>(result, param);

            return context.Set<Result>().Where(lambda).Select(ormResult =>  new DalResult()
                {
                    Id = ormResult.Id,
                    Place = ormResult.Place,
                    Points = ormResult.Points,
                    AthleteId = ormResult.AthleteId,
                    CompetitionId = ormResult.CompetitionId,
                    AthleteName = ormResult.Athlete.AthleteName,
                    CompetitionTitle = ormResult.Competition.Title,
                    CompetitionProgram = ormResult.Competition.Program
                }).
                FirstOrDefault();
        }

        public IEnumerable<DalResult> GetItemsByPredicate(System.Linq.Expressions.Expression<Func<DalResult, bool>> predicate)
        {
            var param = Expression.Parameter(typeof(Result));
            var result = new CustomExpressionVisitor<Result>(param).Visit(predicate.Body);
            Expression<Func<Result, bool>> lambda = Expression.Lambda<Func<Result, bool>>(result, param);

            return context.Set<Result>().Where(lambda).
                                        Select(ormResult => new DalResult()
                                        {
                                            Id = ormResult.Id,
                                            Place = ormResult.Place,
                                            Points = ormResult.Points,
                                            AthleteId = ormResult.AthleteId,
                                            CompetitionId = ormResult.CompetitionId,
                                            AthleteName = ormResult.Athlete.AthleteName,
                                            CompetitionTitle = ormResult.Competition.Title,
                                            CompetitionProgram = ormResult.Competition.Program
                                        });
        }

        public void Create(DalResult result)
        {
             var resultCheck = context.Set<Result>().
                Where(p => p.AthleteId == result.AthleteId && p.CompetitionId == result.CompetitionId
                    && p.Place == result.Place && p.Points == result.Points).Any();

             if (!resultCheck)
             {
                 context.Set<Result>().Add(result.ToResult());
             }
        }

        public void DeleteById(int resultKey)
        {
            var result = context.Set<Result>().Where(item => item.Id == resultKey).First();
            context.Set<Result>().Remove(result);
        }

        public void DeleteAll()
        {
            IEnumerable<Result> list = context.Set<Result>().Select(ormResult => ormResult);
            context.Set<Result>().RemoveRange(list);
        }

        public void Update(DalResult entity)
        {
            var result = context.Set<Result>().Where(item => item.Id == entity.Id).First();
            result.Place = entity.Place;
            result.Points = entity.Points;
        }        
    }
}
