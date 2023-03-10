using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoStatistics.Models
{
    public class CryptoCurrency
    {
        [PrimaryKey, AutoIncrement] 
        public int Id { get; set; }
        public string Name { get; set; }

        public string TimeStamp { get; set; }
    }
}
