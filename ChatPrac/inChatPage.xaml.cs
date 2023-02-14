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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ChatPrac.DataBase;

namespace ChatPrac
{
    /// <summary>
    /// Логика взаимодействия для inChatPage.xaml
    /// </summary>
    public partial class inChatPage : Page
    {
        public List<ChatMessage> ChatMessages { get; set; }
        public List<ChatEmployee> EmployeeChatrooms { get; set; }
        public Chatroom Chatrooms { get; set; }
        public inChatPage(Chatroom chatroom)
        {
            InitializeComponent();
            ChatMessages = BdConnect.connection.ChatMessage.Where(x => x.Chatroom_Id == chatroom.Id).ToList();
            EmployeeChatrooms = BdConnect.connection.ChatEmployee.Where(x => x.Chatroom_Id == chatroom.Id).ToList();
            Chatrooms = chatroom;
            DataContext = this;
        }
        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            if (tbChat.Text.Trim().Length != 0)
            {
                ChatMessage message = new ChatMessage();
                message.Sender_Id = MainWindow.employee.Id;
                message.Chatroom_Id = Chatrooms.Id;
                message.Date = DateTime.Now;
                message.Message = tbChat.Text.Trim();
                BdConnect.connection.ChatMessage.Add(message);
                BdConnect.connection.SaveChanges();

                ChatMessages = BdConnect.connection.ChatMessage.Where(x => x.Chatroom_Id == Chatrooms.Id).ToList();
                EmployeeChatrooms = BdConnect.connection.ChatEmployee.Where(x => x.Chatroom_Id == Chatrooms.Id).ToList();

                lvChat.ItemsSource = ChatMessages;
                lvEmployee.ItemsSource = EmployeeChatrooms;

                tbChat.Text = "";
            }
        }
        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new EmployeeFinderPage(Chatroom));
        }

        private void btnLeaveChatroom_Click(object sender, RoutedEventArgs e)
        {
            ChatEmployee chatroom = BdConnect.connection.ChatEmployee.Where(x => x.Chatroom_Id == Chatrooms.Id
            && x.Employee_Id == MainWindow.employee.Id).FirstOrDefault();

            if (chatroom != null)
            {
                BdConnect.connection.ChatEmployee.Remove(chatroom);
                BdConnect.connection.SaveChanges();
                NavigationService.Navigate(new MainPage(MainWindow.employee));
            }
            else
            {
                MessageBox.Show("You not be in this chat");
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage(MainWindow.employee));
        }

        private void btnChangeTopic_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NewTitlePage(null, Chatrooms));
        }

    }
}
