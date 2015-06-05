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
    public class CompetitionRepository : ICompetitionRepository
    {
        private readonly DbContext context;

        public CompetitionRepository(DbContext uow)
        {
            this.context = uow;
        }

        public IQueryable<DalCompetition> GetAll()
        {
            return context.Set<Competition>().Select(competition => new DalCompetition()
                        {
                            Id = competition.Id,
                            Title = competition.Title,
                            Program = competition.Program,
                            DateBegin = competition.DateBegin,
                            DateEnd = competition.DateEnd
                        });
        }

        public DalCompetition GetById(int key)
        {
            var ormCompetition = context.Set<Competition>().FirstOrDefault(competition => competition.Id == key);
            return new DalCompetition()
            {
                Id = ormCompetition.Id,
                Title = ormCompetition.Title,
                Program = ormCompetition.Program,
                DateBegin = ormCompetition.DateBegin,
                DateEnd = ormCompetition.DateEnd
            };
        }

        public DalCompetition GetByPredicate(System.Linq.Expressions.Expression<Func<DalCompetition, bool>> predicate)
        {
            var param = Expression.Parameter(typeof(Competition));
            var result = new CustomExpressionVisitor<Competition>(param).Visit(predicate.Body);
            Expression<Func<Competition, bool>> lambda = Expression.Lambda<Func<Competition, bool>>(result, param);

            return context.Set<Competition>().Where(lambda).
                Select(ormCompetition => new DalCompetition()
                {
                    Id = ormCompetition.Id,
                    Title = ormCompetition.Title,
                    Program = ormCompetition.Program,
                    DateBegin = ormCompetition.DateBegin,
                    DateEnd = ormCompetition.DateEnd
                }).
                FirstOrDefault();
        }

        public void Create(DalCompetition competition)
        {
            var competitionCheck = context.Set<Competition>().
                Where(p => p.Title == competition.Title && p.Program == competition.Program).Any();
            if (!competitionCheck)
            {
                context.Set<Competition>().Add(competition.ToCompetition());
            }
        }

        public void DeleteById(int competitionKey)
        {
            var competition = context.Set<Competition>().Where(item => item.Id == competitionKey).First();
            context.Set<Competition>().Remove(competition);
        }

        public void DeleteAll()
        {
            IEnumerable<Competition> list = context.Set<Competition>().Select(ormCompetition => ormCompetition);
            context.Set<Competition>().RemoveRange(list);
        }

        public void Update(DalCompetition entity)
        {
            var competition = context.Set<Competition>().Where(item => item.Id == entity.Id).First();
            competition.Title = entity.Title;
            competition.Program = entity.Program;
            competition.DateBegin = entity.DateBegin;
            competition.DateEnd = entity.DateEnd;
        }
    }
}
