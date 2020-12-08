﻿using SolarCoffee.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarCoffee.Web.ViewModels
{
    public class OrderModel
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public CustomerModel Customer { get; set; }
        public List<SalesOrderItem> SalesOrderItems { get; set; }
        public bool IsPaid { get; set; }
    }
}