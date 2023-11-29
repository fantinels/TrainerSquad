namespace TrainerSquad.Models.ViewModels
{
    public class PersonalFormViewModel
    {
        public Personal Personal { get; set; }
        public List<Equipment> Equipments { get; set; }
        public List<Client> Clients { get; set; }
        public List<Schedule> Schedules { get; set; }
    }
}
