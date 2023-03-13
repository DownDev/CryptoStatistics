using CryptoStatistics.Models;
using CryptoStatistics.Services;
using Microcharts;
using Microcharts.Forms;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CryptoStatistics
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StatisticsDetails : ContentPage
	{
        private List<ChartEntry> chartEntries = new List<ChartEntry>();

        public StatisticsDetails (CryptoCurrencyData data)
		{
			InitializeComponent ();
            GenerateChart(data.Id,"d1",chartLine);
            img.Source = $"https://coinicons-api.vercel.app/api/icon/{data.SymbolLower}";
            title.Text = data.Name;
            price.Text = data.PriceUsdFormatted;
            percent.Text = $"{data.ChangePercent24HrD:F2}%";
            percent.TextColor = data.PercentColor;
        }
        //time = m1, m5, m15, m30, h1, h2, h6, h12, d1
        private async void GenerateChart(string name, string time, ChartView chart)
        {
            var response = await ApiService.GetDataFromApiAsync<ApiHistoryResponseModel>($"https://api.coincap.io/v2/assets/{name}/history", new Dictionary<string, string>() { { "interval", time } });
            foreach (var item in response.Data)
            {
                chartEntries.Add(
                    new ChartEntry(item.PriceUsdD)
                    {
                        Label="",
                        ValueLabel = item.priceUsd,
                        Color = SKColor.Parse("#f2f2f2")
                    }
                );
            }
            chart.Chart = new LineChart { Entries = chartEntries, LineMode = LineMode.Straight, PointMode = PointMode.None, BackgroundColor = SKColor.Parse("#404040"), LabelTextSize=0 };
        }

        async void OnGoBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}