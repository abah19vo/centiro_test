using System;
using System.Collections.Generic;
using CentiroHomeAssignment.Models;
using CentiroHomeAssignment.Repositories;

namespace CentiroHomeAssignment.Tests
{
	public class MockOrderRepository : IOrderRepository
    {
        public bool ShouldReturnEmpty = false;
        public bool ShouldThrowError = false;

        public MockOrderRepository()
		{
		}

        public void DeleteOrderNumber(int ordernumber)
        {
            if(ShouldThrowError) throw new Exception();
        }

        public List<OrderModel> GetAllOrders()
        {
            if (ShouldReturnEmpty) return new List<OrderModel> { };
            if (ShouldThrowError) throw new Exception();
            return new List<OrderModel> { new OrderModel(-1,"","",-1,null) };
        }

        public OrderModel GetOrderNumber(int OrderNumber)
        {
            if (ShouldReturnEmpty) return null;
            if (ShouldThrowError) throw new Exception();
            return new OrderModel(-1, "", "", -1, null);
        }
    }
}

