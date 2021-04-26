namespace Domain.Wine
{
    public class WineRating
    {
        public int Id { get; set; }

        public int DrinkerId { get; set; }

        public int WineId { get; set; }

        public int Rating { get; set; }

        public string Note { get; set; }
    }
}
