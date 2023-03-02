using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CryptoStatistics.Models
{
    public class ApiHistoryResponseModel
    {
        public List<CryptoCurrencyHistoryData> Data { get; set; }
        public long Timestamp { get; set; }
    }
    public class CryptoCurrencyHistoryData
    {
        public string priceUsd { get; set; }
        public double time { get; set; }
        public string date { get; set; }


        public float PriceUsdD => float.Parse(priceUsd, CultureInfo.InvariantCulture);

        public string PriceUsdFormatted => $"${PriceUsdD.ToString("N2")}";
    }
}
