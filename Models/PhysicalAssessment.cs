using System.ComponentModel.DataAnnotations;

namespace TrainerSquad.Models
{
    public class PhysicalAssessment
    {
        public int Id { get; set; }
        [Display(Name = "Peso (kg)")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public double Weight { get; set; }
        [Display(Name = "Altura (cm)")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public double Height { get; set; }
        [Display(Name = "IMC")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public double Imc { get; set; }
        [Display(Name = "Data Avaliação Física")]
        [Required(ErrorMessage = "Selecione uma data")]
        [DataType(DataType.Date)]
        public DateTime PhysicalDate { get; set; }
        [Display(Name = "Aluno")]
        public int ClientId { get; set; }
        [Display(Name = "Aluno")]
        public Client Client { get; set; }
    }
}
