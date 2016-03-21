using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingApp.Objects;
using BankingApp.Helpers;
using Newtonsoft.Json;

namespace BankingApp.Managers
{
    static class AccountManager
    {
        public static List<BankAccount> BankAccounts { get; private set; }

        static AccountManager()
        {
            BankAccounts = new List<BankAccount>();
        }

        public static void LoadData()
        {
            ConsoleHelper.WriteLine("TODO: IMPLEMENT LOADING OF EXISTING ACCOUNTS, POSSIBLY IN WORKSPACES?",ConsoleColor.Cyan);
            BankAccounts.Clear();
        }

        public static void SaveData()
        {
            ConsoleHelper.WriteLine("Saving accounts.json, TODO: WORKSPACES?", ConsoleColor.Yellow);

            using (var fs = File.Open(@"Data/accounts.json", FileMode.OpenOrCreate))
            {
                using (var sw = new StreamWriter(fs))
                {
                    using (JsonWriter jw = new JsonTextWriter(sw))
                    {
                        jw.Formatting = Formatting.Indented;

                        var serializer = new JsonSerializer();
                        serializer.Serialize(jw, BankAccounts);
                    }
                }
            }
        }


    }
}
