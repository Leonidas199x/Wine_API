namespace Domain.Drinker
{
    public class Drinker
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsNew => Id == default;
    }
}
