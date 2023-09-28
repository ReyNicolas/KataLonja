using Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;


namespace Assets.Scripts.Models.ModelTest
{
    
    public class LoadTest
    {
        public Load load;
        public List<FishToSell> fishes;

        [SetUp]
        public void Setup()
        {
            fishes = new List<FishToSell>()
            {
                new FishToSell("Salmon", 2),
                new FishToSell("Tuna", 5),
                new FishToSell("Cod", 3)
            };
            load = new Load(1, fishes);
        }

        [Test]
        public void GetTotalKgs_ShouldReturnSumOfFishWeights()
        {
            int expectedKgs = SumOfFishesToSellKgs();

            // Act
            int totalKgs = load.GetTotalKgs();

            // Assert
            Assert.AreEqual(expectedKgs, totalKgs);
        }

        [Test]
        public void TotalDevaluationRate_WhenFinalRateIsLowerThanOne_ShouldReturnCorrectRate()
        {
            var kms = 500;
            var expectedRate = 0.05f;
            // Act
            var result = load.TotalDevaluationRate(kms);

            // Assert
            Assert.AreEqual(expectedRate, result);
        }
        [Test]
        public void TotalDevaluationRate_WhenFinalRateIsHigherThanOne_ShouldReturnOne()
        {
            var kms = 5000000;
            var expectedRate = 1;
            // Act
            var result = load.TotalDevaluationRate(kms);

            // Assert
            Assert.AreEqual(expectedRate, result);
        }

        private int SumOfFishesToSellKgs()
        {
            //Arrange
            return fishes.Sum(f => f.Kgs);
        }
    }
}
