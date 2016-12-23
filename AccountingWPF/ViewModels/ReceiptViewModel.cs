﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingWPF.Models;
using AccountingWPF.Repositories;
using AccountingWPF.BaseLib;

namespace AccountingWPF.ViewModels
{
    public class ReceiptViewModel
    {
        public IList<Receipt> receipts { get; set; }
        //public IList<VAT> vats { get; set; }
        private MonateryFlowCRUD<Receipt> receiptRepo { get; set; }
        //private VatRepository vatRepo { get; set; }

        public ReceiptViewModel()
        {
            receiptRepo = new ReceiptRepository<Receipt>();
            receipts = receiptRepo.getByUserId(UserManager.CurrentUser.Id);
        }

    }
}