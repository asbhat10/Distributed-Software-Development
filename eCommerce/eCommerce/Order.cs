using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce
{
    //Order class to place the order
    class Order
    {
        //Retailer id who placed the order
        private String senderId;
        //Credit card number of the retailer
        private int cardNo;
        //Number of chickens ordered
        private int amount;
        //Time at which the order was placed
        private String timeStamp;
        //Price of single unit of chicken
        private int chickenPrice;



        public string SenderId
        {
            get
            {
                return senderId;
            }

            set
            {
                senderId = value;
            }
        }

        public int CardNo
        {
            get
            {
                return cardNo;
            }

            set
            {
                cardNo = value;
            }
        }

        public int Amount
        {
            get
            {
                return amount;
            }

            set
            {
                amount = value;
            }
        }

        public string TimeStamp
        {
            get
            {
                return timeStamp;
            }

            set
            {
                timeStamp = value;
            }
        }

        public int ChickenPrice
        {
            get
            {
                return chickenPrice;
            }

            set
            {
                chickenPrice = value;
            }
        }
    }
}
