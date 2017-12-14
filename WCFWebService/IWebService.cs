using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFWebService
{
    [ServiceContract]
    public interface IWebService
    {
        [OperationContract]
        List<Person> GetAllPersons();
        Person GetPersonById(int id);
        string Create(string firstname, string lastname, int age, string gender);
        string Update(int id, string firstname, string lastname, int age, string gender);
        string Delete(int id);
    }
}
