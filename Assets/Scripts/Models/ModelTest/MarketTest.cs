using Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models.ModelTest
{
    public class MarketTest
    {
        private Load load;
        private List<FishToSell> fishes;
        private List<FishPrice> fishPrices;
        private Market market;
        private int distance;


        [SetUp]
        public void Setup()
        {
            distance = 100;
            market = new Market("Market",distance);
            fishes = new List<FishToSell>()
            {
                new FishToSell("Salmon", 2),
                new FishToSell("Tuna", 5),
                new FishToSell("Cod", 3)
            };
            load = new Load(1, fishes);

            fishPrices = new List<FishPrice>()
        {
            new FishPrice("Salmon", 10),
            new FishPrice("Tuna", 15),
            new FishPrice("Cod", 8)
        };
        }

        [Test]
        public void TotalPriceToSellLoad_ShouldReturnCorrectValue()
        {
            fishPrices.ForEach(fp => market.SetFishPrice(fp));
            var expectedResult = SumOfFishesFinalPrices() * LoadValuationRate();


            var result = market.TotalPriceToSellLoad(load);

            Assert.AreEqual(expectedResult, result);
        }


        private float SumOfFishesFinalPrices()
        {
            var sum = 0;
            foreach (var fish in fishes)
            {
                var fishPrice = fishPrices.Find(fp => fp.Name == fish.Name);
                if(fishPrice != null)
                {
                    sum += fishPrice.PricePerKg * fish.Kgs;
                }
            }
            return sum;

        }

        private float LoadValuationRate()
        {
            return 1- load.TotalDevaluationRate(distance);
        }
    }
}
