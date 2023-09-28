using System;
using TMPro;
using UnityEngine;

namespace Views
{
    public class FishMarketPriceContainer : MonoBehaviour
    {
        [SerializeField] string marketName;
        [SerializeField] string fishName;
        [SerializeField] TMP_InputField priceIF;
        public event Action<string, string, string> OnPriceChange;

        private void Start()
        {
            priceIF = GetComponent<TMP_InputField>();
            priceIF.onValueChanged.AddListener(InvokeChangePrice);
        }

        void InvokeChangePrice(string text)
        {
            OnPriceChange?.Invoke(fishName, marketName, priceIF.text);
        }
    }
}

