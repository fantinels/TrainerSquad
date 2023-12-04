using System.ComponentModel.DataAnnotations;

namespace TrainerSquad.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        [Display(Name = "Nome do Equipamento")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string EquipmentName { get; set; }
        public EquipmentStatus Status { get; set; }
        [Display(Name = "Última Manutenção")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Selecione uma data")]
        public DateTime LastMaintenance { get; set; }
        [Display(Name = "Personal")]
        public int PersonalId { get; set; }
        public Personal Personal { get; set; }
    }

    public enum EquipmentStatus : int
    {
        DISPONIVEL = 0,
        EM_MANUTENCAO = 1,
        DANIFICADO = 2,
        DESCARTADO = 3
    }
}
