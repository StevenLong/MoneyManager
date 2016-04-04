using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using static Money_Manager.Account;

namespace Money_Manager
{

    public sealed partial class NewAccountPage : Page
    {

        double fullStartingBalance;

        public NewAccountPage()
        {
            this.InitializeComponent();
        }

        private async void btnDone_Click(object sender, RoutedEventArgs e)
        {
            bool valid = await validateInfo();

            if (valid)
            {
                GetAccount.firstName = tbFirstName.Text;
                GetAccount.lastName = tbLastName.Text;
                GetAccount.username = tbUserName.Text;
                GetAccount.password = tbPassword.Password;
                GetAccount.currency = App.currency;
                GetAccount.balance = Convert.ToDouble(tbStartingBalance.Text);
                //currentUser.toConsole(); // Shows dialog with json for debugging only

                await GetAccount.write();

                Frame.Navigate(typeof(HomePage));
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(LoginPage));
        }

        private async System.Threading.Tasks.Task<bool> validateInfo()
        {
            bool firstAndLastNameGood;
            bool usernameGood;
            bool passwordGood;
            bool currencyGood;
            bool startingBalanceGood;
            //first name last name
            if (tbFirstName.Text != "" && tbLastName.Text != "")
            {
                firstAndLastNameGood = true;
            }
            else
            {
                firstAndLastNameGood = false;
            }
            //username
            if (tbUserName.Text.Length >= 5 && !tbUserName.Text.Contains(' '))
            {
                usernameGood = true;
            }
            else
            {
                usernameGood = false;
            }
            //password x2
            if (tbPassword.Password.Length >= 5 && tbPassword.Password.CompareTo(tbPasswordRetype.Password) == 0)
            {
                passwordGood = true;
            }
            else
            {
                passwordGood = false;
            }
            //currency
            if (App.currency.Equals(null))
            {
                currencyGood = false;
            }
            else
            {
                currencyGood = true;
            }
            // starting balance
            // combining large and small currency
            try
            {
                double bigBalance;
                double littleBalance;
                bigBalance = Convert.ToDouble(tbStartingBalance.Text);
                if (tbStartingBalanceSmall.Text.Length <= 2)
                {
                    littleBalance = Convert.ToDouble(tbStartingBalanceSmall.Text);
                    littleBalance /= 100;
                    fullStartingBalance = bigBalance + littleBalance;
                    startingBalanceGood = true;
                }
                else
                {
                    startingBalanceGood = false;
                }

            }
            catch
            {
                var dialog = new MessageDialog("Error: Invalid Input");
                await dialog.ShowAsync();
                startingBalanceGood = false;
            }

            if (firstAndLastNameGood && usernameGood && passwordGood && currencyGood && startingBalanceGood)
            {
                return true;
            }
            else
            {
                var dialog = new MessageDialog("Error: Invalid Input");
                await dialog.ShowAsync();
                return false;
            }
        }

        private void rbEuro_Checked(object sender, RoutedEventArgs e)
        {
            App.currency = "€";
        }

        private void rbDollar_Checked(object sender, RoutedEventArgs e)
        {
            App.currency = "$";
        }

        private void rbPound_Checked(object sender, RoutedEventArgs e)
        {
            App.currency = "£";
        }
    }
}
