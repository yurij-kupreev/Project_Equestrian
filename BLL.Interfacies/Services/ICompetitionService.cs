using System.Collections.Generic;
using BLL.Interface.Entities;
using System;

namespace BLL.Interface.Services
{
    public interface ICompetitionService
    {
        IEnumerable<CompetitionEntity> GetAllCompetitionEntities();
        void CreateCompetition(CompetitionEntity competition);
        CompetitionEntity GetCompetitionById(int competitionKey);
        void EditCompetition(CompetitionEntity competition);
    }
}