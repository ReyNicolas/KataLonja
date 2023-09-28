namespace Models
{
    public class FishPrice
    {
        public readonly string Name;
        public readonly int PricePerKg;
        public FishPrice(string fishName, int price)
        {
            Name = fishName;
            PricePerKg = price;
        }

    }
}