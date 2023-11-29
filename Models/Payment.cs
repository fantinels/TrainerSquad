namespace TrainerSquad.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public PaymentStatus Status { get; set; }
        public double Price { get; set; }
        public DateTime PayDate { get; set; }
        public int ClientId { get; set; } 
        public Client Client { get; set; }

    }

    public enum PaymentStatus : int
    {
        PAGO = 0,
        PENDENTE = 1
    }
}
