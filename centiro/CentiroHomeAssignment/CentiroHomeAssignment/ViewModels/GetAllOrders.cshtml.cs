using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CentiroHomeAssignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CentiroHomeAssignment.Views.Orders
{
    public class GetAllOrdersViewModel : PageModel
    {
        public List<OrderModel> Orders;
        public ErrorModel Error { get; set; }
        public OrderModel SelectedOrder {get;set;}

        public object SetSelectedOrder(OrderModel order) => SelectedOrder = order;

        public void OnGet()
        {
        }
    }
}
