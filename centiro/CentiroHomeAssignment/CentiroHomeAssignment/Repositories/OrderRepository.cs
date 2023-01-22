using System;
using System.Collections.Generic;
using System.IO;
using CentiroHomeAssignment.Models;

namespace CentiroHomeAssignment.Repositories
{
	public class OrderRepository: IOrderRepository
    {
        static List<OrderModel> allOrders;

        public OrderRepository():base()
		{
            var files = new string[] { "Order1.txt", "Order2.txt", "Order3.txt" };

            var result = new List<OrderModel> { };
            foreach (var file in files)
            {
                result.Add(GetOrderByFileName(file));
            }
            allOrders = result;
        }

        public void DeleteOrderNumber(int ordernumber)
        {
            allOrders.RemoveAll((order)=> order.OrderNumber == ordernumber);
        }

        public int CreateOrder(OrderModel newOrder)
        {
            newOrder.OrderNumber = allOrders.Count;

            allOrders.Add(newOrder);
            return newOrder.OrderNumber;
        }

        public List<OrderModel> GetAllOrders() => allOrders;

        public OrderModel GetOrderNumber(int ordernumber) => allOrders.Find((order) => order.OrderNumber == ordernumber);

        private OrderModel GetOrderByFileName(string fileName)
		{
            string path = Path.Combine(Directory.GetCurrentDirectory(), "App_Data", fileName);

            var lines = File.ReadAllLines(path);
            if (lines.Length < 2) throw new Exception("Empty Order");

            var firstLine = lines[1].Split("|");
            var newOrder = new OrderModel(
                int.Parse(firstLine[1]),
                firstLine[9],
                firstLine[10],
                int.Parse(firstLine[11]),
                new List<OrderLineModel> { }
                );
            for (int i = 1; i < lines.Length; i++)
            {
                var line = lines[i].Split("|");
                newOrder.OrderLines.Add(new OrderLineModel(
                    line[2],
                    line[3],
                    line[4],
                    line[5],
                    line[6],
                    line[7],
                    line[8]
                    ));
            }
            return newOrder;
        }

        public string CreateOrderLine(int orderNumber, OrderLineModel newOrderLine)
        {

            var orderLines = allOrders.Find((order) => order.OrderNumber == orderNumber).OrderLines;
            newOrderLine.OrderLineNumber = orderLines.Count.ToString();
            orderLines.Add(newOrderLine);
            return newOrderLine.OrderLineNumber;

        }
    }
}

