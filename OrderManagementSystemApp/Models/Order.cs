using System;
using System.ComponentModel.DataAnnotations;

namespace OrderManagementSystemApp.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public int CustomerId { get; set; }
        public required Customer Customer { get; set; }
        public required string ProductList { get; set; }

    }
}