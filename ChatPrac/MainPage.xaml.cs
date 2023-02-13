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
	/// Логика взаимодействия для MainPage.xaml
	/// </summary>
	public partial class MainPage : Page
	{
		public List<Chatroom> chatrooms { get; set; }
		public Employee Empl { get; set; }
		public MainPage(Employee employee)
		{
			InitializeComponent();
			chatrooms = BdConnect.connection.Chatroom.ToList();
			Empl= employee;
			DataContext = this;
		}

		private void btnEmplFind_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new SearchPage(null));
		}

		private void btnClose_Click(object sender, RoutedEventArgs e)
		{
			System.Windows.Application.Current.Shutdown();
		}

        private void lvChat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
			if(lvChat.SelectedItem != null)
            {
				var item = lvChat.SelectedItem as Chatroom;
				NavigationService.Navigate(new inChatPage());
            }
        }
    }
}
