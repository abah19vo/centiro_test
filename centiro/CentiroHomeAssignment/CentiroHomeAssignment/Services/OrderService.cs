using System;
using System.Collections.Generic;
using CentiroHomeAssignment.Models;
using CentiroHomeAssignment.Repositories;

namespace CentiroHomeAssignment.Services
{
	public class OrderService : IOrderService
	{
		private readonly IOrderRepository _orderRepository;
		public OrderService(IOrderRepository repository):base() => _orderRepository = repository;

        public List<OrderModel> GetAllOrders() => _orderRepository.GetAllOrders();
		 
        public OrderModel GetOrderNumber(int OrderNumber) => _orderRepository.GetOrderNumber(OrderNumber);

		public void DeleteByOrderNumber(int? OrderNumber) {
			if (OrderNumber == null) throw new Exception("BadContent");

			var excists = _orderRepository.GetOrderNumber(OrderNumber??-1) == null;
			if(!excists) throw new Exception("NotFound");
            _orderRepository.DeleteOrderNumber(OrderNumber ?? -1);
		}

        public int CreateOrder(OrderModel newOrder)
        {
            if (newOrder == null ) throw new Exception("BadContent");      
            return _orderRepository.CreateOrder(newOrder);
        }

        public string CreateOrderLine(int? orderNumber, OrderLineModel newOrderLine)
        {
            if (newOrderLine == null || orderNumber == null) throw new Exception("BadContent");
            return _orderRepository.CreateOrderLine(orderNumber??-1, newOrderLine);
        }


    }
}

