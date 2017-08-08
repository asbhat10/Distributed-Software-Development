using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace eCommerce
{
    static class MultiCellBuffer
    {
        public static String[] buffer = new String[2];
        public static int counter = 0;
        private static Semaphore get = new Semaphore(0, 2);
        private static Semaphore set = new Semaphore(2, 2);

        public static void setCell(String order)
        {
            //Wait for the writable cell to be available
            set.WaitOne();
            Console.WriteLine("Thread {0} enters the set semaphore.", Thread.CurrentThread.Name);
            //lock the cell buffer for the write function
            lock (buffer[counter])
            {
                //Write the order into the multicell buffer
                buffer[counter] = order;
                //Release the semaphore to read from the cell
                get.Release();
                //increment the counter to the next index
                counter++;
            }
            
            
        }

        public static String getCell()
        {
            //wait for the cell to be available to read
            get.WaitOne();
            String order = "";
            Console.WriteLine("CellBuffer is read.");
            //lock the cell to read from it
            lock (buffer[counter-1])
            {
                //Read the order string from the cell buffer
                order = buffer[counter-1];
                counter--;
                //Release a cell tobe available to write
                set.Release();
                //return the order         
                return order;
            }
            
            
        }

    }
}
