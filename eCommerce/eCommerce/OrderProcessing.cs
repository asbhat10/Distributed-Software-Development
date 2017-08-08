using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace eCommerce
{
    public delegate void completeOrderEvent(CompletedOrder cOrder);
    class OrderProcessing
    {
       
        //Event handler when the order is completed
        public static event completeOrderEvent completeOrder;

        //Constant shipping and handling charges
        Int32 shippingHandling = 5;
        public void processOrder(Order order)
        {
            //Get the unit price of chicken
            Int32 unitPrice = order.ChickenPrice;
            //Calculate the tax on the order
            double tax = (unitPrice * order.Amount) * 0.2;
            //Calculate total price
            double price = unitPrice * order.Amount + tax+ shippingHandling;
            //Insert values in Completed order object
            CompletedOrder compOrder = new CompletedOrder();
            compOrder.Amount = price;
            compOrder.SenderId = order.SenderId;
            //Check if the credit card number is in between 4000 and 7000
            if (order.CardNo >= 4000 && order.CardNo <= 7000)
            {
                compOrder.Status = "success";
                compOrder.CardNo = order.CardNo;
            }
            else
            {
                // Set status to fail if credit card number is not in between 4000 and 7000
                compOrder.Status = "fail";
                compOrder.CardNo = order.CardNo;
            }
            compOrder.NoOfChickens = order.Amount;
            compOrder.TimeStamp = order.TimeStamp;
            compOrder.OrderNum = Thread.CurrentThread.Name;
            compOrder.ChickenPrice = order.ChickenPrice;
            //Emit the event to the subscribers
            completeOrder(compOrder);
        }

    }
}
