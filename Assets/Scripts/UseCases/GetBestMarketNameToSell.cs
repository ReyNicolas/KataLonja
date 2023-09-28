using Models;
using System.Collections.Generic;

namespace UseCases
{
    public class GetBestMarketNameToSell
    {
        Enterprising enterprising;
        public GetBestMarketNameToSell(Enterprising enterprising)
        {
            this.enterprising = enterprising;
        }

        public string Execute()
        {
            var market = enterprising.GetBestMarketToSell();
            if(market == null)
            {
                throw new KeyNotFoundException("Ningun mercado da ganancias");
            }                
            return enterprising.GetBestMarketToSell().Name;
        }
    }
}