﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Reporting;
using AccountingWeb.BindingModels;
using DataRepository.Repositories;
using DataRepository.Models;
using AccountingWeb.Security;

namespace AccountingWeb.Controllers
{
    public class AnnualReportController : Controller
    {
		private IMonetaryFlowRepository<Expenditure> expenditureRepository = new ExpenditureRepository<Expenditure>(AccountingWeb.Database.SessionManager.SessionFactory);
		private IMonetaryFlowRepository<Receipt> receiptRepository = new ReceiptRepository<Receipt>(AccountingWeb.Database.SessionManager.SessionFactory);
		private AbstractReport reportBuilder = new HtmlReport();
		//
		// GET: /AnnualReport/
		public ActionResult Index()
		{
			ReportBindingModel reportBM = new ReportBindingModel();
			reportBM.ActiveYears.AddRange(expenditureRepository.getAvailableYearsByUserId(UserManager.CurrentUser.Id));
			reportBM.ActiveYears.AddRange(receiptRepository.getAvailableYearsByUserId(UserManager.CurrentUser.Id));

			reportBM.ActiveYears = reportBM.ActiveYears.Distinct().ToList();

			reportBM.SelectedYear = reportBM.ActiveYears.First();

			return View(reportBM);
		}

		//
		// GET: /AnnualReport/GenerateReport
		public FileResult GenerateReport(ReportBindingModel reportBM)
		{
			//the reason why this form of reporting isn't optimal
			IList<Expenditure> expenditures = expenditureRepository.getByUserId(UserManager.CurrentUser.Id);
			IList<Receipt> receipts = receiptRepository.getByUserId(UserManager.CurrentUser.Id);

			byte[] fileBytes = reportBuilder.CreateAnnualReport(UserManager.CurrentUser, reportBM.SelectedYear, expenditures, receipts);
			return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, "Annual_Report_" + UserManager.CurrentUser.AssociationName + "_" + reportBM.SelectedYear.ToString() + ".html");
		}
    }
}
