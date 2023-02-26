﻿using System.ComponentModel.DataAnnotations;

namespace DoAnBE.Models
{
    public class OrderDetail
    {
        [Key]
        public Guid OrderDetailId { get; set; }
        public Guid Id { get; set; }
        public int OrderId { get; set; }
        public Guid ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
