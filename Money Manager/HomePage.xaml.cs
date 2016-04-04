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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Money_Manager
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            this.InitializeComponent();
        }

        private int type = 0;
        public string currency = App.currency;
        public string firstName = GetAccount.firstName;
        public string balance = GetAccount.balanceToString();
        public string reservedBalance = GetAccount.reservedToString();
        public string fullBalance = GetAccount.fullBalanceToString();

        private void btnAddFunds_Click(object sender, RoutedEventArgs e)
        {
            type = 1;
        }

        private void btnSubtractFunds_Click(object sender, RoutedEventArgs e)
        {
            type = 2;
        }

        private void btnAddReserve_Click(object sender, RoutedEventArgs e)
        {
            type = 3;
        }

        private void btnSubtractReserve_Click(object sender, RoutedEventArgs e)
        {
            type = 4;
        }

        // flyout method

        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            double amount = 0.00;

            try
            {
                switch (type)
                {
                    case 1:
                        amount = Convert.ToDouble(tbFundsToAdd.Text);
                        GetAccount.addMoney(amount);
                        amount = 0;
                        flbAmountGetter.Hide();
                        break;
                    case 2:
                        amount = Convert.ToDouble(tbFundsToAdd.Text);
                        GetAccount.subtractMoney(amount);
                        amount = 0;
                        flbAmountGetter.Hide();
                        break;
                    case 3:
                        amount = Convert.ToDouble(tbFundsToAdd.Text);
                        GetAccount.addReserve(amount);
                        amount = 0;
                        flbAmountGetter.Hide();
                        break;
                    case 4:
                        amount = Convert.ToDouble(tbFundsToAdd.Text);
                        GetAccount.subtractReserve(amount);
                        amount = 0;
                        flbAmountGetter.Hide();
                        break;
                }
            }
            catch(FormatException)
            {
                var dialog = new MessageDialog("Only numbers in amount box.", "Input Error");
                await dialog.ShowAsync();
            }
            
            Frame.Navigate(typeof(HomePage));
        }

        private async void btnExit_Click(object sender, RoutedEventArgs e)
        {
            await GetAccount.write();
            Application.Current.Exit();
        }
    }
}
