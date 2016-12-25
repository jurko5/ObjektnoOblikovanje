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
using System.Windows.Shapes;
using AccountingWPF.ViewModels;

namespace AccountingWPF.Views
{
	/// <summary>
	/// Interaction logic for ExpenditureMainWindow.xaml
	/// </summary>
	public partial class ExpenditureMainWindow : Window
	{
        ExpenditureViewModel expenditureVM { get; set; } 

		public ExpenditureMainWindow()
		{
			InitializeComponent();
           
            expenditureVM = new ExpenditureViewModel();
			this.DataContext = expenditureVM;
			this.dg_cbx_VAT.ItemsSource = expenditureVM.vats;
            DeinitializeDataGrid();
			
		}

        private void DeinitializeDataGrid() 
        {
            this.Delete_expenditure_button.IsEnabled = false;
            this.Save_expenditure_button.IsEnabled = false;
            this.dataGridExpenditure.IsEnabled = false;
        }
        private void InitializeDataGrid()
        {
            this.dataGridExpenditure.IsEnabled = true;
            this.Delete_expenditure_button.IsEnabled = true;
            this.Save_expenditure_button.IsEnabled = true;
        }

        private void Add_new_expenditure_Button_Click(object sender, RoutedEventArgs e)
        {
            InitializeDataGrid();
            MessageBox.Show("Add");
        }

        private void Delete_expenditure_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("delete");
        }

        private void Edit_expenditure_Button_Click(object sender, RoutedEventArgs e)
        {
            InitializeDataGrid();
            MessageBox.Show("edit");
        }

        private void Save_ependiture_Button_Click(object sender, RoutedEventArgs e)
        {
            DeinitializeDataGrid();
            MessageBox.Show("save");
        }
	}
}
