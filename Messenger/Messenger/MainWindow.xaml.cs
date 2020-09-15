using MaterialDesignThemes.Wpf;
using Messenger.ServiceReference1;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Messenger
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MessengerClient messengerClient = new MessengerClient();
        MemoryStream ms = new MemoryStream();
        public AccountDTO Account { get; set; }
        public List<StackPanel> DialogPanels { get; set; }
        public Chip Interlocutor { get; set; }
        public bool IsChatsFill = false;
        public void FillContacts(AccountDTO account)
        {
            List<AccountDTO> contacts = null;
            MemoryStream memory = new MemoryStream();
            Dispatcher.Invoke(() =>
            {
                panelContacts.Children.Clear();
                contacts = messengerClient.GetContacts(account).ToList();
            });
            foreach (var item in contacts)
            {
                Chip chip = null;
                Dispatcher.Invoke(() =>
                {
                    chip = new Chip
                    {
                        Background = Brushes.Gray,
                        Foreground = Brushes.White,
                        Content = item.Name,
                        Width = Double.NaN,
                        Height = Double.NaN,
                        Margin = new Thickness(0, 15, 0, 0),
                        Tag = item
                    };
                });
                memory = new MemoryStream(item.Image);
                Dispatcher.Invoke(() =>
                {
                    chip.Icon = new Ellipse
                    {
                        Width = 32,
                        Height = 32,
                        Fill = new ImageBrush
                        {
                            Stretch = Stretch.UniformToFill,
                            ImageSource = BitmapFrame.Create(memory)
                        }
                    };
                    chip.IsDeletable = true;
                    chip.Click += Chip_Click;
                    chip.DeleteClick += Contact_DeleteClick;
                    panelContacts.Children.Add(chip);
                });
            }
        }

        private void Chip_Click(object sender, RoutedEventArgs e)
        {
            mainPagePanel.Visibility = Visibility.Collapsed;
            Interlocutor = sender as Chip;
            string partisipants = Account.Id + " " + (Interlocutor.Tag as AccountDTO).Id;
            string partisipantsRes = partisipants.Split().Min() + " " + partisipants.Split().Max();
            chatScroll.ScrollToVerticalOffset(Math.Pow(100, 100));
            chatPanel.Children.Clear();
            foreach (var item in DialogPanels)
            {
                if ((item.Tag as ChatDTO).Participants == partisipantsRes)
                {
                    chatPanel.Children.Add(item);
                    emptyChatPanel.Visibility = Visibility.Collapsed;
                    return;
                }
            }
            chatPanel.Children.Add(emptyChatPanel);
            emptyChatPanel.Visibility = Visibility.Visible;
        }

        public void AddMessage(StackPanel panel, MessageDTO message)
        {
            bool isSelf = false;
            if (Account.Id == message.DeliverId)
                isSelf = true;
            AccountDTO account = messengerClient.GetUserById(message.DeliverId.Value);
            StackPanel messagePanel = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(10) };
            StackPanel panel2 = new StackPanel { VerticalAlignment = VerticalAlignment.Top };
            StackPanel panel3 = new StackPanel { Orientation = Orientation.Horizontal };
            panel3.Children.Add(new TextBlock
            {
                Foreground = Brushes.White,
                Margin = new Thickness(5),
                Text = account.Name
            });
            panel3.Children.Add(new TextBlock
            {
                Foreground = Brushes.Gray,
                Margin = new Thickness(5)
            });

            (panel3.Children[1] as TextBlock).Text = message.Data.ToString().Remove(5, 5).Remove(11);
            StackPanel panel4 = new StackPanel { Margin = new Thickness(5) };
            panel4.Children.Add(new TextBlock
            {
                Foreground = Brushes.LightCyan,
                Width = panel.Width / 2,
                TextWrapping = TextWrapping.Wrap,
                Text = message.Content,
                FontSize = 17
            });
            ms = new MemoryStream(account.Image);
            panel2.Children.Add(panel3);
            panel2.Children.Add(panel4);
            if (!isSelf)
            {
                messagePanel.Children.Add(new Ellipse
                {
                    Height = 70,
                    Width = 70,
                    VerticalAlignment = VerticalAlignment.Top,
                    Fill = new ImageBrush { Stretch = Stretch.UniformToFill, ImageSource = BitmapFrame.Create(ms) }
                });
                messagePanel.Children.Add(panel2);
            }
            else
            {
                messagePanel.HorizontalAlignment = HorizontalAlignment.Right;
                messagePanel.Margin = new Thickness(10, 10, 30, 10);
                panel3.HorizontalAlignment = HorizontalAlignment.Right;
                (panel4.Children[0] as TextBlock).TextAlignment = TextAlignment.Right;
                UIElement temp1 = panel3.Children[0];
                UIElement temp2 = panel3.Children[1];
                panel3.Children.Clear();
                panel3.Children.Add(temp2);
                panel3.Children.Add(temp1);

                messagePanel.Children.Add(panel2);
                messagePanel.Children.Add(new Ellipse
                {
                    Height = 70,
                    Width = 70,
                    VerticalAlignment = VerticalAlignment.Top,
                    Fill = new ImageBrush { Stretch = Stretch.UniformToFill, ImageSource = BitmapFrame.Create(ms) }
                });
            }
            panel.Children.Add(messagePanel);
        }

        public void FillAllChats()
        {
            new Task(() => Loading()).Start();
            MessengerClient msClient = new MessengerClient();
            AccountDTO account = null;
            Dispatcher.Invoke(() => account = Account);
            List<ChatDTO> chats = msClient.GetAllMessagesInChats(account).ToList();
            bool isExist = false;
            List<StackPanel> dialogPanels = new List<StackPanel>();
            foreach (var item in chats)
            {
                foreach (var panel in dialogPanels)
                {
                    ChatDTO chatPanel = null;
                    Dispatcher.Invoke(() => chatPanel = panel.Tag as ChatDTO);
                    if (item.Participants == chatPanel.Participants)
                    {
                        Dispatcher.Invoke(() => AddMessage(panel, msClient.GetMessageById(item.MessageId.Value)));
                        isExist = true;
                        Dispatcher.Invoke(() => panel.Tag = item);
                    }
                }
                if (!isExist)
                {
                    StackPanel panel = null;
                    bool isContact = false;
                    Dispatcher.Invoke(() =>
                    {
                        foreach (Chip ac in panelContacts.Children)
                        {
                            if (item.Participants.Contains((ac.Tag as AccountDTO).Id.ToString()))
                                isContact = true;
                        }
                        AccountDTO acc = messengerClient.GetUserById(messengerClient.GetMessageById(item.MessageId.Value).DeliverId.Value);
                        if (!isContact & acc.Id != Account.Id)
                        {
                            ms = new MemoryStream(acc.Image);
                            listMails.Items.Add(new SearchClass { Img = BitmapFrame.Create(ms), Text = acc.Name, Tag = acc });
                        }
                        panel = new StackPanel { Tag = item, Width = 907 };
                        AddMessage(panel, msClient.GetMessageById(item.MessageId.Value));
                    });
                    dialogPanels.Add(panel);
                }
                isExist = false;
            }
            Dispatcher.Invoke(() =>
            {
                DialogPanels.AddRange(dialogPanels.ToArray());
                for (int i = 0; i < DialogPanels.Count; i++)
                {
                    DialogPanels[i].Tag = dialogPanels[i].Tag as ChatDTO;
                }
                timer.Stop();
                pnlLoading.Visibility = Visibility.Hidden;
                tbLoading.Visibility = Visibility.Hidden;
            });
            IsChatsFill = true;
        }

        public void CheckNewMessages()
        {
            if (IsChatsFill)
            {
                MessengerClient msClient = new MessengerClient();
                bool isExist = false;
                List<ChatDTO> chats = msClient.GetChats(Account).ToList();
                List<StackPanel> dialogPanels = null;
                Dispatcher.Invoke(() => dialogPanels = DialogPanels);

                foreach (var item in chats)
                {
                    foreach (var panel in dialogPanels)
                    {
                        ChatDTO chatPanel = null;
                        Dispatcher.Invoke(() => chatPanel = panel.Tag as ChatDTO);
                        if (item.Participants == chatPanel.Participants)
                        {
                            isExist = true;
                            if (item.MessageId > chatPanel.MessageId)
                            {
                                Dispatcher.Invoke(() =>
                                {
                                    chatPanel.MessageId = item.MessageId;
                                    AddMessage(panel, msClient.GetMessageById(item.MessageId.Value));
                                    chatScroll.ScrollToVerticalOffset(Math.Pow(100, 100));
                                    return;
                                });
                            }
                        }
                    }
                    if (!isExist)
                    {
                        bool isContact = false;
                        Dispatcher.Invoke(() =>
                        {
                            foreach (Chip acc in panelContacts.Children)
                            {
                                if (item.Participants.Contains((acc.Tag as AccountDTO).Id.ToString()))
                                    isContact = true;
                            }
                            AccountDTO account = messengerClient.GetUserById(messengerClient.GetMessageById(item.MessageId.Value).DeliverId.Value);
                            if (!isContact & account.Id != Account.Id)
                            {
                                ms = new MemoryStream(account.Image);
                                listMails.Items.Add(new SearchClass { Img = BitmapFrame.Create(ms), Text = account.Name, Tag = account });
                            }
                            StackPanel panel = new StackPanel { Tag = item, Width = 907 };
                            AddMessage(panel, msClient.GetMessageById(item.MessageId.Value));
                            DialogPanels.Add(panel);
                        });
                    }
                    isExist = false;
                }
            }
        }
        public void RefreshMessages()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(Timer_Click);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void Timer_Click(object sender, EventArgs e)
        {
            new Task(() => CheckNewMessages()).Start();
        }

        public MainWindow(AccountDTO account)
        {
            InitializeComponent();
            DialogPanels = new List<StackPanel>();
            ms = new MemoryStream(account.Image);
            Account = account;
            ((chipUser.Icon as Ellipse).Fill as ImageBrush).ImageSource = BitmapFrame.Create(ms);
            chipUser.Content = account.Name;
            new Task(() => OnLoad(account)).Start();

            RefreshMessages();
        }
        public void OnLoad(AccountDTO acc)
        {
            FillContacts(acc);
            FillAllChats();
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
            h += 2;
            if (h % 40 == 0)
            {
                if (tbLoading.Text.Length < 10)
                    tbLoading.Text += ".";
                else
                    tbLoading.Text = tbLoading.Text.Remove(7);
            }
            if (h >= 360)
            {
                h = 0;
            }
            tbLoading.Foreground = new SolidColorBrush(ColorChange(h, 1f, 1f));
        }
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
        private void Contact_DeleteClick(object sender, RoutedEventArgs e)
        {
            if (messengerClient.IsContactAlreadyExist(Account, (sender as Chip).Tag as AccountDTO))
            {
                messengerClient.DeleteContact(Account, (sender as Chip).Tag as AccountDTO);
                panelContacts.Children.Remove(sender as Chip);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string partisipants = Account.Id + " " + (Interlocutor.Tag as AccountDTO).Id;
            string partisipantsRes = partisipants.Split().Min() + " " + partisipants.Split().Max();
            MessageDTO message = new MessageDTO
            {
                Content = tbMessage.Text,
                DeliverId = Account.Id,
                Data = DateTime.Now
            };
            messengerClient.AddMessage(message.Content, message.Data, message.DeliverId.Value);
            messengerClient.AddChat(partisipantsRes, message, (Interlocutor.Tag as AccountDTO).Name + "&" + Account.Name, null);
            tbMessage.Text = "";
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            listUsers.Items.Clear();
            foreach (var item in messengerClient.GetUsersBySearch(tbSearch.Text))
            {
                ms = new MemoryStream(item.Image);
                listUsers.Items.Add(new SearchClass { Img = BitmapFrame.Create(ms), Text = item.Name, Tag = item });
            }
        }
        public class SearchClass
        {
            public ImageSource Img { get; set; }
            public string Text { get; set; }
            public object Tag { get; set; }
        }

        private void List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox list = sender as ListBox;
            if (list.Items.Count > 0)
            {
                UserForm userForm = new UserForm((list.SelectedItem as SearchClass).Tag as AccountDTO, Account, this);
                userForm.Left = this.Left + this.Width / 6;
                userForm.Top = this.Top + this.Height / 5;
                userForm.Show();
            }
        }
        private void TbSearch_LostFocus(object sender, RoutedEventArgs e)
        {
            if (FocusManager.GetFocusedElement(this).GetType() != typeof(ListBoxItem))
                listUsers.Items.Clear();
        }

        private void ListUsers_LostFocus(object sender, RoutedEventArgs e)
        {
            if (FocusManager.GetFocusedElement(this).GetType() != typeof(ListBoxItem))
            {
                if (FocusManager.GetFocusedElement(this) is TextBox)
                {
                    if ((FocusManager.GetFocusedElement(this) as TextBox).Foreground != Brushes.White)
                        listUsers.Items.Clear();
                }
                else
                    listUsers.Items.Clear();
            }
        }

        private void Mail_Click(object sender, RoutedEventArgs e)
        {
            if (listMails.Visibility == Visibility.Hidden)
                listMails.Visibility = Visibility.Visible;
            else
                listMails.Visibility = Visibility.Hidden;
        }
    }
}
