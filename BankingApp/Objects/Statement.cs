using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using BankingApp.Helpers;

namespace BankingApp.Objects
{
    class Statement
    {
        public string Name { get; set; }

        public List<Transaction> Transactions { get; set; }

        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Create a new statement without any existing transactions
        /// </summary>
        /// <param name="name">The name of this statement</param>
        /// <param name="bankAccount">The bankaccount associated with this statement</param>
        public Statement(string name)
        {
            this.Name = name;
            Transactions = new List<Transaction>();
            DateCreated = DateTime.Now;
        } 


        /// <summary>
        /// Parses the statement and fills the Transactions
        /// </summary>
        /// <param name="filePath"></param>
        public virtual void ParseStatement(string filePath)
        {
            ConsoleHelper.WriteLine("Begining to parse " + filePath,ConsoleColor.Green);

            if (!File.Exists(filePath))
            {
                ConsoleHelper.WriteLine("Statement " + filePath + " Not Found", ConsoleColor.Red);
                return;
            }
        }

    }
}
