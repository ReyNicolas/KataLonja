using NUnit.Framework;
using Models;
using System.Collections.Generic;
using UseCases;

namespace Assets.Scripts.Models.ModelTest
{
    public class ChangeMarketFishPriceTest
    {
        private List<FishPrice> fishPrices;
        private List<Market> markets;
        private Market madrid;
        private Market barcelona;
        private Market lisboa;
        private int distance;
        private ChangeMarketFishPrice changeMarketFishPrice;

        [SetUp]
        public void Setup()
        {
            distance = 100;
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
            changeMarketFishPrice = new ChangeMarketFishPrice(markets);
        }


        [Test]
        public void Execute_marketExists_ShouldAddFishPrice()
        {
            var expectedPrice = 10;
            var fishNameNotInMarket = "Pulpo";

            changeMarketFishPrice.Execute(fishNameNotInMarket, madrid.Name, expectedPrice);
            var result = madrid.GetPricePerKgsOfThisFishName(fishNameNotInMarket);

            Assert.AreEqual(expectedPrice, result);

        }

        [Test]
        public void Execute_marketDoesntExist_ShouldAddFishPrice()
        {
            var marketNameThatNotExist = "Nada";
            var expectedPrice = 10;
            var fishNameNotInMarket = "Pulpo";

            Assert.Throws<KeyNotFoundException>(() => changeMarketFishPrice.Execute(fishNameNotInMarket, marketNameThatNotExist, expectedPrice));


        }

    }
}

