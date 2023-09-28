using NUnit.Framework;
using Models;
using System.Collections.Generic;
using UseCases;

namespace Assets.Scripts.Models.ModelTest
{
    public class GetBestMarketNameToSellTest
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
        private GetBestMarketNameToSell getBestMarketNameToSell;


        [SetUp]
        public void Setup()
        {
            van = new Van(200, 50, 200);
        }


        [Test]
        public void Execute_ShouldReturnKeyNotFoundException_WhenThereIsNotBestMarket()
        {
            MarketsProfitsNegatives();

            Assert.Throws<KeyNotFoundException>(() => getBestMarketNameToSell.Execute());
        }

        [Test]
        public void Execute_ShouldMarketName_WhenThereIsBestMarketToSell()
        {
            MarketsProfitsPositives();
            var expectedName = enterprising.GetBestMarketToSell().Name;

            var result = getBestMarketNameToSell.Execute();

            Assert.AreEqual(expectedName, result);
        }

        private void MarketsProfitsNegatives()
        {
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
            getBestMarketNameToSell = new GetBestMarketNameToSell(enterprising);
        }


        private void MarketsProfitsPositives()
        {
            var vieiras = new FishToSell("Vieiras", 50);
            var pulpo = new FishToSell("Pulpo", 100);
            var centollos = new FishToSell("Centollos", 50);

            madrid = new Market("Madrid", 800);
            barcelona = new Market("Barcelona", 1100);
            lisboa = new Market("Lisboa", 600);
            markets = new List<Market>() { madrid, barcelona, lisboa };

            load = new Load(1, new List<FishToSell>() { vieiras, pulpo, centollos });

            van = new Van(200, 5, 2);

            madrid.SetFishPrice(new FishPrice("Vieiras", 500));
            madrid.SetFishPrice(new FishPrice("Pulpo", 0));
            madrid.SetFishPrice(new FishPrice("Centollos", 450));
            barcelona.SetFishPrice(new FishPrice("Vieiras", 450));
            barcelona.SetFishPrice(new FishPrice("Pulpo", 120));
            barcelona.SetFishPrice(new FishPrice("Centollos", 0));
            lisboa.SetFishPrice(new FishPrice("Vieiras", 600));
            lisboa.SetFishPrice(new FishPrice("Pulpo", 100));
            lisboa.SetFishPrice(new FishPrice("Centollos", 500));


            van.SetLoad(load);

            enterprising = new Enterprising(van, markets);

            getBestMarketNameToSell = new GetBestMarketNameToSell(enterprising);
        }
    }
}

