using Messenger.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
    /// Логика взаимодействия для EmailVerifyForm.xaml
    /// </summary>
    public partial class EmailVerifyForm : Window
    {
        public AccountDTO Account { get; set; }
        public string TbEmail { get; set; }
        public string VerifyCode { get; set; }

        public string GetRandomCode()
        {
            Random rand = new Random();
            string code = "";
            int codeSize = 8;
            for (int i = 0; i < codeSize; i++)
            {
                char ch;
                do
                {
                    ch = (char)rand.Next('0', 'z');
                }
                while (!((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z') || (ch >= '0' && ch <= '9')));
                code += ch;
            }
            return code;
        }
        public void SendVerifyCode()
        {
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("drocsid.no.reply@gmail.com", "drocsid2020");

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("drocsid.no.reply@gmail.com");
            mail.To.Add(tbMail.Text);

            mail.Subject = "Drocsid verify code";
            VerifyCode = GetRandomCode();
            mail.Body = VerifyCode;

            client.Send(mail);
        }
        public EmailVerifyForm()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            //if (VerifyCode == tbCode.Text)
            //{
            Account.Email = tbMail.Text;
            new Task(() => Login()).Start();
            //}
            //else
                //tbCode.Foreground = Brushes.Red;
        }

        public void Login()
        {
            MessengerClient messengerClient = new MessengerClient();
            string login = "", password = "", email = " ", name = "";
            byte[] img = null;
            Dispatcher.Invoke(() =>
            {
                password = Account.Password;
                login = Account.Login;
                email = Account.Email;
                name = Account.Name;
                img = Account.Image;
            });
            messengerClient.Registrate(email, login, password, name, img);

            AccountDTO account = messengerClient.Login(login, password);
            MainWindow mainWindow = null;
            Dispatcher.Invoke(() => mainWindow = new MainWindow(account));
            Dispatcher.Invoke(() => mainWindow.Show());
            this.Hide();
        }

        private void Again_Click(object sender, RoutedEventArgs e)
        {
            if (tbMail.Text == "")
            {
                tbMail.Foreground = Brushes.Red;
            }
            else
                SendVerifyCode();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tbMail.Text = TbEmail;
            SendVerifyCode();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Owner.Show();
            this.Close();
        }
    }
}
