using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.Repository;
using System;

namespace BLL.Services
{
    public class CompetitionService : ICompetitionService
    {
        private readonly IUnitOfWork uow;
        private readonly ICompetitionRepository competitionRepository;

        public CompetitionService(IUnitOfWork uow, ICompetitionRepository repository)
        {
            this.uow = uow;
            this.competitionRepository = repository;
        }

        public IEnumerable<CompetitionEntity> GetAllCompetitionEntities()
        {
            return competitionRepository.GetAll().Select(competition => competition.ToBllCompetition());
        }

        public CompetitionEntity GetCompetitionById(int competitionKey)
        {
            return competitionRepository.GetByPredicate(item => item.Id == competitionKey).ToBllCompetition();
        }

        public void CreateCompetition(CompetitionEntity competition)
        {
            competitionRepository.Create(competition.ToDalCompetition());
            uow.Commit();
        }

        public void EditCompetition(CompetitionEntity competition)
        {
            competitionRepository.Update(competition.ToDalCompetition());
            uow.Commit();
        }
    }
}
