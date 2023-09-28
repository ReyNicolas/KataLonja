using Models;
using NUnit.Framework;
using System.Collections.Generic;

public class VanTest
{
    private Van van;
    private int maxKg;
    private int costToLoad;
    private int costPerKm;
    Load loadWithinCapacity;
    Load loadExceedsCapacity;

    [SetUp]
    public void Setup()
    {
        maxKg = 100;
        costToLoad = 5;
        costPerKm = 2;
        van = new Van(maxKg, costToLoad, costPerKm);

        loadWithinCapacity = new Load(1,new List<FishToSell>()
        {
            new FishToSell("Salmon", 2),
            new FishToSell("Tuna", 5),
            new FishToSell("Cod", 3)
        });

        loadExceedsCapacity = new Load(1,new List<FishToSell>()
        {
            new FishToSell("Salmon", 30),
            new FishToSell("Tuna", 50),
            new FishToSell("Cod", 25)
        });

    }

    [Test]
    public void ValidateThisLoad_WhenThisLoadIsLower_ReturnTrue()
    {
        var result = van.ValidateThisLoad(loadWithinCapacity);
        Assert.IsTrue(result);
    }
    [Test]
    public void ValidateThisLoad_WhenThisLoadIsUpper_ReturnFalse()
    {
        var result = van.ValidateThisLoad(loadExceedsCapacity);
        Assert.IsFalse(result);
    }
    [Test]
    public void GetCostForSellAtThisDistance_WhenKmsIsZero_ReturnCostToLoad()
    {
        var result = van.GetCostForSellAtThisDistance(0);
        Assert.AreEqual(costToLoad, result);            
    }
    [Test]
    public void GetCostForSellAtThisDistance_WhenKmsIsHigherThanZero_ReturnCostToLoadPlusKmsMultiplicatedWithCostPerKM()
    {
        var km = 2;
        var expectedResult = costToLoad + km * costPerKm;

        var result = van.GetCostForSellAtThisDistance(km);
        Assert.AreEqual(expectedResult, result);
    }


}
