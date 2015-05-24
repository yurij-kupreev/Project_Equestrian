using BLL.Interface.Entities;
using MvcPL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPL.Infrastructure
{
    public static class ModelMappers
    {
        public static AthleteViewModel ToAthleteView(this AthleteEntity athleteEntity)
        {
            if (athleteEntity == null) return null;
            return new AthleteViewModel()
            {
                Id = athleteEntity.Id,
                AthleteName = athleteEntity.AthleteName,
                HorseName = athleteEntity.HorseName,
                Points = athleteEntity.Points
            };
        }
        public static CompetitionViewModel ToCompetitionView(this CompetitionEntity competitionEntity)
        {
            if (competitionEntity == null) return null;
            return new CompetitionViewModel()
            {
                Id = competitionEntity.Id,
                Title = competitionEntity.Title,
                Program = competitionEntity.Program,
                DateBegin = competitionEntity.DateBegin,
                DateEnd = competitionEntity.DateEnd
            };
        }
        public static ResultViewModel ToResultView(this ResultEntity resultEntity)
        {
            if (resultEntity == null) return null;
            return new ResultViewModel()
            {
                Id = resultEntity.Id,
                AthleteName = resultEntity.AthleteName,
                Place = resultEntity.Place,
                Points = resultEntity.Points,
                CompetitionProgram = resultEntity.CompetitionProgram,
                CompetitionTitle = resultEntity.CompetitionTitle
            };
        }

        public static ResultEntity ToResultEntity(this ResultsAddModel model, int id = 0)
        {
            if (model == null) return null;
            return new ResultEntity()
            {
                Id = id,
                Place = model.Place,
                Points = model.Points
            };
        }

        public static AthleteEntity ToAthleteEntity(this ResultsAddModel model, int id = 0)
        {
            if (model == null) return null;
            return new AthleteEntity()
            {
                Id = id,
                AthleteName = model.AthleteName,
                HorseName = model.HorseName,
            };
        }

        public static CompetitionEntity ToCompetitionEntity(this ResultsAddModel model, int id = 0)
        {
            if (model == null) return null;
            return new CompetitionEntity()
            {
                Id = id,
                Title = model.CompetitionTitle,
                Program = model.CompetitionProgram,
                DateBegin = model.DateBegin,
                DateEnd = model.DateEnd
            };
        }
    }
}