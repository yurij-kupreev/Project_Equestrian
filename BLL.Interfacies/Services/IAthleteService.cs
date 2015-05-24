using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IAthleteService
    {
        IEnumerable<AthleteEntity> GetAllAthleteEntities();
        void CreateAthlete(AthleteEntity athlete);
        AthleteEntity GetAthleteById(int athleteKey);
        void EditAthlete(AthleteEntity athlete);
    }
}