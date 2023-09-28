

using System;
using System.Collections.Generic;

namespace Models
{
    public class Enterprising
    {
        Van van;
        List<Market> marketList;

        public Enterprising(Van van, List<Market> marketList)
        {
            this.van = van;
            this.marketList = marketList;
        }

        public Market GetBestMarketToSell()
        {
            Market bestMarket = null;
            float maxProfit = 0;
            foreach (Market market in marketList)
            {                
                if(GetTotalProfit(market)> maxProfit)
                {
                    bestMarket = market;
                }
            }
            return bestMarket;
        }

        private float GetTotalProfit(Market market)
        {
            return market.TotalPriceToSellLoad(van.GetLoad()) - van.GetCostForSellAtThisDistance(market.DistanceInKm);
        }
    }
}