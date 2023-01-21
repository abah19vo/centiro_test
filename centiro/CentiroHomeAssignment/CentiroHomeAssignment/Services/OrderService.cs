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

    }
}

