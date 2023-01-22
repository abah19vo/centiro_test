using CentiroHomeAssignment.Controllers;
using CentiroHomeAssignment.Services;
using CentiroHomeAssignment.ViewModel;
using CentiroHomeAssignment.Views.Orders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CentiroHomeAssignment.Tests
{
    [TestClass]
    public class OrderUnitTest
    {

        MockOrderRepository Repository;
        OrderService Service;
        OrdersController Controller;
        public OrderUnitTest()
        {
            Repository = new MockOrderRepository();
            Service = new OrderService(Repository);
            Controller = new OrdersController(Service);
        }

        [TestMethod]
        public void Gets_orders_GetAll()
        {
            Repository.ShouldThrowError = false;
            Repository.ShouldReturnEmpty = false;

            var result = Controller.GetAll() as ViewResult;
            var ordersModel = (GetAllOrdersViewModel)result.ViewData.Model;

            Assert.IsNull(ordersModel.Error);
            Assert.IsNotNull(ordersModel.Orders);
            Assert.IsTrue(ordersModel.Orders.Count > 0);
        }
        [TestMethod]
        public void Handeles_uexpected_exceptions_GetAll()
        {
            Repository.ShouldThrowError = true;
            var result = Controller.GetAll() as ViewResult; ;
            var ordersModel = (GetAllOrdersViewModel)result.ViewData.Model;

            Assert.IsNotNull(ordersModel.Error);
            Assert.AreEqual("InternalError", ordersModel.Error.ErrorCode);
            Assert.IsNull(ordersModel.Orders);
        }
        [TestMethod]
        public void Handeles_empty_result_GetAll()
        { 
            Repository.ShouldThrowError = false;
            Repository.ShouldReturnEmpty = true;

            var result = Controller.GetAll() as ViewResult;
            var ordersModel = (GetAllOrdersViewModel)result.ViewData.Model;

            Assert.IsNotNull(ordersModel.Error);
            Assert.AreEqual("NoContent", ordersModel.Error.ErrorCode);
            Assert.IsNull(ordersModel.Orders);
        }

        [TestMethod]
        public void Get_specific_order_GetByOrderNumber()
        {
            Repository.ShouldThrowError = false;
            Repository.ShouldReturnEmpty = false;

            var result = Controller.GetByOrderNumber(1) as ViewResult;
            var orderModel = (GetByOrderNumerViewModel)result.ViewData.Model;

            Assert.IsNull(orderModel.Error);
            Assert.IsNotNull(orderModel.Order);

        }

        [TestMethod]
        public void Handeles_uexpected_exceptions_GetByOrderNumber()
        {
            Repository.ShouldThrowError = true;
            Repository.ShouldReturnEmpty = false;

            var result = Controller.GetByOrderNumber(1) as ViewResult;
            var orderModel = (GetByOrderNumerViewModel)result.ViewData.Model;

            Assert.IsNotNull(orderModel.Error);
            Assert.AreEqual("InternalError", orderModel.Error.ErrorCode);
            Assert.IsNull(orderModel.Order);
        }
        [TestMethod]
        public void Handeles_null_result_GetByOrderNumber()
        {
            Repository.ShouldThrowError = false;
            Repository.ShouldReturnEmpty = true;

            var result = Controller.GetByOrderNumber(1) as ViewResult;
            var orderModel = (GetByOrderNumerViewModel)result.ViewData.Model;

            Assert.IsNotNull(orderModel.Error);
            Assert.AreEqual("NotFound", orderModel.Error.ErrorCode);
            Assert.IsNull(orderModel.Order);
        }
    }
}
