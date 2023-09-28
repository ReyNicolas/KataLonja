
namespace Models
{
    public class Van
    {
        public readonly int maxKg;
        public readonly int costToLoad;
        public readonly int costPerKm;
        Load load;

        public Van(int maxKg, int costToLoad, int costPerKm)
        {
            this.maxKg = maxKg;
            this.costToLoad = costToLoad;
            this.costPerKm = costPerKm;
        }

        public void SetLoad(Load load)
        {
            if (ValidateThisLoad(load))
            {
                this.load = load;
            }
        }

        public Load GetLoad()
        {
            return load;   
        }

       public bool ValidateThisLoad(Load load)
        {
           return load.GetTotalKgs() <= maxKg;
        }
       public int GetCostForSellAtThisDistance(int kms)
        {
            return costToLoad + kms * costPerKm;
        }

    }
}