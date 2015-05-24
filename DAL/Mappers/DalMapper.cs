using DAL.Interface.DTO;
using ORM;

namespace DAL.Mappers
{
    public static class DalMapper
    {
        //public static DalResult ToDalResult(this Result result)
        //{
        //    if (result == null) return null;
        //    return new DalResult()
        //    {
        //        Id = result.Id,
        //        Place = result.Place,
        //        Points = result.Points,
        //        AthleteId = result.AthleteId,
        //        CompetitionId = result.CompetitionId,
        //        AthleteName = result.Athlete.AthleteName,
        //        CompetitionTitle = result.Competition.Title,
        //        CompetitionProgram = result.Competition.Program
        //    };
        //}

        public static Result ToResult(this DalResult dalResult)
        {
            if (dalResult == null) return null;
            return new Result()
            {
               // Id = dalResult.Id,
                Place = dalResult.Place,
                Points = dalResult.Points,
                AthleteId = dalResult.AthleteId,
                CompetitionId = dalResult.CompetitionId
            };
        }
        //public static DalAthlete ToDalAthlete(this Athlete athlete)
        //{
        //    if (athlete == null) return null;
        //    return new DalAthlete()
        //    {
        //        Id = athlete.Id,
        //        AthleteName = athlete.AthleteName,
        //        HorseName = athlete.HorseName,
        //        Points = athlete.,
                
        //    };
        //}

        public static Athlete ToAthlete(this DalAthlete dalAthlete)
        {
            if (dalAthlete == null) return null;
            return new Athlete()
            {
               // Id = dalAthlete.Id,
                AthleteName = dalAthlete.AthleteName,
                HorseName = dalAthlete.HorseName
            };
        }
        //public static DalCompetition ToDalCompetition(this Competition competition)
        //{
        //    if (competition == null) return null;
        //    return new DalCompetition()
        //    {
        //        Id = competition.Id,
        //        Title = competition.Title,
        //        Program = competition.Program,
        //        DateBegin = competition.DateBegin,
        //        DateEnd = competition.DateEnd
        //    };
        //}

        public static Competition ToCompetition(this DalCompetition dalCompetition)
        {
            if (dalCompetition == null) return null;
            return new Competition()
            {
                //Id = dalCompetition.Id,
                Title = dalCompetition.Title,
                Program = dalCompetition.Program,
                DateBegin = dalCompetition.DateBegin,
                DateEnd = dalCompetition.DateEnd
            };
        }

        //public static DalUser ToDalUser(this User user)
        //{
        //    if (user == null) return null;
        //    return new DalUser()
        //    {
        //        Id = user.Id,
        //        Email = user.Email,
        //        Password = user.Password,
        //        AddedDate = user.AddedDate,
        //        RoleId = user.RoleId
        //    };
        //}

        public static User ToUser(this DalUser dalUser)
        {
            if (dalUser == null) return null;
            return new User()
            {
                Email = dalUser.Email,
                Password = dalUser.Password,
                RoleId = dalUser.RoleId,
                AddedDate = dalUser.AddedDate
            };
        }

        //public static DalRole ToDalRole(this Role role)
        //{
        //    if (role == null) return null;
        //    return new DalRole()
        //    {
        //        Id = role.Id,
        //        Name = role.Name
        //    };
        //}

        public static Role ToRole(this DalRole dalRole)
        {
            if (dalRole == null) return null;
            return new Role()
            {
                //Id = dalRole.Id,
                Name = dalRole.Name,
            };
        }
    }
}
