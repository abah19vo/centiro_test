using System;
namespace CentiroHomeAssignment.Models
{
     public class OrderLineModel
     {
          public string OrderLineNumber { get; set; }
          public string ProductNumber { get; set; }
          public int Quantity { get; set; }
          public string Name { get; set; }
          public string Description { get; set; }
          public double Price { get; set; }
          public string ProductGroup { get; set; }

          public OrderLineModel(
              string NewOrderLineNumber,
              string NewProductNumber,
              int NewQuantity,
              string NewName,
              string NewDescription,
              double NewPrice,
              string NewProductGroup
              )
          {
               OrderLineNumber = NewOrderLineNumber;
               ProductNumber = NewProductNumber;
               Quantity = NewQuantity;
               Name = NewName;
               Description = NewDescription;
               Price = NewPrice;
               ProductGroup = NewProductGroup;
          }
     }
}

