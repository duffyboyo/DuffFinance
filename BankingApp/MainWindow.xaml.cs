using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using MahApps.Metro.Controls;
using BankingApp.Helpers;
using BankingApp.Objects;

namespace BankingApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            BankAccount b = new BankAccount("Current Account",BankType.Natwest);
            imgDebugBank.Source = b.BankLogo;

            NatwestStatement statement = new NatwestStatement("First Statment");
            statement.ParseStatement("TESTSTATEMENT.csv");
            b.Statements.Add(statement);

            Managers.AccountManager.BankAccounts.Add(b);

            Managers.AccountManager.SaveData();


            Transaction t = new Transaction();
            t.Description = "STEAM";
            imgDebugTransaction.Source = t.TransactionImage;

        }

        private void MiOpen_OnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            ConsoleHelper.WriteLine("TODO: IMPLEMENT LOADING CSV", ConsoleColor.Cyan);
        }

        private void MiClose_OnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            ConsoleHelper.WriteLine("TODO: IMPLEMENT CLOSING CURRENT CSV", ConsoleColor.Cyan);

        }

        private void MiSave_OnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            ConsoleHelper.WriteLine("TODO: IMPLEMENT SAVING DATA", ConsoleColor.Cyan);

        }
    }
}
