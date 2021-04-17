namespace Domain.Grapes
{
    public class GrapeColour
    {
        public int Id { get; set; }

        public string Colour { get; set; }

        public bool IsNew => Id == default;
    }
}
