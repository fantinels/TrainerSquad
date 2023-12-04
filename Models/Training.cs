using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TrainerSquad.Models
{
    public class Training
    {
        public int Id { get; set; }
        [Display(Name = "Observação")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Note { get; set; }
        [Display(Name = "Carga")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public int Load { get; set; }
        [Display(Name = "Série")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public int Serie { get; set; }
        [Display(Name = "Repetição")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public int Repetition { get; set; }
        [Display(Name = "Exercício")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Exercise { get; set; }
        [Display(Name = "Tipo")]
        public TrainingType Type { get; set; }
        [Display(Name = "Aluno")]
        public int ClientId { get; set; }
        [Display(Name = "Aluno")]
        public Client Client { get; set; }
    }

    public enum TrainingType : int
    {
        TREINO_A = 0,
        TREINO_B = 1,
        TREINO_C = 2,
        TREINO_D = 3
    }
}
