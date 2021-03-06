﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace DataRepository.Models.nHibernateModels
{
    public class MonetaryFlowMap : ClassMap<MonetaryFlow>
    {
        public MonetaryFlowMap()
        {
            Id(x => x.Id).GeneratedBy.Increment();
            Map(x => x.Date);
            Map(x => x.AmountCash);
            Map(x => x.AmountNonCashBenefit);
            Map(x => x.AmountTransferAccount);
            References(c => c.Vat).Column("FK_VAT").Not.LazyLoad();
            References(c => c.User).Column("FK_UserId").Not.LazyLoad();
            Map(x => x.FK_UserId).Formula("[FK_UserId]");
            Map(x => x.FK_VAT).Formula("[FK_VAT]");
            Map(x => x.JournalEntryNum);
            Map(x => x.Total);

            UseUnionSubclassForInheritanceMapping();
        }
    }
}
