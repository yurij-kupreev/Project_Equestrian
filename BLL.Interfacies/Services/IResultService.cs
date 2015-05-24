using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IResultService
    {
        IEnumerable<ResultEntity> GetAllResultEntities();
        IEnumerable<ResultEntity> GetCompetitionResults(int competitionKey);
        IEnumerable<ResultEntity> GetAtheleteResults(int athleteKey);
        ResultEntity GetResultById(int resultKey);
        void CreateResult(ResultEntity user);
        void CreateResult(ResultEntity result, AthleteEntity athlete, CompetitionEntity competition);
        void EditResult(ResultEntity result);
        void DeleteResult(int resultKey);
        void DeleteAllResults();
    }
}