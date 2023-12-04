using System.ComponentModel.DataAnnotations;

namespace TrainerSquad.Models
{
    public class Client
    {
        public int Id { get; set; }
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MinLength(2, ErrorMessage = "Insira um nome maior")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Display(Name = "CPF")]
        [Required(ErrorMessage = "Este campo é obrigatório e deve conter 11 dígitos")]
        [MinLength(11, ErrorMessage = "Deve conter 11 dígitos")]
        [MaxLength(11, ErrorMessage = "Deve conter 11 dígitos")]
        public string Cpf { get; set; }
        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "Selecione uma data")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "Este campo é obrigatório e deve conter 11 dígitos")]
        [MinLength(11, ErrorMessage = "Deve conter 11 dígitos")]
        [MaxLength(11, ErrorMessage = "Deve conter 11 dígitos")]
        public string Telephone { get; set; }
        [Display(Name = "Sexo")]
        public GenderStatus Gender { get; set; }
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Email { get; set; }
        [Display(Name = "Plano")]
        public PlanStatus Plan { get; set; }
        public ClientStatus Status { get; set; }
        [Display(Name = "Personal")]
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
