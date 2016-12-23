﻿using AccountingWPF.Notification;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingWPF.Models
{
    public class Expenditure : MonateryFlow
    {
        [RegularExpression(@"[0-9]{1,8}\,[0-9]{1,2}", ErrorMessage = "Value must be a decimal number")]
        public virtual string Article22 {
            get {
                return GetValue(() => Article22); ;
            }

            set {
                SetValue(() => Article22, value);
            }
        }

    }
}
