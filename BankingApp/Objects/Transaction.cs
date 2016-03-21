using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Newtonsoft.Json;

namespace BankingApp.Objects
{
    class Transaction
    {
        public DateTime Date { get; set; }
        public TransactionType Type { get; set; }
        public string Description { get; set; }
        public Decimal Amount { get; set; }
        public Decimal BalanceAtTransaction { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }

        [JsonIgnore]
        public BitmapImage TransactionImage => _parseTransactionImage();


        private BitmapImage _parseTransactionImage()
        {
            var cult = new CultureInfo("en-GB");
            string[] keys = {"steam", "paypal"};
            var sKeyResult = keys.FirstOrDefault(s => cult.CompareInfo.IndexOf(Description, s, CompareOptions.IgnoreCase) >= 0);
            var uri = "";
            switch (sKeyResult) 
            {
                case "steam":
                    uri = "Resources/TransactionImages/steam.png";
                    break;
                case "paypal":
                    uri = "Resources/TransactionImages/paypal.png";
                    break;
                default:
                    uri = "Resources/TransactionImages/default.png";
                    break;
            }

            return new BitmapImage(new Uri(uri, UriKind.Relative));
        }


    }
}
