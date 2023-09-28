namespace Models
{
    public class FishToSell
    {
        public string Name { get; set; }
        public int Kgs { get; set; }

        public FishToSell(string name,int kgs)
        {
            Name = name;
            Kgs = kgs;
        }      
    }
}