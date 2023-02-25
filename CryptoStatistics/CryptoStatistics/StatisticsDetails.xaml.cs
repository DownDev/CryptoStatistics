using CryptoStatistics.Models;
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
		public StatisticsDetails (CryptoCurrencyData data)
		{
			InitializeComponent ();
			test.Text = data.Name;
		}
	}
}