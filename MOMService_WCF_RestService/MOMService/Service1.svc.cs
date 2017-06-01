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
using MOMService.Utilities;

namespace MOMService
{
     //NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class Service1 : IService1
    {
        private static readonly log4net.ILog log =
   log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        IDataAccess da;
        public IList<Home> GetMOMProjects()
        {
            log.Info("Started");
           da = new DataAccess();
           return da.GetMOMProjects();
        }

        public IList<MOMStatus> GetConfigurationData(string project)
        {
            da = new DataAccess();
            return da.GetConfigurationData(project);
        }

        public IList<Reports> GetConfigDataReport()
        {
            da = new DataAccess();
            return da.GetConfigDataReport();
        }

        public bool InsertUpdateData(IList<ActivityModel> listActModel, string operation)
        {
            string data = "";
            da = new DataAccess();
            List<ActivityModel> listAct = new List<ActivityModel>();
            listAct = listActModel.ToList();
            data = listAct.ListToXML();
            return da.InsertUpdateData(data, operation);
            
        }

        public IList<ActivityModel> GetMOMData(string startDate, string endDate, string selectedStatus, string project)
        {
            da = new DataAccess();
            return da.GetMOMData(startDate, endDate, selectedStatus, project);
        }

        public string GetLastDate(string user)
        {
            da = new DataAccess();
            return da.GetLastDate(Convert.ToInt32(user));
        }

        public IList<ActivityModel> GetMOMPendingData(string user, string statusId)
        {
            da = new DataAccess();
            return da.GetMOMPendingData(Convert.ToInt32(user), Convert.ToInt32(statusId));
        }
    }
}
