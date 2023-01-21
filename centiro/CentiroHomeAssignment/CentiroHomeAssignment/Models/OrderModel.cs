using System;
using System.Collections.Generic;

namespace CentiroHomeAssignment.Models
{
    public class OrderModel
    {

        public int OrderNumber { get; }
        public string OrderDate { get; set; }
        public string CustomerName { get; set; }
        public int CustomerNumber { get; set; }
        public List<OrderLineModel> OrderLines { get; set; }

        
        

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

