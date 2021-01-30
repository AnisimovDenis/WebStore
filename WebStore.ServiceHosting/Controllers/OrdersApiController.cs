using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.DTO.Orders;
using WebStore.Domain.Entities.Orders;
using WebStore.Domain.ViewModels;
using WebStore.Infrastructure.Services;
using WebStore.Interfaces;

namespace WebStore.ServiceHosting.Controllers
{
    [Route(WebAPI.Orders)]
    [ApiController]
    public class OrdersApiController : ControllerBase
    {
        private readonly IOrderService orderService;
        private readonly ILogger<OrdersApiController> logger;

        public OrdersApiController(IOrderService orderService, ILogger<OrdersApiController> logger)
        {
            this.orderService = orderService;
            this.logger = logger;
        }

        public async Task<IEnumerable<OrderDTO>> GetUserOrders(string userName) => await orderService.GetUserOrders(userName);

        public async Task<OrderDTO> GetOrderById(int id) => await orderService.GetOrderById(id);

        public async Task<OrderDTO> CreateOrder(string userName, [FromBody] CreateOrderModel orderModel)
        {
            logger.LogInformation($"Формирование заказа для пользователя {userName}");
            var order = await orderService.CreateOrder(userName, orderModel);

            return order;
        }
    }
}
