﻿using AccountingWPF.ChildWindow.ViewModel;
using AccountingWPF.ChildWindow.View;
using AccountingWPF.Helpers;
using DataRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingWPF.ChildWindow
{
    public class ChildWindowUpdateIngoingInvoiceView
    {
        public event Action<IngoingInvoice> Closed;
        
        public ChildWindowUpdateIngoingInvoiceView()
        {

        }

        public void Show(IngoingInvoice selected)
        {
            UpdateIngoingInvoiceViewModel vm = new UpdateIngoingInvoiceViewModel(selected);
            vm.Closed += ChildWindow_Closed;
            ChildWindowUpdateManager.Instance.ShowChildWindow(new UpdateIngoingInvoiceView() { DataContext = vm });
        }

        void ChildWindow_Closed(IngoingInvoice invoice)
        {
            if (Closed != null)
                Closed(invoice);
            ChildWindowUpdateManager.Instance.CloseChildWindow();
        }
    }
}
