﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace AccountingWPF.Models.nHibernateModels
{
    public class MonateryFlowMap : ClassMap<MonateryFlow>
    {

        public MonateryFlowMap()
        {
            Id(x => x.Id).Column("Id").GeneratedBy.Increment();
            Map(x => x.Date);
            Map(x => x.AmountCash);
            Map(x => x.AmountNonCashBenefit);
            Map(x => x.AmountTransferAccount);
            //pogledat kako rjesit foreign keyeve
            Map(x => x.FK_UserId);
            Map(x => x.FK_VAT);
            Map(x => x.JournalEntryNum);
            Map(x => x.Total);

            UseUnionSubclassForInheritanceMapping();
        }

    }
}