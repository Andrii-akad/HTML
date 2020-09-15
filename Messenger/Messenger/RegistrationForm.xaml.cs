using Messenger.ServiceReference1;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
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
    /// Логика взаимодействия для RegistrationForm.xaml
    /// </summary>
    public partial class RegistrationForm : Window
    {
        public Image Image { get; set; }
        MessengerClient client = new MessengerClient();
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Owner.Left = Left;
            Owner.Top = Top;
            Owner.Show();
            this.Hide();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (sender as TextBox);
            if (textBox.Text.Length == 0)
                textBox.Foreground = Brushes.Red;
            else
                textBox.Foreground = Brushes.MintCream;
        }

        private void FloatingConfirmBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = (sender as PasswordBox);
            if (passwordBox.Password.Length == 0)
                passwordBox.Foreground = Brushes.Red;
            else
                passwordBox.Foreground = Brushes.MintCream;
        }

        private void Registrate_Click(object sender, RoutedEventArgs e)
        {
            bool isOk = true;
            foreach (var item in panel.Children)
            {
                if (item is TextBox)
                {
                    TextBox_TextChanged(item, null);
                    if ((item as TextBox).Foreground == Brushes.Red)
                        isOk = false;
                }
                else if (item is PasswordBox)
                {
                    FloatingConfirmBox_PasswordChanged(item, null);
                    if ((item as PasswordBox).Foreground == Brushes.Red)
                        isOk = false;
                }
            }
            if (imgdata == null)
            {
                isOk = false;
                btnImage.Foreground = Brushes.Red;
            }
            else
                btnImage.Foreground = Brushes.White;
            if (!client.IsLoginUnique(tbLogin.Text))
            {
                isOk = false;
                tbLogin.Foreground = Brushes.Red;
                MaterialDesignThemes.Wpf.HintAssist.SetHelperText(tbLogin, "This login already exist");
            }
            if (!tbPassword.Password.Equals(tbPassword2.Password))
            {
                isOk = false;
                tbPassword2.Password = "";
                tbPassword2.Foreground = Brushes.Red;
                MaterialDesignThemes.Wpf.HintAssist.SetHelperText(tbPassword2, "Password mismatch");
            }
            if (isOk)
            {
                EmailVerifyForm verifyForm = new EmailVerifyForm()
                {
                    Account = new AccountDTO
                    {
                        Email = tbEmail.Text,
                        Login = tbLogin.Text,
                        Password = tbPassword.Password,
                        Name = tbName.Text,
                        Image = imgdata
                    },
                    TbEmail = tbEmail.Text,
                    Owner = this
                };
                verifyForm.Show();
                this.Hide();
            }

        }
        byte[] imgdata = null;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Jpg|*.jpg|Png|*.png|Jpeg|*.jpeg";
            fileDialog.ShowDialog();

            imgdata = File.ReadAllBytes(fileDialog.FileName);
            image.ImageSource = new { Image = new BitmapImage(new Uri(fileDialog.FileName)) }.Image;
        }
    }
}
