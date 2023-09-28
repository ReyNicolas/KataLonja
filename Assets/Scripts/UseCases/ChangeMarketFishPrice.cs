using Models;
using System.Collections.Generic;

namespace UseCases
{
    public class ChangeMarketFishPrice
    {
        List<Market> markets;
        public ChangeMarketFishPrice(List<Market> markets)
        {
            this.markets = markets;
        }

        public void Execute(string fishName, string marketName, int price)
        {

            var market = GetMarket(marketName);
            if (market == null)
            {
                throw new KeyNotFoundException();
            }
            market.SetFishPrice(new FishPrice(fishName, price));
        }

        Market GetMarket(string marketName) =>
            markets.Find(market => market.Name == marketName);
    }
}
