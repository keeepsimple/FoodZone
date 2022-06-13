namespace FoodZone.API.Models
{
    public class FeedbackDTO
    {
        public int Id { get; set; }
        public string Comment { get; set; }

        public int FoodId { get; set; }
    }
}
