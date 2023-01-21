using System;
using CentiroHomeAssignment.Models;
using System.Collections.Generic;

namespace CentiroHomeAssignment.Repositories
{
	public interface IOrderRepository
	{
        public List<OrderModel> GetAllOrders();

        public OrderModel GetOrderNumber(int ordernumber);
    }
}

