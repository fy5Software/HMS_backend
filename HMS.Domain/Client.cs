﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Domain
{
   public class Client:BaseEntity
    {
       
        public string Business { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Address { get; set; }
        public int Gst { get; set; }

    }
}
