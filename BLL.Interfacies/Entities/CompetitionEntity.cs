using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.Interface.Entities
{
    public class CompetitionEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Program { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
    }
}
