using System;
using System.Collections.Generic;
using System.Linq;

namespace Models
{
    public class Market
    {
        public string Name { get; }
        public int DistanceInKm { get; }

        Dictionary<string, FishPrice> fishNameToPrice = new Dictionary<string, FishPrice>();

        public Market(string name, int distanceInKm)
        {
            Name = name;
            DistanceInKm = distanceInKm;
        }

        public int GetPricePerKgsOfThisFishName(string fishName)
        {
            return fishNameToPrice.ContainsKey(fishName)
                ? fishNameToPrice[fishName].PricePerKg
                : 0;
        }

        public void SetFishPrice(FishPrice fishPrice)
        {
            if (fishNameToPrice.ContainsKey(fishPrice.Name))
            {
                fishNameToPrice[fishPrice.Name] = fishPrice;
                return;
            }
            fishNameToPrice.Add(fishPrice.Name, fishPrice);
        }

        public float TotalPriceToSellLoad(Load load)
        {
            return PriceWithoutDevaluation(load) * (1- load.TotalDevaluationRate(DistanceInKm));
        }

        float PriceWithoutDevaluation(Load load)
        {
            return load.GetFishesToSell().Sum(fishToSell => GetTotalPriceOfFish(fishToSell));
        }

        int GetTotalPriceOfFish(FishToSell fishToSell)
        {
            return fishNameToPrice.ContainsKey(fishToSell.Name)
                ?fishNameToPrice[fishToSell.Name].PricePerKg * fishToSell.Kgs
                : 0;
        }

    }
}