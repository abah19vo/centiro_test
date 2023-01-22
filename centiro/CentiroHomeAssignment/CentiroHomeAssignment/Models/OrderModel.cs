using System;
using System.Collections.Generic;

namespace CentiroHomeAssignment.Models
{
    public class OrderModel
    {

        public int OrderNumber { get; set; }
        public string OrderDate { get; set; }
        public string CustomerName { get; set; }
        public int CustomerNumber { get; set; }
        public List<OrderLineModel> OrderLines { get; set; }

        public OrderModel(
               )
        {
            OrderNumber = -1;
            OrderDate = "";
            CustomerName = "";
            CustomerNumber = -1;
            OrderLines = new List<OrderLineModel> { };
        }

        public OrderModel(
               String NewOrderDate,
               String NewCustomerName,
               int NewCustomerNumber
               )
        {
            OrderNumber = -1;
            OrderDate = NewOrderDate;
            CustomerName = NewCustomerName;
            CustomerNumber = NewCustomerNumber;
            OrderLines = new List<OrderLineModel> { };
        }
        public OrderModel(
               int NewOrderNumber,
               String NewOrderDate,
               String NewCustomerName,
               int NewCustomerNumber,
               List<OrderLineModel> NewOrderLines
               )
          {
            OrderNumber = NewOrderNumber;
            OrderDate = NewOrderDate;
            CustomerName = NewCustomerName;
            CustomerNumber = NewCustomerNumber;
            OrderLines = NewOrderLines;  
          }
     }
}

