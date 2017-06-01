using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.Models;
using System.Data;

namespace DataAccessLayer.Interfaces
{
    public interface IDataAccess
    {
        IList<Home> GetMOMProjects();
        IList<MOMStatus> GetConfigurationData(string project);
        IList<Reports> GetConfigDataReport();
        bool InsertUpdateData(string data,string operation);
        IList<ActivityModel> GetMOMData(string startDate, string endDate, string selectedStatus, string project);

        string GetLastDate(int user);
        IList<ActivityModel> GetMOMPendingData(int user, int statusId);
    }
}
