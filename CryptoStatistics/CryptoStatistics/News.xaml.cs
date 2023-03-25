using System;
using System.Collections.Generic;
using System.Linq;
using CryptoStatistics.Models;
using CryptoStatistics.Services;
using Xamarin.Forms;

namespace CryptoStatistics
{	
	public partial class News : ContentPage
	{
		private List<Post> ApiData;
		public News()
		{
			InitializeComponent();
			GetNews();
		}

		private async void GetNews()
		{
			var result = await ApiService.GetDataFromApiAsync<NewsDataModel>("https://newsdata.io/api/1/news", new Dictionary<string, string> { { "apikey", "pub_183905a322fff00caadd3e6acebb7cec2c803" }, { "language", "pl,en" }, { "q", "bitcoin" } });
			ApiData = result.results.ToList();
			NewsListView.ItemsSource = ApiData;
        }

        async void OnNewsTapped(object sender, ItemTappedEventArgs e)
        {
			var data = e.Item as Post;
			await Navigation.PushModalAsync(new NewsDetails(data));
        }

        private void NewsRefresh(object sender, EventArgs e)
        {
			GetNews();
            NewsListView.EndRefresh();
        }
    }
}

