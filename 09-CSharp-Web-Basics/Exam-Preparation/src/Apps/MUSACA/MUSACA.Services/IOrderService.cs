namespace MUSACA.Services
{
    using MUSACA.Models;
    using System.Collections.Generic;

    public interface IOrderService
    {
        Order Create(Order order);

        Order Cashout(string orderId);

        Order GetActiveOrder(string userId);

        ICollection<Order> GetCurrentUserCompletedOrders(string userId);

        bool AddProduct(string userId, string productId);
    }
}
