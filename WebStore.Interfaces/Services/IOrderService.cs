﻿using System.Collections.Generic;
using System.Threading.Tasks;
using WebStore.Domain.DTO.Orders;
using WebStore.Domain.Entities.Orders;
using WebStore.Domain.ViewModels;

namespace WebStore.Infrastructure.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDTO>> GetUserOrders(string UserName);

        Task<OrderDTO> GetOrderById(int Id);

        Task<OrderDTO> CreateOrder(string UserName, CreateOrderModel OrderModel);
    }
}
