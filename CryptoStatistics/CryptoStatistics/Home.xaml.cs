using System;
using System.Collections.Generic;
using CryptoStatistics.Models;
using CryptoStatistics.Services;
using System.Linq;
using Xamarin.Forms;

namespace CryptoStatistics
{
    public partial class Home : ContentPage
    {
        private List<CryptoCurrencyData> ApiData;

        public Home()
        {
            InitializeComponent();
            GetDataFromApi();
            
        }
        private async void GetCryptoList()
        {
            // display list not api call
            var cryptoCurrencies = await App.Database.GetCryptoCurrencies();
            var result = new List<CryptoCurrencyData>();
            foreach (var item in cryptoCurrencies)
            {
                var followingCurrency = ApiData.FirstOrDefault(n => n.Id == item.Name);
                if (followingCurrency != null)
                {
                    result.Add(followingCurrency);
                }
            }
            CryptoListView.ItemsSource = result;
        }

        private async void GetDataFromApi()
        {
            var response = await ApiService.GetDataFromApiAsync<AssetsApiResponseModel>("https://api.coincap.io/v2/assets/", new Dictionary<string, string>() { { "limit", "100" } });
            ApiData = response.Data.ToList();
            GetCryptoList();
        }
        private void OnCryptoSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            var item = (string)(sender as ImageButton).CommandParameter;

            await App.Database.DeleteElement(item);

            GetCryptoList();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if(ApiData!= null)
            {
                GetCryptoList();
            }
            else
            {
                GetDataFromApi();
            }
        }
    }
}

