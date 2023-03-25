using System;
using System.Collections.Generic;
using CryptoStatistics.Models;
using Xamarin.Forms;

namespace CryptoStatistics
{	
	public partial class NewsDetails : ContentPage
	{	
		public NewsDetails(Post news)
		{
			InitializeComponent();
			BindingContext = news;
		}

        async void OnGoBackClicked(object sender, EventArgs e)
        {
			await Navigation.PopModalAsync();
        }
    }
}

