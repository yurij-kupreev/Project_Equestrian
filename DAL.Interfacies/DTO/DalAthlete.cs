using System;
namespace DAL.Interface.DTO
{
    public class DalAthlete : IEntity
    {
        public int Id { get; set; }
        public string AthleteName { get; set; }
        public string HorseName { get; set; }
        public double Points { get; set; }
    }
}
