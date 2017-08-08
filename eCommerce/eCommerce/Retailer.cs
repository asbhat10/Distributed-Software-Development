using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace eCommerce
{
    class Retailer
    {
        Random rng = new Random();

        public void retailerFunc()
        {   
            //for starting thread
            //Check if the priceCutCounter is less than 10
            while (ChickenFarm.priceCutCounter < 10)
            {
                ChickenFarm chicken = new ChickenFarm();

                Thread.Sleep(500);
                Int32 p = chicken.getPrice();
                //Console.WriteLine("Store {0} has everyday low price: ${1} each", Thread.CurrentThread.Name, p);
                //Check if there is a price cut
                if (ChickenFarm.priceCutBool)
                {
                    //Create a new order and set the properties
                    Order order = new Order();
                    order.Amount = rng.Next(0, 5);
                    order.SenderId = Thread.CurrentThread.Name;
                    order.CardNo = rng.Next(5000, 7000);
                    order.ChickenPrice = p;
                    order.TimeStamp = GetTimestamp(DateTime.Now);
                    //Encode the order into String
                    String encodedOrder = encode(order);
                    //Send the order buffer cell
                    submitOrder(encodedOrder);
                    //put the thread to sleep for 2 seconds
                    Thread.Sleep(2000);
                }
                
            }
            
        }
        public void chickenOnSale(Int32 p)
        {  // Event handler
            Console.WriteLine("Store{0} chickens are on sale: as low as ${1} each", Thread.CurrentThread.Name, p);
        }

       
        //Set the order in the buffer cell
        private void submitOrder(string encodedOrder)
        {
            MultiCellBuffer.setCell(encodedOrder);

        }

        //Encode the order into string
        public string encode(Order order)
        {
            return order.SenderId + "_" + order.CardNo + "_" + order.Amount + "_" + order.TimeStamp+ "_"+order.ChickenPrice;
        }

        //Get the current time stamp
        public string GetTimestamp(DateTime value)
        {
            return value.ToString("F");
        }

        public void completeOrder(CompletedOrder cOrder)
        {
            //print the completed order confirmation
            if (cOrder.Status.Equals("success"))
            {
                Console.WriteLine("");
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("{0} successfully processed!! ", cOrder.OrderNum);
                Console.WriteLine("Retailer Id: {0}", cOrder.SenderId);
                Console.WriteLine("Number of Chickens ordered: {0}", cOrder.NoOfChickens);
                Console.WriteLine("Total Amount: {0}", cOrder.Amount);
                Console.WriteLine("Credit card Number: {0}", cOrder.CardNo);
                Console.WriteLine("Time Stamp: {0}", cOrder.TimeStamp);
                Console.WriteLine("Chicken Price: {0}", cOrder.ChickenPrice);
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("");
            }
        }
    }
}
