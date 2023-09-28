using NUnit.Framework;
using Models;
using System.Collections.Generic;


namespace Assets.Scripts.Models.ModelTest
{
    public class EnterprisingTest
    {
        private Enterprising enterprising;
        private Van van;
        private Load load;
        private List<FishToSell> fishes;
        private List<FishPrice> fishPrices;
        private List<Market> markets;
        private Market madrid;
        private Market barcelona;
        private Market lisboa;
        private int distance;


        [SetUp]
        public void Setup()
        {
            van = new Van(200, 50, 200);
            distance = 100;
            fishes = new List<FishToSell>()
            {
                new FishToSell("Salmon", 2),
                new FishToSell("Tuna", 5),
                new FishToSell("Cod", 3)
            };
            load = new Load(1, fishes);
            van.SetLoad(load);

            fishPrices = new List<FishPrice>()
        {
            new FishPrice("Salmon", 10),
            new FishPrice("Tuna", 15),
            new FishPrice("Cod", 8)
        };

            madrid = new Market("Madrid", distance);
            barcelona = new Market("Barcelona", distance);
            lisboa = new Market("Lisboa", distance);

            fishPrices.ForEach(fp => madrid.SetFishPrice(fp));
            fishPrices.ForEach(fp => barcelona.SetFishPrice(fp));
            fishPrices.ForEach(fp => lisboa.SetFishPrice(fp));

            markets = new List<Market>() { madrid, barcelona, lisboa };
            enterprising = new Enterprising(van, markets);

        }

        [Test]
        public void GetBestMarketToSell_ShouldReturnNull_WhenBestMarketProfitIsNegative()
        {
            var result = enterprising.GetBestMarketToSell();
            Assert.AreEqual(null, result);
        }

        private Market GetTheBestMarket(List<Market> markets)
        {
            Market marketWithBestProfit = null;
            float maxProfit = 0;
            foreach (var market in markets)
            {
                var totalProfit = market.TotalPriceToSellLoad(load) - van.GetCostForSellAtThisDistance(market.DistanceInKm);
                if (totalProfit > maxProfit)
                {
                    maxProfit = totalProfit;
                    marketWithBestProfit = market;
                }
            }
            return marketWithBestProfit;
        }
    }
}

