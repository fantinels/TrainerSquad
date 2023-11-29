namespace TrainerSquad.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        public string EquipmentName { get; set; }
        public EquipmentStatus Status { get; set; }
        public DateTime LastMaintenance { get; set; }
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
