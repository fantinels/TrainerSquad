using System.ComponentModel.DataAnnotations;

namespace TrainerSquad.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        [Display(Name = "Data")]
        [Required(ErrorMessage = "Selecione uma data")]
        [DataType(DataType.Date)]
        public DateTime Scheduling { get; set; }
        public ScheduleStatus Status { get; set; }
        [Display(Name = "Aluno")]
        public int ClientId { get; set; }
        [Display(Name = "Aluno")]
        public Client Client { get; set; }
        [Display(Name = "Personal")]
        public int PersonalId { get; set; }
        public Personal Personal { get; set; }
    }

    public enum ScheduleStatus : int
    {
        AGENDADO = 0,
        CANCELADO = 1,
        REAGENDADO = 2,
        COMPARECEU = 3,
        NAO_COMPARECEU = 4
    }
}
