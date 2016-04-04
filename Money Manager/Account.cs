using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.Data.Json;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Windows.UI.Xaml;
using Windows.Storage;
using System.Diagnostics;

namespace Money_Manager
{
    [DataContract]
    class Account
    {
        [DataMember(Name = "firstName")]
        public string firstName        { get; set; }
        [DataMember(Name = "lastName")]
        public string lastName         { get; set; }
        [DataMember(Name = "username")]
        public string username         { get; set; } // username = save file name
        [DataMember(Name = "password")]
        public string password         { get; set; }
        [DataMember(Name = "currency")]
        public string currency         { get; set; }
        [DataMember(Name = "balance")]
        public double balance          { get; set; }
        [DataMember(Name = "reserved")]
        public double reservedBalance  { get; set; }

        private static Account account;

        private Account() { }

        public static Account GetAccount
        {
            get
            {
                if (account == null)
                {
                    account = new Account();
                }
                return account;
            }
        }

        public void SetAccount(Account currentAccount)
        {
            GetAccount.firstName        = currentAccount.firstName;
            GetAccount.lastName         = currentAccount.lastName;
            GetAccount.username         = currentAccount.username;
            GetAccount.password         = currentAccount.password;
            GetAccount.currency         = currentAccount.currency;
            GetAccount.balance          = currentAccount.balance;
            GetAccount.reservedBalance  = currentAccount.reservedBalance;
        }

        public string balanceToString()
        {
            string strBalance = Convert.ToString(balance);
            return strBalance;
        }

        public string reservedToString()
        {
            string strBalance = Convert.ToString(reservedBalance);
            return strBalance;
        }

        public string fullBalanceToString()
        {
            double fullBalance = balance + reservedBalance;
            string strBalance = Convert.ToString(fullBalance);
            return strBalance;
        }




        // save
        public async Task write()
            {
            // make file name
            string fileName = username + ".json";

            try
            {
                // get the storage file
                var localFolder = ApplicationData.Current.LocalFolder;
                var storageFile = await localFolder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);

                // get the stream and serializer
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Account));

                Stream stream = await storageFile.OpenStreamForWriteAsync();
                stream.Seek(0, SeekOrigin.Begin);
                serializer.WriteObject(stream, this);

                stream.Dispose();
            }
            catch (FileNotFoundException)
            {
                Debug.WriteLine("filenotfoundexception save");
            }
            catch (IOException e)
            {
                Debug.WriteLine(e.ToString());
            }

        }
        // load
        public async Task load(string file)
        {
            // make file name
            string fileName = file + ".json";

            // make a account object
            Account currentAccount = GetAccount;
            try
            {
                // get the storage file
                var localFolder = ApplicationData.Current.LocalFolder;
                var storageFile = await localFolder.GetFileAsync(fileName);

                // get the file stream and serializer

                FileStream fileStream = new FileStream(storageFile.Path, FileMode.Open);
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Account));

                // read the serialized account object frorm the serializer and filestream
                currentAccount = (Account)serializer.ReadObject(fileStream);
                SetAccount(currentAccount);
                Debug.WriteLine("firstname: " + currentAccount.firstName + ", lastname: " + currentAccount.lastName + ", password: " + currentAccount.password);

                fileStream.Dispose();
            }
            catch(FileNotFoundException)
            {
                Debug.WriteLine("filenotfoundexception load");
            }
            catch(IOException)
            {
                Debug.WriteLine("ioexception");
            }
            
        }

        //add money
        public void addMoney(double moneyIn)
        {
            balance += moneyIn;
        }
        //subtract money
        public async void subtractMoney(double moneyOut)
        {
            if (balance >= moneyOut)
            {
                balance -= moneyOut;
            }
            else
            {
                var dialog = new MessageDialog("Error: Insufficient Funds");
                await dialog.ShowAsync();
            }
        }
        // reserve money
        public async void addReserve(double moneyIn)
        {
            if (balance >= moneyIn)
            {
                reservedBalance += moneyIn;
                balance -= moneyIn;
            }
            else
            {
                var dialog = new MessageDialog("Error: Insufficient Funds");
                await dialog.ShowAsync();
            }
        }
        // unreserve money
        public async void subtractReserve(double moneyOut)
        {
            if(reservedBalance >= moneyOut)
            {
                reservedBalance -= moneyOut;
                balance += moneyOut;
            }
            else
            {
                var dialog = new MessageDialog("Error: Insufficient Funds");
                await dialog.ShowAsync();
            }
        }
    }
}
