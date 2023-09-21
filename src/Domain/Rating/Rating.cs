namespace Domain.Rating
{
    public class WineRating
    {
        public int Id { get; set; }

        public int WineId { get; set; }

        public Drinker.Drinker Drinker { get; set; }

        public int Rating { get; set; }

        public string Note { get; set; }

        public bool IsNew => Id == default;
    }
}
