namespace MUSACA.Services
{
    using Microsoft.EntityFrameworkCore;
    using MUSACA.Data;
    using MUSACA.Models;
    using MUSACA.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class OrderService : IOrderService
    {
        private readonly MusacaDbContext dbContext;

        private readonly IProductService productService;

        public OrderService(MusacaDbContext dbContext, IProductService productService)
        {
            this.dbContext = dbContext;
            this.productService = productService;
        }

        public Order Create(Order order)
        {
            Order orderFromDb = this.dbContext.Orders.Add(order).Entity;
            this.dbContext.SaveChanges();

            return orderFromDb;
        }

        public Order Cashout(string orderId)
        {
            this.dbContext.Orders
                .SingleOrDefault(order => order.Id == orderId)
                .Status = OrderStatus.Completed;

            Order updatedOrder = this.dbContext.Orders
                .SingleOrDefault(order => order.Id == orderId);

            this.dbContext.Update(updatedOrder);

            Order newActiveOrder = new Order
            {
                IssuedOn = DateTime.UtcNow,
                CashierId = updatedOrder.CashierId
            };

            return this.Create(newActiveOrder);
        }

        public Order GetActiveOrder(string userId)
        {
            var currentActiveOrder = this.dbContext.Orders
                .Include(order => order.Products)
                .ThenInclude(orderProduct => orderProduct.Product)
                .Include(order => order.Cashier)
                .SingleOrDefault(order => order.CashierId == userId && order.Status == OrderStatus.Active);

            return currentActiveOrder;
        }

        public ICollection<Order> GetCurrentUserCompletedOrders(string userId)
        {
            return this.dbContext.Orders
                .Include(order => order.Products)
                .ThenInclude(orderProduct => orderProduct.Product)
                .Include(order => order.Cashier)
                .Where(order => order.CashierId == userId && order.Status == OrderStatus.Completed)
                .ToList();
        }

        //TODO: Go over this again
        public bool AddProduct(string userId, string productId)
        {
            Product orderedProduct = this.dbContext.Products
                .SingleOrDefault(product => product.Id == productId);

            Order currentActiveOrder = this.GetActiveOrder(userId);            

            int initialOrderProductsCount = currentActiveOrder.Products.Count;

            currentActiveOrder.Products.Add(new OrderProduct
            {
                Product = orderedProduct
            });

            this.dbContext.Update(currentActiveOrder);
            this.dbContext.SaveChanges();

            int orderProductsCount = currentActiveOrder.Products.Count;

            if (initialOrderProductsCount + 1 == orderProductsCount)
            {
                return true;
            }

            return false;
        }
    }
}
