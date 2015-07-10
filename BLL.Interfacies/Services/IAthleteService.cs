using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IAthleteService
    {
        IEnumerable<AthleteEntity> GetAllAthleteEntities(int numPage);
        IEnumerable<AthleteEntity> GetAthletesByName(int numPage, string predicate);
        AthleteEntity GetAthleteById(int athleteKey);
        void CreateAthlete(AthleteEntity athlete);
        void EditAthlete(AthleteEntity athlete);
        
    }
}