using System.ComponentModel.DataAnnotations;

namespace TrainerSquad.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public PaymentStatus Status { get; set; }
        [Display(Name = "Preço")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public double Price { get; set; }
        [Display(Name = "Data de Pagamento")]
        [Required(ErrorMessage = "Selecione uma data")]
        [DataType(DataType.Date)]
        public DateTime PayDate { get; set; }
        [Display(Name = "Aluno")]
        public int ClientId { get; set; }
        [Display(Name = "Aluno")]
        public Client Client { get; set; }

    }

    public enum PaymentStatus : int
    {
        PAGO = 0,
        PENDENTE = 1
    }
}
