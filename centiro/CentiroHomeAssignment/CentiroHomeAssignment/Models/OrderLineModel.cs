using System;
namespace CentiroHomeAssignment.Models
{
     public class OrderLineModel
     {
        public string OrderLineNumber { get; set; }
        public string ProductNumber { get; set; }
        public string Quantity { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string ProductGroup { get; set; }

        public OrderLineModel()
        {
            OrderLineNumber = "";
            ProductNumber = "";
            Quantity = "";
            Name = "";
            Description = "";
            Price = "";
            ProductGroup = "";
        }

        public OrderLineModel(
            string NewOrderLineNumber,
            string NewProductNumber,
            string NewQuantity,
            string NewName,
            string NewDescription,
            string NewPrice,
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

