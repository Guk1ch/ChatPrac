﻿using System;
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
		public MainPage(Employee employee)
		{
			InitializeComponent();
		}

		private void btnEmplFind_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new SearchPage());
		}

		private void btnClose_Click(object sender, RoutedEventArgs e)
		{
			
		}
	}
}
