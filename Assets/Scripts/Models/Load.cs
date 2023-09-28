using System.Collections.Generic;
using System.Linq;

namespace Models
{
    public class Load
    {
        private List<FishToSell> fishesToSell = new List<FishToSell>();
        private int devaluationPerHundredKmPercent;

        public Load(int devaluationPerHundredKmPercent, List<FishToSell> fishesToSell)
        {
            this.devaluationPerHundredKmPercent = devaluationPerHundredKmPercent;
            this.fishesToSell = fishesToSell;
        }

        public List<FishToSell> GetFishesToSell() 
        {
            return fishesToSell;
        }
        public int GetTotalKgs()
        {
            return fishesToSell.Sum(fk => fk.Kgs);
        }
        public float TotalDevaluationRate(int kms)
        {
            return TotalDevaluationPercent(kms) / 100;
        }

        float TotalDevaluationPercent(int kms)
        {
            var hundredKms = kms / 100;
            var totalDevaluationPercent = hundredKms * devaluationPerHundredKmPercent;
            return (totalDevaluationPercent < 100) ? totalDevaluationPercent : 100;

        }
    }
}