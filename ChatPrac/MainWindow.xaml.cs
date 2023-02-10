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
using System.Collections.ObjectModel;
using System.Windows.Shapes;
using ChatPrac.DataBase;

namespace ChatPrac
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public static Employee employee { get; set; }
		public MainWindow()
		{
			InitializeComponent();
			

		}

		private void btnOk_Click(object sender, RoutedEventArgs e)
		{
			string login = tbLog.Text.Trim();
			string password = tbPass.Password.Trim();
			employee =BdConnect.connection.Employee.Where(x=> x.Username == login && x.Password == password).FirstOrDefault();
			if(employee == null)
			{
				MessageBox.Show("Что то не так");
			}
			else if (employee != null)
			{
				ManeWindow window = new ManeWindow(employee);
				window.Show();
				this.Close();
			}
		}

		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}
