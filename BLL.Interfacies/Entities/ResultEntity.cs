namespace BLL.Interface.Entities
{
    public class ResultEntity
    {
        public int Id { get; set; }
        public int Place { get; set; }
        public double Points { get; set; }
        public int AthleteId { get; set; }
        public int CompetitionId { get; set; }
        public string AthleteName { get; set; }
        public string CompetitionTitle { get; set; }
        public string CompetitionProgram { get; set; }
    }
}