using System;
using CentiroHomeAssignment.Models;
using System.Collections.Generic;
namespace CentiroHomeAssignment.Services
{
	public interface IOrderService
    {

        public List<OrderModel> GetAllOrders();

        public OrderModel GetOrderNumber(int OrderNumber);
    }
}

