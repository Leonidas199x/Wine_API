namespace Domain.StopperType
{
    public class StopperType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsNew => Id == default;
    }
}
