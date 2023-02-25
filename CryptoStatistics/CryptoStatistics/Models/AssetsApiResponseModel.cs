using System;
using System.Collections.Generic;
using System.Globalization;
using Xamarin.Forms;

namespace CryptoStatistics.Models
{
    public class AssetsApiResponseModel
    {
        public List<CryptoCurrencyData> Data { get; set; }
        public long Timestamp { get; set; }
    }
    public class CryptoCurrencyData
    {
        public string Id { get; set; }
        public string Rank { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string Supply { get; set; }
        public string MaxSupply { get; set; }
        public string MarketCapUsd { get; set; }
        public string VolumeUsd24Hr { get; set; }
        public string PriceUsd { get; set; }
        public string ChangePercent24Hr { get; set; }
        public string Vwap24Hr { get; set; }
        public string Explorer { get; set; }

        public string SymbolLower => Symbol.ToLower();

        public Color PercentColor => ChangePercent24HrD >= 0 ? Color.LightGreen : Color.Red;

        public double SupplyD => double.Parse(Supply, CultureInfo.InvariantCulture);
        public double MaxSupplyD => double.Parse(MaxSupply, CultureInfo.InvariantCulture);
        public double MarketCapUsdD => double.Parse(MarketCapUsd, CultureInfo.InvariantCulture);
        public double VolumeUsd24HrD => double.Parse(VolumeUsd24Hr, CultureInfo.InvariantCulture);
        public double PriceUsdD => double.Parse(PriceUsd, CultureInfo.InvariantCulture);
        public double ChangePercent24HrD => double.Parse(ChangePercent24Hr, CultureInfo.InvariantCulture);
        public double Vwap24HrD => double.Parse(Vwap24Hr, CultureInfo.InvariantCulture);

        public string PriceUsdFormatted => $"${PriceUsdD.ToString("N2")}";
    }
}
