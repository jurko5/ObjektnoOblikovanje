﻿using AccountingWPF.ViewModels;
using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace AccountingWPF.Views
{
    /// <summary>
    /// Interaction logic for AnnualReport.xaml
    /// </summary>
    public partial class AnnualReportWindow : Window
    {
		public AnnualReportViewModel annualReportVM;
		private SaveFileDialog saveFileDialog;

        public AnnualReportWindow()
        {
            InitializeComponent();

			annualReportVM = new AnnualReportViewModel();
			this.DataContext = annualReportVM;

			saveFileDialog = new SaveFileDialog();
			saveFileDialog.DefaultExt = ".html";
			saveFileDialog.Filter = "HyperText Markup File (*.html)|*.html";
        }

		private void btn_create_Click(object sender, RoutedEventArgs e)
		{
			bool? dialogResult = saveFileDialog.ShowDialog();
			if (dialogResult.HasValue && dialogResult.Value == true)
			{
				annualReportVM.CreateReport(saveFileDialog.FileName);

				lbl_status.Content = "Report created at: " + saveFileDialog.FileName.ToString();
			}
			else
			{
				lbl_status.Content = "Report creation aborted!";
			}
		}
    }
}
