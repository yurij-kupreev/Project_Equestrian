using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM
{
    public class Competition
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Program { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
        public virtual ICollection<Result> Results { get; set; }
    }
}
