using Messenger.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Messenger
{
    /// <summary>
    /// Логика взаимодействия для LoginForm.xaml
    /// </summary>
    public partial class LoginForm : Window
    {
        bool isCreate = false;
        RegistrationForm form;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            if (isCreate)
            {
                form.Left = Left;
                form.Top = Top;
                form.Show();
                this.Hide();
            }
            else
            {
                isCreate = true;
                form = new RegistrationForm() { Owner = this };
                form.Left = Left;
                form.Top = Top;
                form.Show();
                this.Hide();
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            //MainWind.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Child = new RegistrationForm() { Father = this };
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (sender as TextBox);
            if (textBox.Text.Length == 0)
                textBox.Foreground = Brushes.Red;
            else
                textBox.Foreground = Brushes.MintCream;
        }

        private void FloatingPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = (sender as PasswordBox);
            if (passwordBox.Password.Length == 0)
                passwordBox.Foreground = Brushes.Red;
            else
                passwordBox.Foreground = Brushes.MintCream;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new Task(() => Login()).Start();
        }
        DispatcherTimer timer = new DispatcherTimer();

        public void Loading()
        {
            Dispatcher.Invoke(() =>
            {
                pnlLoading.Visibility = Visibility.Visible;
                tbLoading.Visibility = Visibility.Visible;
            });
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            timer.Start();
        }
        float h = 0;
        private void Timer_Tick(object sender, EventArgs e)
        {
            h++;
            if (loadingTime >= 5)
            {
                loadingTime = 0;
                LoginForm newForm = new LoginForm();
                newForm.tbLogin.Text = tbLogin.Text;
                newForm.tbPassword.Password = tbPassword.Password;
                newForm.Button_Click(null, null);
                newForm.Show();
                Dispatcher.Invoke(() => this.Close());
            }
            if (h % 80 == 0)
            {
                if (tbLoading.Text.Length < 10)
                    tbLoading.Text += ".";
                else
                    tbLoading.Text = tbLoading.Text.Remove(7);
            }
            if (h >= 360)
            {
                h = 0;
                loadingTime++;
            }
            tbLoading.Foreground = new SolidColorBrush(ColorChange(h, 1f, 1f));
        }
        int loadingTime = 0;
        public Color ColorChange(float h, float s, float v)
        {

            int i;
            float f, p, q, t;

            if (s < float.Epsilon)
            {
                int c = (int)(v * 255);
                return Color.FromRgb((byte)c, (byte)c, (byte)c);
            }

            h /= 60;
            i = (int)Math.Floor(h);
            f = h - i;
            p = v * (1 - s);
            q = v * (1 - s * f);
            t = v * (1 - s * (1 - f));

            float r, g, b;
            switch (i)
            {
                case 0: r = v; g = t; b = p; break;
                case 1: r = q; g = v; b = p; break;
                case 2: r = p; g = v; b = t; break;
                case 3: r = p; g = q; b = v; break;
                case 4: r = t; g = p; b = v; break;
                default: r = v; g = p; b = q; break;
            }

            return Color.FromRgb((byte)(r * 255), (byte)(g * 255), (byte)(b * 255));
        }


        public void Login()
        {
            new Task(() => Loading()).Start();
            MessengerClient messengerClient = new MessengerClient();
            string login = "", password = "";
            Dispatcher.Invoke(() => password = tbPassword.Password);
            Dispatcher.Invoke(() => login = tbLogin.Text);
            AccountDTO account = messengerClient.Login(login, password);
            if (account != null)
            {
                MainWindow mainWindow = null;
                Dispatcher.Invoke(() => mainWindow = new MainWindow(account));
                Dispatcher.Invoke(() => mainWindow.Show());
            }
            else
            {
                Dispatcher.Invoke(() =>
                {
                    tbPassword.Password = "";
                    tbPassword.Foreground = Brushes.Red;
                    MaterialDesignThemes.Wpf.HintAssist.SetHelperText(tbPassword, "Incorrect login or password");
                });
            }
            timer.Stop();
            Dispatcher.Invoke(() =>
            {
                pnlLoading.Visibility = Visibility.Hidden;
                tbLoading.Visibility = Visibility.Hidden;
                // this.Hide();
            });
        }
    }
}

