using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace eCommerce
{
    public delegate void priceCutEvent(Int32 pr); 	// Define delegate
    class ChickenFarm
    {
        static Random rng = new Random();
        public static int orderNum = 1;
        //Counter for number of price cuts
        public static int priceCutCounter = 0;
        //varible to keep track if there is a price cut
        public static Boolean priceCutBool = false;
        public static event priceCutEvent priceCut; // Define event
        //Initial chicken price
        private static Int32 chickenPrice = 10;
        public Int32 getPrice() { return chickenPrice; }


        public static void changePrice(Int32 price)
        {
            if (price < chickenPrice)
            {
                // a price cut
                // there is at least a subscriber 
                if (priceCut != null)
                {
                    priceCut(price); 	// emit event to subscribers
                    //Increment the price cut counter
                    priceCutCounter++;
                    //Indicates if there is a pricecut                 
                    priceCutBool = true;
                }

            }
            else
            {
                //Set this to false if there is no price cut
                priceCutBool = false;
            }
            //Set the chicken price to the new price
            chickenPrice = price;

        }

        // Generate a random price
        private static int pricingModel()
        {
            return rng.Next(5, 20);
        }

        public void farmerFunc()
        {
            
            while(priceCutCounter <10)
            {
                Thread.Sleep(500);
                // Take the order from the queue of the orders;
                // Decide the price based on the orders
                Int32 p = ChickenFarm.pricingModel();
                // Console.WriteLine("New Price is {0}", p);
                ChickenFarm.changePrice(p);

                Console.WriteLine("New Price {0}",p);

                //Read the cell if the multi cell buffer is not empty
                if (MultiCellBuffer.counter != 0)
                {
                    //Initialise a new order process object
                    OrderProcessing orderProcess = new OrderProcessing();
                    //Read the cell
                    String orderStr = MultiCellBuffer.getCell();
                    //Decode the order string into order object
                    Order order = ChickenFarm.decode(orderStr);
                    //Start a new orderprocess thread
                    Thread thread = new Thread(() => orderProcess.processOrder(order));
                    thread.Name = "Order " + ChickenFarm.orderNum;
                    thread.Start();
                    //Increment the order number
                    ChickenFarm.orderNum = ChickenFarm.orderNum + 1;
                }
                
            }
        }

        public static Order decode(String orderStr)
        {
            //Split the string on "_" and assign the string to its corresponding order variable
            Order order = new Order();
            String[] splitOrder = orderStr.Split('_');
            order.SenderId = splitOrder[0];
            order.CardNo = Convert.ToInt32(splitOrder[1]);
            order.Amount = Convert.ToInt32(splitOrder[2]);
            order.TimeStamp = splitOrder[3];
            order.ChickenPrice = Convert.ToInt32(splitOrder[4]);
            return order;
        }

        

    }
}
