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

        public ActionResult GetAll()
        {
            var vm = new GetAllOrdersViewModel();

            try
            {
                var orders = _orderService.GetAllOrders();

                if (orders.Count == 0)
                {
                    vm.Error = new ErrorModel("NoContent", "No orders excits yet");
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

        public ActionResult GetByOrderNumber(int id) {
            var vm = new GetByOrderNumberViewModel();
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

        public ActionResult CreateOrderLine(int? id)
        {
            try
            {
                
                return View();
            }
            catch
            {
                return StatusCode(500);
            }
        }
        //POST
        [HttpPost, ActionName("CreateOrderLine")]
        public ActionResult CreateOrderLine(int? id, OrderLineModel model)
        {
            try
            {
                _orderService.CreateOrderLine(id, model);
                var orders = _orderService.GetAllOrders();
                var vm = new GetAllOrdersViewModel();

                if (orders.Count == 0)
                {
                    vm.Error = new ErrorModel("NoContent", "No orders excits yet");
                }
                else vm.Orders = orders;
                return View("GetAll", vm);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        public ActionResult CreateOrder()
        {
            try
            {
                return View();
            }
            catch
            {
                return StatusCode(500);
            }
        }
        //POST
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrder( OrderModel model)
        {
            var vm = new CreateOrderModel();
            try
            {
                var res = _orderService.CreateOrder(model);
                return View("daGetAll");
            }
            catch
            {
                vm.Error = new ErrorModel("InternalError", "Unknown error occured, please try again later");
                return View( vm);
            }
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteByOrderNumber(int? id)
        {
            try
            {

                _orderService.DeleteByOrderNumber(id);
                return Redirect("GetAll");
            }
            catch(Exception e)
            {
                var vm = new GetByOrderNumberViewModel();
                if(e.Message == "BadContent")
                {
                    vm.Error = new ErrorModel("BadContent", "The order number is invalid");

                }
                if (e.Message == "NoContent")
                {
                    vm.Error = new ErrorModel("NotFound", "The order requested to be deleted does not exits");

                }else vm.Error = new ErrorModel("InternalError", "Unknown error occured, please try again later");
                return View(vm);

            }
        }

    }
}
