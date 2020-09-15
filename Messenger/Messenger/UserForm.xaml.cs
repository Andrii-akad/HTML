using Messenger.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Messenger
{
    /// <summary>
    /// Логика взаимодействия для UserForm.xaml
    /// </summary>
    public partial class UserForm : Window
    {
        MessengerClient messengerClient = new MessengerClient();
        public AccountDTO Contact { get; set; }
        public AccountDTO MainAccount { get; set; }
        public MainWindow WindowOwner { get; set; }
        public UserForm(AccountDTO account, AccountDTO owner, MainWindow window)
        {
            InitializeComponent();
            WindowOwner = window;
            Contact = account;
            MainAccount = owner;

            if (messengerClient.IsContactAlreadyExist(MainAccount, Contact))
                btnAdd.IsEnabled = false;
            else
                btnDelete.IsEnabled = false;

            pnlImg.DataContext = account;
            pnlInfo.DataContext = account;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddContact_Click(object sender, RoutedEventArgs e)
        {
            if (!messengerClient.IsContactAlreadyExist(MainAccount, Contact))
            {
                messengerClient.AddContact(MainAccount, Contact);
                WindowOwner.FillContacts(MainAccount);
                btnDelete.IsEnabled = true;
                btnAdd.IsEnabled = false;
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void DeleteContact_Click(object sender, RoutedEventArgs e)
        {
            if (messengerClient.IsContactAlreadyExist(MainAccount, Contact))
            {
                messengerClient.DeleteContact(MainAccount, Contact);
                WindowOwner.FillContacts(MainAccount);
                btnDelete.IsEnabled = false;
                btnAdd.IsEnabled = true;
            }
        }
    }
}
