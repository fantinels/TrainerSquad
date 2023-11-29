namespace TrainerSquad.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Cpf { get; set; }
        public DateTime BirthDate { get; set; }
        public string Telephone { get; set; }
        public GenderStatus Gender { get; set; }
        public string Email { get; set; }
        public PlanStatus Plan { get; set; }
        public ClientStatus Status { get; set; }
        public int PersonalId { get; set; }
        public Personal Personal { get; set; }
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
        public ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
        public ICollection<PhysicalAssessment> PhysicalAssessments { get; set; } = new List<PhysicalAssessment>();
        public ICollection<Training> Trainings { get; set; } = new List<Training>();

    }

    public enum ClientStatus : int
    {
        ATIVO = 0,
        INATIVO = 1
    }

    public enum PlanStatus : int
    {
        MENSAL = 0,
        TRIMESTRAL = 1,
        SEMESTRAL = 2,
        ANUAL = 3
    }

    public enum GenderStatus : int
    {
        FEMININO = 0,
        MASCULINO = 1
    }
}
