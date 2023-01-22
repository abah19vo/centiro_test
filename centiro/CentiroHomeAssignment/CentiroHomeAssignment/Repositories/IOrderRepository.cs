using System;
using CentiroHomeAssignment.Models;
using System.Collections.Generic;

namespace CentiroHomeAssignment.Repositories
{
	public interface IOrderRepository
	{
        public List<OrderModel> GetAllOrders();

        public OrderModel GetOrderNumber(int ordernumber);

        public void DeleteOrderNumber(int ordernumber);

        public int CreateOrder(OrderModel newOrder);

        public string CreateOrderLine(int orderNumber,OrderLineModel newOrder);


    }
}

