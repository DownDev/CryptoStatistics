using System;
using System.Collections.Generic;

using Xamarin.Forms;
using CryptoStatistics.Models;
using CryptoStatistics.Services;
using System.Linq;

namespace CryptoStatistics
{
    public partial class Statistics : ContentPage
    {
        private ICollection<CryptoCurrencyData> ApiData;
        public Statistics()
        {
            InitializeComponent();
            GetApiData();
        }

        private string GetPickerData()
        {
            //get data from picker code here
            return "";
        }

        private async void GetApiData()
        {
            var response = await ApiService.GetDataFromApiAsync<AssetsApiResponseModel>("https://api.coincap.io/v2/assets/", new Dictionary<string, string>() { { "limit", "5" } });
            ApiData = response.Data.ToList();
            listView.ItemsSource = response.Data;
        }

        private void SearchData(object sender, TextChangedEventArgs e)
        {
            var result = ApiData.Where(n => n.Name.ToLower().Contains(e.NewTextValue.ToLower()));
            listView.ItemsSource = result;
        }
    }
}

