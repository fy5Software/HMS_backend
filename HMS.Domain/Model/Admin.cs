﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Domain.Model
{
   public class Admin
    {
        public int Id { get; set; }
        public string BusinessName { get; set; }
        public string Category { get; set; }
        public string FoodLincNum { get; set; }
        public string Address { get; set; }
        public string Gst { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string BankName { get; set; }
        public string IfscCode { get; set; }
        public string BankAddress { get; set; }
        
        public long PinCode { get; set; }
        public string RestaurentLogo { get; set; }
        public string RestaurentSeal { get; set; }
        public string Signature { get; set; }
        public string TermAndCondition { get; set; }
    }
}
