namespace TrainerSquad.Models.ViewModels
{
    public class ClientFormViewModel
    {
        public Client Client { get; set; }
        public List<Personal> Personals { get; set; }
        public List<Payment> Payments { get; set; }
        public List<PhysicalAssessment> PhysicalAssessments { get; set; }
        public List<Training> Trainings { get; set; }
    }
}
