using System.ComponentModel.DataAnnotations;

namespace TrainerSquad.Models
{
    public class Personal
    {
        public int Id { get; set; }
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MinLength(2, ErrorMessage = "Insira um nome maior")]
        [MaxLength(30)]
        public string Name { get; set; }
        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Este campo é obrigatório e deve contar 4 caracteres")]
        [MinLength(4, ErrorMessage = "Sua senha deve conter 4 caracteres")]
        [MaxLength(4, ErrorMessage = "Sua senha deve conter 4 caracteres")]
        public string Password { get; set; }
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Email { get; set; }
        public ICollection<Client> Clients { get; set; } = new List<Client>();
        public ICollection<Equipment> Equipments { get; set; } = new List<Equipment>();
        public ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
    }
}
