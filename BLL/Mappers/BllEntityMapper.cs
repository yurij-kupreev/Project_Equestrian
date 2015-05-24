using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class BllEntityMapper
    {
        public static DalResult ToDalResult(this ResultEntity resultEntity)
        {
            if (resultEntity == null) return null;
            return new DalResult()
            {
                Id = resultEntity.Id,
                Place = resultEntity.Place,
                Points = resultEntity.Points,
                AthleteId = resultEntity.AthleteId,
                CompetitionId = resultEntity.CompetitionId,
                AthleteName = resultEntity.AthleteName,
                CompetitionTitle = resultEntity.CompetitionTitle,
                CompetitionProgram = resultEntity.CompetitionProgram
            };
        }

        public static ResultEntity ToBllResult(this DalResult dalResult)
        {
            if (dalResult == null) return null;
            return new ResultEntity()
            {
                Id = dalResult.Id,
                Place = dalResult.Place,
                Points = dalResult.Points,
                AthleteId = dalResult.AthleteId,
                CompetitionId = dalResult.CompetitionId,
                AthleteName = dalResult.AthleteName,
                CompetitionTitle = dalResult.CompetitionTitle,
                CompetitionProgram = dalResult.CompetitionProgram
            };
        }
        public static DalAthlete ToDalAthlete(this AthleteEntity athleteEntity)
        {
            if (athleteEntity == null) return null;
            return new DalAthlete()
            {
                Id = athleteEntity.Id,
                AthleteName = athleteEntity.AthleteName,
                HorseName = athleteEntity.HorseName,
                Points = athleteEntity.Points,
            };
        }

        public static AthleteEntity ToBllAthlete(this DalAthlete dalAthlete)
        {
            if (dalAthlete == null) return null;
            return new AthleteEntity()
            {
                Id = dalAthlete.Id,
                AthleteName = dalAthlete.AthleteName,
                HorseName = dalAthlete.HorseName,
                Points = dalAthlete.Points,
            };
        }
        public static DalCompetition ToDalCompetition(this CompetitionEntity competitionEntity)
        {
            if (competitionEntity == null) return null;
            return new DalCompetition()
            {
                Id = competitionEntity.Id,
                Title = competitionEntity.Title,
                Program = competitionEntity.Program,
                DateBegin = competitionEntity.DateBegin,
                DateEnd = competitionEntity.DateEnd
            };
        }

        public static CompetitionEntity ToBllCompetition(this DalCompetition dalCompetition)
        {
            if (dalCompetition == null) return null;
            return new CompetitionEntity()
            {
                Id = dalCompetition.Id,
                Title = dalCompetition.Title,
                Program = dalCompetition.Program,
                DateBegin = dalCompetition.DateBegin,
                DateEnd = dalCompetition.DateEnd
            };
        }

        public static DalUser ToDalUser(this UserEntity userEntity)
        {
            if (userEntity == null) return null;
            return new DalUser()
            {
                Id = userEntity.Id,
                Email = userEntity.UserEmail,
                Password = userEntity.UserPassword,
                RoleId = userEntity.RoleId,
                AddedDate = userEntity.AddedDate
            };
        }

        public static UserEntity ToBllUser(this DalUser dalUser)
        {
            if (dalUser == null) return null;
            return new UserEntity()
            {
                Id = dalUser.Id,
                UserEmail = dalUser.Email,
                UserPassword = dalUser.Password,
                RoleId = dalUser.RoleId,
                AddedDate = dalUser.AddedDate
            };
        }

        public static DalRole ToDalRole(this RoleEntity roleEntity)
        {
            if (roleEntity == null) return null;
            return new DalRole()
            {
                Id = roleEntity.Id,
                Name = roleEntity.Name
            };
        }

        public static RoleEntity ToBllRole(this DalRole dalRole)
        {
            if (dalRole == null) return null;
            return new RoleEntity()
            {
                Id = dalRole.Id,
                Name = dalRole.Name,
            };
        }
    }
}
