﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.Repository;

namespace BLL.Services
{
    public class AthleteService : IAthleteService
    {
        private readonly IUnitOfWork uow;
        private readonly IAthleteRepository athleteRepository;

        public AthleteService(IUnitOfWork uow, IAthleteRepository repository)
        {
            this.uow = uow;
            this.athleteRepository = repository;
        }

        public IEnumerable<AthleteEntity> GetAllAthleteEntities()
        {
            return athleteRepository.GetAll().
                OrderByDescending(p => p.Points).
                Select(athlete => athlete.ToBllAthlete());
        }

        public void CreateAthlete(AthleteEntity athlete)
        {
            athleteRepository.Create(athlete.ToDalAthlete());
            uow.Commit();
        }

        public AthleteEntity GetAthleteById (int athleteKey)
        {
            return athleteRepository.GetByPredicate(item => item.Id == athleteKey).ToBllAthlete();
        }

        public void EditAthlete(AthleteEntity athlete)
        {
            athleteRepository.Update(athlete.ToDalAthlete());
            uow.Commit();
        }
    }
}