﻿namespace Basket.API.Models
{
    public class ShoppingCardItem
    {
        public int Quentity { get; set; } = default!;
        public string Color { get; set; } = default!;
        public decimal Price { get; set; } = default!;
        public Guid ProductId { get; set; } = default!;
        public string ProductName { get; set; } = default!;
    }
}
