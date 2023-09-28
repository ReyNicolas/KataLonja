using Models;
using System.Collections.Generic;
using UseCases;

namespace Presenters
{
    public class LonjaPresenter
    {
        IView view;
        ChangeMarketFishPrice changeMarketFishPrice;
        GetBestMarketNameToSell getBestMarketNameToSell;

        Enterprising enterprising;
        Load load;
        Van van;
        FishToSell vieiras;
        FishToSell pulpo;
        FishToSell centollos;
        List<Market> markets;
        Market madrid;
        Market barcelona;
        Market lisboa;
        public void Initialize(IView view)
        {
            this.view = view;
            SetInitialValues();

            changeMarketFishPrice = new ChangeMarketFishPrice(markets);
            getBestMarketNameToSell = new GetBestMarketNameToSell(enterprising);
            view.OnBestMarket += BestMarket;
            view.OnFishMarketPriceChange += ChangePrice;
        }

        private void SetInitialValues()
        {
            vieiras = new FishToSell("Vieiras", 50);
            pulpo = new FishToSell("Pulpo", 100);
            centollos = new FishToSell("Centollos", 50);

            madrid = new Market("Madrid", 800);
            barcelona = new Market("Barcelona", 1100);
            lisboa = new Market("Lisboa", 600);
            markets = new List<Market>() { madrid, barcelona, lisboa };

            load = new Load(1, new List<FishToSell>() { vieiras, pulpo, centollos });

            van = new Van(200, 5, 2);
            van.SetLoad(load);

            enterprising = new Enterprising(van, markets);

        }
          
        private void ChangePrice(string fishName, string marketName, string price)
        {
            try
            {
                changeMarketFishPrice.Execute(fishName, marketName, int.Parse(price));
            }
            catch (KeyNotFoundException ex)
            {
                view.ShowMessageResult("Error al cambiar precio:" + ex.Message);
            }
            
        }

        private void BestMarket()
        {
            try
            {
             string marketName = getBestMarketNameToSell.Execute();
             view.ShowMessageResult($"El mercado con mas beneficio es: {marketName}");
            }
            catch(KeyNotFoundException e)
            {
                view.ShowMessageResult("Problema:" + e.Message);
            }
        }
    }
}