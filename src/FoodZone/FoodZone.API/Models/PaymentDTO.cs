namespace FoodZone.API.Models
{
    public class PaymentDTO
    {
        public int Id { get; set; }
        public string TransactionHistory { get; set; }

        public DateTime PayDate { get; set; }

        public string AccountId { get; set; }
    }
}
