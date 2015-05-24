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
    public class ResultService : IResultService
    {
        private readonly IUnitOfWork uow;
        private readonly IResultRepository resultRepository;
        private readonly IAthleteRepository athleteRepository;
        private readonly ICompetitionRepository competitionRepository;


        public ResultService(IUnitOfWork uow, IResultRepository resultRepository, IAthleteRepository athleteRepository,
            ICompetitionRepository competitionRepository)
        {
            this.uow = uow;
            this.resultRepository = resultRepository;
            this.athleteRepository = athleteRepository;
            this.competitionRepository = competitionRepository;
        }

        public IEnumerable<ResultEntity> GetAllResultEntities()
        {
            return resultRepository.GetAll().Select(result => result.ToBllResult());
        }

        public IEnumerable<ResultEntity> GetCompetitionResults(int competitionKey)
        {
            return resultRepository.GetItemsByPredicate(p => p.CompetitionId == competitionKey).
                                    OrderBy(p => p.Place).
                                    Select(p => p.ToBllResult());
        }

        public IEnumerable<ResultEntity> GetAtheleteResults(int athleteKey)
        {
            return resultRepository.GetItemsByPredicate(p => p.AthleteId == athleteKey).
                                    OrderBy(p => p.Place).
                                    Select(p => p.ToBllResult());

        }

        public ResultEntity GetResultById(int resultKey)
        {
            return resultRepository.GetByPredicate(item => item.Id == resultKey).ToBllResult();
        }

        public void CreateResult(ResultEntity result)
        {
            resultRepository.Create(result.ToDalResult());
            uow.Commit();
        }

        public void EditResult(ResultEntity result)
        {
            resultRepository.Update(result.ToDalResult());
            uow.Commit();
        }

        public void CreateResult(ResultEntity result, AthleteEntity athlete, CompetitionEntity competition)
        {
            athleteRepository.Create(athlete.ToDalAthlete());
            competitionRepository.Create(competition.ToDalCompetition());
            uow.Commit();

            string athleteName = athlete.AthleteName;
            string horseName = athlete.HorseName;
            result.AthleteId = athleteRepository.GetByPredicate(item => item.AthleteName == athleteName
               && item.HorseName == horseName).Id;

            string title = competition.Title;
            string program = competition.Program;
            DateTime dateBegin = competition.DateBegin;
            DateTime dateEnd = competition.DateEnd;
            result.CompetitionId = competitionRepository.GetByPredicate(item => item.Program == program
                && item.Title == title
                && item.DateBegin == dateBegin && item.DateEnd == dateEnd).Id;

            resultRepository.Create(result.ToDalResult());
            uow.Commit();
        }

        public void DeleteResult(int resultKey)
        {
            var resultEntity = resultRepository.GetByPredicate(item => item.Id == resultKey).ToBllResult();
            if (resultEntity != null)
            {
                int athleteKey = resultEntity.AthleteId;
                int competitionKey = resultEntity.CompetitionId;
                var athleteResults = resultRepository.GetItemsByPredicate(item => item.AthleteId == athleteKey);
                var competitionResults = resultRepository.GetItemsByPredicate(item => item.CompetitionId == competitionKey);
                if (athleteResults.Count() == 1)
                    athleteRepository.DeleteById(athleteKey);
                if (competitionResults.Count() == 1)
                    competitionRepository.DeleteById(competitionKey);
                resultRepository.DeleteById(resultKey);
                uow.Commit();
            }
        }

        public void DeleteAllResults()
        {
            athleteRepository.DeleteAll();
            competitionRepository.DeleteAll();
            resultRepository.DeleteAll();
            uow.Commit();
        }

    }
}

