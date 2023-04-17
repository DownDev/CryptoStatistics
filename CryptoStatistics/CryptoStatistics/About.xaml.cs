using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
namespace CryptoStatistics
{	
	public partial class About : ContentPage
	{
		public Command TapCommand => new Command<string>(async (url) => await Browser.OpenAsync(url, BrowserLaunchMode.SystemPreferred));
        public About()
		{
			InitializeComponent();
			BindingContext = this;
		}
	}
}

