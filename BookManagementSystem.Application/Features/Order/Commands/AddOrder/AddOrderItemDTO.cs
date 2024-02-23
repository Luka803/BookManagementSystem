﻿namespace BookManagementSystem.Application.Features.Order.Commands.AddOrder;

public class AddOrderItemDTO
{
    public Guid OrderID = Guid.Empty;
    public Guid BookID { get; set; }

    public decimal Price = 0;

    public int ItemNumber = 1;
    public int Count { get; set; }

}
