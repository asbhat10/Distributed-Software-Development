using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace eCommerce
{
    class myApplication
    {

        static void Main(string[] args)
        {

            //Initialise the multi cell buffer
            for (int i = 0;i< 2; i++)
            {
                MultiCellBuffer.buffer[i] = "";
            }

            //Initialise the chicken farm object
            ChickenFarm chicken = new ChickenFarm();
            //Create a thread for chicken farm
            Thread farmer = new Thread(new ThreadStart(chicken.farmerFunc));
            farmer.Start();         // Start one farmer thread
            
            //Initialise the relailer object
            Retailer chickenstore = new Retailer();
            //Event handler when there is a price cut
            ChickenFarm.priceCut += new priceCutEvent(chickenstore.chickenOnSale);
            //Event handler when a order is completed
            OrderProcessing.completeOrder += new completeOrderEvent(chickenstore.completeOrder);
            //Create 5 threads for 5 retailers
            Thread[] retailers = new Thread[5];
            for (int i = 0; i < 5; i++)
            {   // Start N retailer threads
                retailers[i] = new Thread(new ThreadStart(chickenstore.retailerFunc));
                retailers[i].Name = "Retailer"+(i + 1).ToString();
                retailers[i].Start();
            }

            //Check if 10 price cuts have occured
            while (true)
            {
                if(ChickenFarm.priceCutCounter >= 10)
                {
                    //Terminate the chicken farm thread
                    farmer.Abort();
                    Console.WriteLine("Chicken farm thread terminated after 10 price cuts");
                    for (int i = 0; i < 5; i++)
                    {   
                        // Terminate N retailer threads
                        retailers[i].Abort();
                        Console.WriteLine("Retailer{0} farm thread terminated after 10 price cuts",i);
                    }
                    break;
                }
            }
        }
    }
}
