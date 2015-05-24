using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM
{
    //[Table("Results")]
    public class Result
    {
        public int Id { get; set; }
        public int Place { get; set; }
        //[DefaultValue(0)]
        public double Points { get; set; }
        public int AthleteId { get; set; }
        public virtual Athlete Athlete { get; set; }
        public int CompetitionId { get; set; }
        public virtual Competition Competition { get; set; }
    }
}
