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
    /// Логика взаимодействия для NewTitlePage.xaml
    /// </summary>
    public partial class NewTitlePage : Page
    {
        public List<Employee> employees { get; set; }
        public Chatroom chatroom = new Chatroom();
        public Chatroom EditChatroom { get; set; }
        public NewTitlePage(List<Employee> EmployeesNewChat, Chatroom chatroom)
        {
            InitializeComponent();
            employees = EmployeesNewChat;
            EditChatroom = chatroom;
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (employees != null)
            {
                if (tbTitle.Text.Trim().Length != 0)
                {
                    chatroom.Topic = tbTitle.Text.Trim();
                    BdConnect.connection.Chatroom.Add(chatroom);

                    foreach (var i in employees)
                    {
                        ChatEmployee employeeChatroom = new ChatEmployee();
                        employeeChatroom.Chatroom_Id = chatroom.Id;
                        employeeChatroom.Employee_Id = i.Id;
                        BdConnect.connection.ChatEmployee.Add(employeeChatroom);
                    }

                    BdConnect.connection.SaveChanges();
                    NavigationService.Navigate(new inChatPage(chatroom));
                }
                else
                {
                    MessageBox.Show("Введите название");
                }
            }
            else
            {
                if (tbTitle.Text.Trim().Length != 0)
                {
                    EditChatroom.Topic = tbTitle.Text.Trim();
                    NavigationService.Navigate(new inChatPage(EditChatroom));
                }
                else
                {
                    MessageBox.Show("Введите название");
                }
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
