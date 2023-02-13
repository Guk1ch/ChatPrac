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
	/// Логика взаимодействия для SearchPage.xaml
	/// </summary>
	public partial class SearchPage : Page
	{
		public List<Department> departments { get; set; }
		public List<Employee> Employees = new List<Employee>();
		public Chatroom ChatroomNow = null;
		public SearchPage(Chatroom chatroom)
		{
			InitializeComponent();
			departments = BdConnect.connection.Department.ToList();
			ChatroomNow = chatroom;
			DataContext = this;
		}

		private void tbSearch_SelectionChanged(object sender, RoutedEventArgs e)
		{
			Filter();
		}

        private void lvDepartments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
			Filter();
        }
		private void Filter()
        {
			Employees = new List<Employee>();
			foreach(var item in departments)
            {
				if (item.IsChecked)
					Employees.AddRange(item.Employee);
            }
			if(tbSearch.Text.Trim().Length != 0)
            {
				Employees = Employees.Where(x => x.Name.Contains(tbSearch.Text.Trim())).ToList();
            }
			lvEmployee.ItemsSource = Employees;
        }

        private void lvEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
			if(lvEmployee.SelectedItem != null)
            {
				var item = lvEmployee.SelectedItem as Employee;
				ChatEmployee chatrom = new ChatEmployee();
				chatrom.Employee_Id = item.Id;
				chatrom.Chatroom_Id = ChatroomNow.Id;

				var uniqUser = BdConnect.connection.ChatEmployee.Where(x=> x.Chatroom_Id == chatrom.Id && x.Employee_Id == chatrom.Employee_Id).FirstOrDefault();
				if(uniqUser == null)
                {
					BdConnect.connection.ChatEmployee.Add(chatrom);
					BdConnect.connection.SaveChanges();
					NavigationService.Navigate(new inChatPage(ChatroomNow, null));
                }
                else
                {
					MessageBox.Show("Этот пользователь уже в чате");
                }
            }
        }
    }
}
