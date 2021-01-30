using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebStore.Clients.Base;
using WebStore.Domain.DTO.Orders;
using WebStore.Infrastructure.Services;
using WebStore.Interfaces;

namespace WebStore.Clients.Orders
{
    public class OrdersClient : BaseClient, IOrderService
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<OrdersClient> logger;

        public OrdersClient(IConfiguration configuration, ILogger<OrdersClient> logger) : base(configuration, WebAPI.Orders)
        {
            this.configuration = configuration;
            this.logger = logger;
        }

        public async Task<OrderDTO> CreateOrder(string UserName, CreateOrderModel OrderModel)
        {
            var response = await PostAsync($"{Address}/{UserName}", OrderModel);
            return await response.Content.ReadAsAsync<OrderDTO>();
        }

        public async Task<OrderDTO> GetOrderById(int Id) => await GetAsync<OrderDTO>($"{Address}/{Id}");

        public async Task<IEnumerable<OrderDTO>> GetUserOrders(string UserName) => await GetAsync<IEnumerable<OrderDTO>>($"{Address}/user/{UserName}");
    }
}
