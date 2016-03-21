using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Newtonsoft.Json;

namespace BankingApp.Objects
{
    class BankAccount
    {
        /// <summary>
        /// Name of Bank Account
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Type of Bank
        /// </summary>
        public BankType Bank { get; set; }
        
        /// <summary>
        /// Collection of Statements
        /// </summary>
        public List<Statement> Statements { get; set; }

        /// <summary>
        /// The Banks Logo.
        /// </summary>
        [JsonIgnore]
        public BitmapImage BankLogo => _parseBankLogo();

        [JsonIgnore]
        public string BankColour => _parseBankColour();


        /// <summary>
        /// Used to generate a new bank account without any transactions
        /// </summary>
        /// <param name="name">Name of the account</param>
        /// <param name="bank">The BankType</param>
        public BankAccount(string name, BankType bank)
        {
            Name = name;
            Bank = bank;
            Statements = new List<Statement>();
        }

        

        /// <summary>
        /// Gets the relative image depending on the bank.
        /// </summary>
        /// <returns>BitMapImage of the Bank</returns>
        private BitmapImage _parseBankLogo()
        {
            string uri;

            switch (Bank)
            {
                case BankType.Natwest:
                    uri = "Resources/BankImages/natwest.png";
                    break;
                default:
                    uri = "Resources/BankImages/default.png";
                    break;
            }

            return new BitmapImage(new Uri(uri, UriKind.Relative));
        }

        /// <summary>
        /// Gets the 
        /// </summary>
        /// <returns>RGBA hex code Of the bank</returns>
        private string _parseBankColour()
        {
            string hex;
            switch (Bank)
            {
                case BankType.Natwest:
                    hex = "#521D6E"; 
                    break;

                case BankType.Unknown:
                default:
                    hex = "#000000";
                    break;

            }
            
            return hex;
        }

    }
}
