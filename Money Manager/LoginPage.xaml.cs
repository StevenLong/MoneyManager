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
using System.Diagnostics;
using static Money_Manager.Account;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Money_Manager
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            this.InitializeComponent();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private async void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            if (tbUserName.Text == "")
            {
                var dialog = new MessageDialog("No User Name Entered");
                await dialog.ShowAsync();
            }
            else if (tbPassword.Password == "")
            {
                var dialog = new MessageDialog("No Password Entered");
                await dialog.ShowAsync();
            }
            else
            {
                // create and populate account
                App.currentStorageFileName = tbUserName.Text + ".json";
                await GetAccount.load(tbUserName.Text);
                // check if password is valid
                //Debug.Write("GetAccount.password (currently nothing): " + GetAccount.password + "\ntbPassword.Text: " + tbPassword.Password);

                try
                {
                    if (GetAccount.password == null)
                    {
                        var dialog = new MessageDialog("Please try again", "Incorrect username");
                        await dialog.ShowAsync();
                    }
                    else if (GetAccount.password.Equals(tbPassword.Password))
                    {
                        Frame.Navigate(typeof(HomePage));
                    }
                    else
                    {
                        var dialog = new MessageDialog("Please try again", "Incorrect password");
                        await dialog.ShowAsync();
                    }
                }
                catch(NullReferenceException nre)
                {
                    Debug.WriteLine("nullreferenceexception");
                    Debug.WriteLine(nre);
                }
                

            }
        }

        private void btnNewAccount_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(NewAccountPage));
        }

    }
}
