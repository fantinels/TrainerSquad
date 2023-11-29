namespace TrainerSquad.Models
{
    public class Personal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public ICollection<Client> Clients { get; set; } = new List<Client>();
        public ICollection<Equipment> Equipments { get; set; } = new List<Equipment>();
        public ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
    }
}
