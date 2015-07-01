using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IAthleteService
    {
        IEnumerable<AthleteEntity> GetAllAthleteEntities(int numPage, string predicate);
        //IEnumerable<AthleteEntity> GetAthletesByName(string term);
        AthleteEntity GetAthleteById(int athleteKey);
        void CreateAthlete(AthleteEntity athlete);
        void EditAthlete(AthleteEntity athlete);
        
    }
}