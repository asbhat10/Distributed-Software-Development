namespace eCommerce
{
    //Completed order class
    public class CompletedOrder
    {
        //If the order was successfully completed
        private string status;
        //Total amount of the order
        private double amount;
        //Retailer id of the order
        private string senderId;
        //Number of chickens ordered
        private int noOfChickens;
        //Credit card number of the Retailer
        private int cardNo;
        //Time at which the order was placed
        private string timeStamp;
        //Order number of the order
        private string orderNum;
        //Price of one unit of chicken
        private int chickenPrice;

        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public double Amount
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

        public int NoOfChickens
        {
            get
            {
                return noOfChickens;
            }

            set
            {
                noOfChickens = value;
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

        public string OrderNum
        {
            get
            {
                return orderNum;
            }

            set
            {
                orderNum = value;
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