using System.ComponentModel;

namespace TrainerSquad.Models
{
    public class Training
    {
        public int Id { get; set; }
        public string Note { get; set; } // observação
        public int Load { get; set; } // carga
        public int Serie { get; set; }
        public int Repetition { get; set; }
        public string Exercise { get; set; }
        public TrainingType Type { get; set; }
        public int ClientId { get; set; }
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
