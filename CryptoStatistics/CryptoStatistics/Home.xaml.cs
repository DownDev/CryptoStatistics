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
        public Home()
        {
            InitializeComponent();
            GetCryptoList();
            
        }
        private async void GetCryptoList()
        {
            // display list not api call

            var response = await ApiService.GetDataFromApiAsync<AssetsApiResponseModel>("https://api.coincap.io/v2/assets/", new Dictionary<string, string>() { { "limit", "3" } });
            CryptoListView.ItemsSource = response.Data.ToList();
        }

        private void OnCryptoSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
        }
    }
}

