using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingApp.Helpers;
using System.IO;
using CsvHelper;

namespace BankingApp.Objects
{
    class NatwestStatement : Statement
    {
        public NatwestStatement(string name) : base(name)
        {
            ConsoleHelper.WriteLine("Creating New NatwestStatement",ConsoleColor.Green);
        }

        public override void ParseStatement(string filePath)
        {
            base.ParseStatement(filePath);
            ConsoleHelper.WriteLine("PARSING NATWEST STATEMENT @ " + filePath, ConsoleColor.DarkCyan);

            using (StreamReader sr = File.OpenText(filePath))
            {
                var csv = new CsvReader(sr);
                var transactions = new List<Transaction>();


                while (csv.Read())
                {
                    var transaction = new Transaction();


                    var Date = csv.GetField<DateTime>(0);
                    var Type = csv.GetField<string>(1);
                    var Description = csv.GetField<string>(2);
                    var Value = csv.GetField<Decimal>(3);
                    var Balance = csv.GetField<Decimal>(4);
                    var AccountName = csv.GetField<string>(5);
                    var AccountNumber = csv.GetField<string>(6);

                    Description = Description.Trim('\'');
                    AccountName = AccountName.Trim('\'');
                    AccountNumber = AccountNumber.Trim('\'');




                    transaction.Date = Date;

                    switch (Type)
                    {
                        case "BAC":
                            transaction.Type = TransactionType.BAC;
                            break;
                        case "POS":
                            transaction.Type = TransactionType.POS;
                            break;
                        case "D/D":
                            transaction.Type = TransactionType.DdD;
                            break;
                        case "DPC":
                            transaction.Type = TransactionType.DPC;
                            break;
                        default:
                            transaction.Type = TransactionType.Unknown;
                            break;
                    }

                    transaction.Description = Description;

                    transaction.Amount = Value;

                    transaction.BalanceAtTransaction = Balance;

                    transaction.AccountName = AccountName;

                    transaction.AccountNumber = AccountNumber;


                    transactions.Add(transaction);

                }

                base.Transactions = transactions;

                //foreach (var transaction in transactions)
                //{
                //    var output = String.Format("{0} : {1} : {2} : {3} ", transaction.Date, transaction.Description, transaction.Amount, transaction.AccountNumber);
                //    ConsoleHelper.WriteLine(output, ConsoleColor.Green);
                //}

            }
        }
    }
}
