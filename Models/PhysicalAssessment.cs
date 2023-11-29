namespace TrainerSquad.Models
{
    public class PhysicalAssessment
    {
        public int Id { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double Imc { get; set; }
        public DateTime PhysicalDate { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
