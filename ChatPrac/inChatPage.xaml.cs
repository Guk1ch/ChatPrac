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
        public Chatroom Chatroom { get; set; }
        public inChatPage(Chatroom chatroom)
        {
            InitializeComponent();
        }
    }
}
