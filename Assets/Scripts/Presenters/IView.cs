using System;

namespace Presenters
{
    public interface IView
    {
        event Action OnBestMarket;
        event Action<string, string, string> OnFishMarketPriceChange;
        void ShowMessageResult(string message);
    }
}