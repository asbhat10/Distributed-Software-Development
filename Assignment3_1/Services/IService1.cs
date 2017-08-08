﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string[] getWeather5day(string zipcode);

        [OperationContract]
        string getStoreLocation(string zipcode, string storeName);

        [OperationContract]
        Boolean PutUsersToFile(String user, String password);

        [OperationContract]
        Boolean PutPlaceToFile(String place, String username);

        [OperationContract]
        Boolean GetUserFromFile(string user, string password);
    }

}
