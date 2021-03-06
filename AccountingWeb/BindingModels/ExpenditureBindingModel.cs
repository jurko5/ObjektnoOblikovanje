﻿using DataRepository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AccountingWeb.BindingModels
{
	public class ExpenditureBindingModel
	{
		[Required]
		public Expenditure Expenditure { get; set; }

		public List<Vat> VATs { get; set; }

		public ExpenditureBindingModel(Expenditure expenditure, List<Vat> vats)
		{
			Expenditure = expenditure;
			VATs = vats;
		}

		public ExpenditureBindingModel()
		{

		}

	}
}