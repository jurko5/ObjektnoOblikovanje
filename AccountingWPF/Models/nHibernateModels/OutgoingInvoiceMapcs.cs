﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace AccountingWPF.Models.nHibernateModels
{
    public class OutgoingInvoiceMap : SubclassMap<OutgoingInvoice>
    {
        public OutgoingInvoiceMap()
        {

            Map(x => x.CustomerInfo);
        }
    }
}
