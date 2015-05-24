using DAL.Interface.DTO;
using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Interface.DTO
{
    public class DalCompetition : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Program { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
    }
}
