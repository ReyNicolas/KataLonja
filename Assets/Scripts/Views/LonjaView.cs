using Presenters;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Views
{
    public class LonjaView : MonoBehaviour, IView
    {
        [SerializeField] TextMeshProUGUI bestMarketText;
        [SerializeField] List<FishMarketPriceContainer> fishMarketPriceContainers;
        LonjaPresenter presenter;
        public event Action OnBestMarket;
        public event Action<string, string, string> OnFishMarketPriceChange;


        private void Start()
        {
            presenter = new LonjaPresenter();
            presenter.Initialize(this);
            fishMarketPriceContainers.ForEach(fmp => fmp.OnPriceChange += OnInvokeChangePrice);
        }
        public void BestMarketButton()
        {
            OnBestMarket?.Invoke();
        }
        public void ShowMessageResult(string message)
        {
            bestMarketText.text = message;

        }

        private void OnInvokeChangePrice(string fishName, string marketName, string fishPrice)
        {
            OnFishMarketPriceChange?.Invoke(fishName, marketName, fishPrice);
        }
    }
}

