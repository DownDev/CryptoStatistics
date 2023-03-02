using System;
using System.Collections.Generic;

using Xamarin.Forms;
using CryptoStatistics.Models;
using CryptoStatistics.Services;
using System.Linq;
using CryptoStatistics.Enums;

namespace CryptoStatistics
{
    public partial class Statistics : ContentPage
    {
        private List<CryptoCurrencyData> ApiData;
        private OrderByStatusEnum OrderByStatus;
        public Statistics()
        {
            InitializeComponent();
            GetApiData();

            OrderByStatus = OrderByStatusEnum.Default;
            sortButton.Text = $"Sort: {OrderByStatus}";
        }

        private string GetPickerData()
        {
            return picker.Items[picker.SelectedIndex];
        }

        private async void GetApiData()
        {
            var response = await ApiService.GetDataFromApiAsync<AssetsApiResponseModel>("https://api.coincap.io/v2/assets/", new Dictionary<string, string>() { { "limit", GetPickerData() } });
            ApiData = response.Data.ToList();

            listView.ItemsSource = !string.IsNullOrEmpty(searchBar.Text) ? 
                ApiData.Where(n => n.Name.ToLower().Contains(searchBar.Text.ToLower())) : ApiData;
        }

        private List<CryptoCurrencyData> SortedData()
        {
            if(OrderByStatus == OrderByStatusEnum.Default)
            {
                var result = !string.IsNullOrEmpty(searchBar.Text) ?
                    ApiData.Where(n => n.Name.ToLower().Contains(searchBar.Text.ToLower())).OrderBy(n => n.PriceUsdD).ToList() :
                    ApiData.OrderBy(n => n.PriceUsdD).ToList();

                OrderByStatus = OrderByStatusEnum.Ascending;
                return result;
            }
            else if(OrderByStatus == OrderByStatusEnum.Ascending)
            {
                var result = !string.IsNullOrEmpty(searchBar.Text) ?
                    ApiData.Where(n => n.Name.ToLower().Contains(searchBar.Text.ToLower())).OrderByDescending(n => n.PriceUsdD).ToList() :
                    ApiData.OrderByDescending(n => n.PriceUsdD).ToList();

                OrderByStatus = OrderByStatusEnum.Descending;
                return result;
            }
            else
            {
                List<CryptoCurrencyData> result = !string.IsNullOrEmpty(searchBar.Text) ?
                    ApiData.Where(n => n.Name.ToLower().Contains(searchBar.Text.ToLower())).ToList() : ApiData.ToList();

                OrderByStatus = OrderByStatusEnum.Default;
                return result;
            }
        }

        private void SearchData(object sender, TextChangedEventArgs e)
        {
            var result = ApiData.Where(n => n.Name.ToLower().Contains(e.NewTextValue.ToLower()));
            listView.ItemsSource = result;
        }

        private void PickerValueChanged(object sender, EventArgs e)
        {
            GetApiData();
        }

        private void RefreshData(object sender, EventArgs e)
        {
            GetApiData();

            OrderByStatus = OrderByStatusEnum.Default;
            sortButton.Text = $"Sort: {OrderByStatus}";

            listView.EndRefresh();
        }

        private void SortData(object sender, EventArgs e)
        {
            listView.ItemsSource = SortedData();

            sortButton.Text = $"Sort: {OrderByStatus}";
        }

        private void ShowDetails(object sender, ItemTappedEventArgs e)
        {
            var data = e.Item as CryptoCurrencyData;
            Navigation.PushModalAsync(new StatisticsDetails(data));
        }
    }
}

