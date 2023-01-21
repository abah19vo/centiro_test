using System;
using System.Collections.Generic;
using System.IO;
using CentiroHomeAssignment.Models;
using CentiroHomeAssignment.Services;
using CentiroHomeAssignment.ViewModel;
using CentiroHomeAssignment.Views.Orders;
using Microsoft.AspNetCore.Mvc;

namespace CentiroHomeAssignment.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService service) => _orderService = service;

        public IActionResult GetAll()
        {
            var vm = new GetAllOrdersViewModel();

            try
            {
                var orders = _orderService.GetAllOrders();

                if (orders.Count == 0)
                {
                    vm.Error = new ErrorModel("NotFound", "The requested order number is not found");
                }
                else vm.Orders = orders;
                return View(vm);
            }
            catch
            {
                vm.Error = new ErrorModel("InternalError", "Unknown error occured, please try again later");
                return View(vm);
            }
            
        }

        public IActionResult GetByOrderNumber(int id) {
            var vm = new GetByOrderNumerViewModel();
            try
            {
                var order = _orderService.GetOrderNumber(id);
                vm.OrderNumber = id;
                if (order == null)
                {
                    vm.Error = new ErrorModel("NotFound", "The requested order number is not found");
                }
                else vm.Order = order;
                return View(vm);
            }
            catch
            {
                vm.Error = new ErrorModel("InternalError", "Unknown error occured, please try again later");
                return View(vm);
            }
            
        }
        
    }
}
