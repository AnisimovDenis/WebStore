using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Domain.DTO.Orders;
using WebStore.Domain.Entities.Orders;

namespace WebStore.Services.Mapping
{
    public static class OrderMapper
    {
        public static OrderItemDTO ToDTO(this OrderItem item) => item is null
            ? null
            : new OrderItemDTO(item.Id, item.Price, item.Quantity);

        public static OrderItem FromDTO(this OrderItemDTO item) => item is null
            ? null
            : new OrderItem
            {
                Id = item.Id,
                Price = item.Price,
                Quantity = item.Quantity
            };

        public static OrderDTO ToDTO(this Order order) => order is null
            ? null
            : new OrderDTO(order.Id, order.Name, order.Phone, order.Address, order.Date, order.Items.Select(ToDTO));

        public static Order FromDTO(this OrderDTO order) => order is null
            ? null
            : new Order
            {
                Id = order.Id,
                Name = order.Name,
                Phone = order.Phone,
                Address = order.Address,
                Date = order.Date,
                Items = order.items.Select(FromDTO).ToList()
            };
    }
}
