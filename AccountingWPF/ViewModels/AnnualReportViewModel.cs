﻿using AccountingWPF.BaseLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Repositories;
using DataRepository.Models;
using Reporting;

namespace AccountingWPF.ViewModels
{
    public class AnnualReportViewModel
    {
        public IList<int> ActiveYears { get; set; }
        public int SelectedYear { get; set; }

        private IMonetaryFlowRepository<Expenditure> expenditureRepository { get; set; }
        private IMonetaryFlowRepository<Receipt> receiptRepository { get; set; }

        private AbstractReport htmlReport;

        public AnnualReportViewModel()
        {
            expenditureRepository = new ExpenditureRepository<Expenditure>();
            receiptRepository = new ReceiptRepository<Receipt>();

            IList<int> receiptsAvailableYears = receiptRepository.getAvailableYearsByUserId(UserManager.CurrentUser.Id);
            IList<int> expendituresAvailableYears = expenditureRepository.getAvailableYearsByUserId(UserManager.CurrentUser.Id);

            HashSet<int> yearsHashSet = new HashSet<int>();

            foreach (int year in receiptsAvailableYears.Concat(expendituresAvailableYears))
            {
                yearsHashSet.Add(year);
            }

            ActiveYears = yearsHashSet.ToList();

            SelectedYear = ActiveYears.FirstOrDefault();

            htmlReport = new HtmlReport();
        }

        public void CreateReport(string filepath)
        {
            using (System.IO.BinaryWriter writer = new System.IO.BinaryWriter(System.IO.File.Open(filepath, System.IO.FileMode.OpenOrCreate)))
            {
                writer.Write(htmlReport.CreateAnnualReport(UserManager.CurrentUser, SelectedYear, expenditureRepository.getByUserId(UserManager.CurrentUser.Id), receiptRepository.getByUserId(UserManager.CurrentUser.Id)));
                writer.Flush();
            }

        }
    }
}
