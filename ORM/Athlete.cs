using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM
{
    public class Athlete
    {
        public int Id { get; set; }
        public string AthleteName { get; set; }
        public string HorseName { get; set; }
        public virtual ICollection<Result> Results { get; set; }

    }
}
