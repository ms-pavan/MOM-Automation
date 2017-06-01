using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DataAccessLayer.Models;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Implementations;
using System.Data;

namespace MOMService
{
     //NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetMOMProjects", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        IList<Home> GetMOMProjects();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetConfigurationData?project={project}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        IList<MOMStatus> GetConfigurationData(string project);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetConfigDataReport", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        IList<Reports> GetConfigDataReport();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "InsertUpdateData?operation={operation}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool InsertUpdateData(IList<ActivityModel> home, string operation);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetMOMData?startDate={startDate}&endDate={endDate}&status={selectedStatus}&project={project}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        IList<ActivityModel> GetMOMData(string startDate, string endDate, string selectedStatus, string project);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetLastDate?user={user}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string GetLastDate(string user);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetMOMPendingData?user={user}&status={statusId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        IList<ActivityModel> GetMOMPendingData(string user, string statusId);
    }

}
