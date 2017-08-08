using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Assignment5
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        bool checkUserCredentials(string id, string password);

        [OperationContract]
        string checkUserCredentialsForStaff(string id, string password);

        [OperationContract]
        string[] getLatLong(string zipcode);

        [OperationContract]
        String SignUpMembers(String id, String password, String name, String cardNo);

        [OperationContract]
        String AddBooks(String isbn, String title, String description);

        [OperationContract]
        ArrayList getAllBooks();

        [OperationContract]
        String[] getBookDetails(String name);

        [OperationContract]
        Boolean addBorrowed(String title, String userId);

        [OperationContract]
        string transformationMembers();

        [OperationContract]
        string transformationBooks();
    }
}
