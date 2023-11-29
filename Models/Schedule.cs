namespace TrainerSquad.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public DateTime Scheduling { get; set; }
        public ScheduleStatus Status { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
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
