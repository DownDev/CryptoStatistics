using CryptoStatistics.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoStatistics.Data
{
    public class CryptoData
    {
        readonly SQLiteAsyncConnection database;

        public CryptoData(string databasePath)
        {
            database = new SQLiteAsyncConnection(databasePath);
            database.CreateTableAsync<CryptoCurrency>().Wait();
        }

        public async Task<List<CryptoCurrency>> GetCryptoCurrencies()
        {
            var cryptoCurrency = await database.Table<CryptoCurrency>().ToListAsync();

            return cryptoCurrency;
        }

        public async Task<List<CryptoCurrency>> AddElement(CryptoCurrencyData data)
        {
            var cryptoCurrencies = await GetCryptoCurrencies();
            if (cryptoCurrencies.Count()<3)
            {
                var resultData = new CryptoCurrency()
                {
                    Name = data.Id,
                    TimeStamp = DateTime.UtcNow.ToString()
                };
                await database.InsertAsync(resultData);
            }
            return await GetCryptoCurrencies();
        }

        public async Task<List<CryptoCurrency>> DeleteElement(string Name)
        {
            var elements = await GetCryptoCurrencies();
            var elementToDelete = elements.FirstOrDefault(n=>n.Name == Name);
            await database.DeleteAsync(elementToDelete);

            return await GetCryptoCurrencies();
        }
    }
}
