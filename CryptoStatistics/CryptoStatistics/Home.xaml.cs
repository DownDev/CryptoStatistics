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
        private void OnCryptoTapped(object sender, ItemTappedEventArgs e)
        {
            var data = e.Item as CryptoCurrencyData;
            Navigation.PushModalAsync(new StatisticsDetails(data));
        }

        private async void RemoveFromWatching(object sender, EventArgs e)
        {
            var item = (sender as ImageButton).CommandParameter as CryptoCurrencyData;

            bool delete = await DisplayAlert($"Delete {item.Name}", $"Do you want to remove {item.Name} from your Watchlist?", "Yes", "No");
            if (!delete)
            {
                return;
            }
            await App.Database.DeleteElement(item.Id);

            GetCryptoList();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if(ApiData != null)
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

