using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using log4net;
using System.Reflection;

namespace DataAccessLayer.Implementations
{
    public class DataAccess : IDataAccess
    {
        private static readonly log4net.ILog log =
    log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        //Get configuration data

        public IList<Home> GetMOMProjects()
        {
            log.Info("Log started");
            IList<Home> list = new List<Home>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["STRMDConnectionString"].ConnectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("GetMOMProjects", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sDr = command.ExecuteReader();
                    if (sDr != null)
                    {
                        while (sDr.Read())
                        {
                            Home model = new Home();
                            model.ProjectId = Convert.ToString(sDr["ProjectId"]);
                            model.ProjectName = Convert.ToString(sDr["ProjectName"]);
                            list.Add(model);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                
                //throw ex;
                log.Error(ex.Message,ex);
            }
            return list;
        }
        
        public IList<MOMStatus> GetConfigurationData(string Project)
        { 
        IList<MOMStatus> list=new List<MOMStatus>();
        try
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["STRMDConnectionString"].ConnectionString))
            {
                conn.Open();
                //SqlCommand command = new SqlCommand("GetConfigDataMOM", conn);
                SqlCommand command = new SqlCommand("GetConfigDataMOMProject", conn);
                command.Parameters.AddWithValue("@ProjectId",Convert.ToInt32(Project));
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader sDr = command.ExecuteReader();
                if (sDr != null)
                {
                    while (sDr.Read())
                    {
                        MOMStatus model = new MOMStatus();
                        model.UserId = Convert.ToString(sDr["UserID"]);
                        model.UserName = Convert.ToString(sDr["UserName"]);
                        list.Add(model);
                    }
                }

            }
        }
        catch (Exception ex)
        {
            //throw ex;
            log.Error(ex.Message, ex);
        }
        return list;
        }

        public IList<Reports> GetConfigDataReport()
        {
            IList<Reports> list = new List<Reports>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["STRMDConnectionString"].ConnectionString))
                {
                    conn.Open();
                    //SqlCommand command = new SqlCommand("GetConfigDataMOM", conn);
                    SqlCommand command = new SqlCommand("GetConfigDataReport", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sDr = command.ExecuteReader();
                    if (sDr != null)
                    {
                        while (sDr.Read())
                        {
                            Reports  model = new Reports();
                            model.StatusId = Convert.ToString(sDr["StatusID"]);
                            model.StatusName = Convert.ToString(sDr["Status"]);
                            list.Add(model);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                //throw ex;
                log.Error(ex.Message, ex);
            }
            return list;
        }

        //Insert/Update daily status
        public bool InsertUpdateData(string data, string operation)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["STRMDConnectionString"].ConnectionString))
                {
                    conn.Open();
                    //SqlCommand command = new SqlCommand("InsertMOMDetails", conn);
                    SqlCommand command = new SqlCommand("InsertUpdateMOMDetails", conn); 
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@XmlData", data);
                    command.Parameters.AddWithValue("@Operation", operation);
                    //command.CommandTimeout = 0;
                    int rec = command.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                //throw ex;                
                return false;

            }
            return true;
        }

        //Get MOM data based on selected date range
        public IList<ActivityModel> GetMOMData(string startDate, string endDate, string status, string project)
        {
            IList<ActivityModel> list = new List<ActivityModel>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["STRMDConnectionString"].ConnectionString))
                {
                    conn.Open();
                    //SqlCommand command = new SqlCommand("GetMOMData", conn);
                    SqlCommand command = new SqlCommand("GetMOMDataProject", conn); 
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@StartDate", Convert.ToDateTime(startDate).ToShortDateString());
                    command.Parameters.AddWithValue("@EndDate", Convert.ToDateTime(endDate).ToShortDateString());
                    //command.Parameters.AddWithValue("@StatusId", Convert.ToInt32(status));
                    command.Parameters.AddWithValue("@StatusId", status);
                    command.Parameters.AddWithValue("@ProjectId", Convert.ToInt32(project));
                    SqlDataReader sDr = command.ExecuteReader();
                    if (sDr != null)
                    {
                        while (sDr.Read())
                        {
                            ActivityModel model = new ActivityModel();
                            model.UserName = Convert.ToString(sDr["UserName"]);
                            model.Date = Convert.ToString(sDr["Date"]);
                            model.Task = Convert.ToString(sDr["Task"]);
                            model.Hours = Convert.ToString(sDr["Hours"]);
                            model.Percentage = Convert.ToString(sDr["Percentage"]);
                            model.Status = Convert.ToString(sDr["Status"]);
                            list.Add(model);
                        }
                    }
                    
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                
                //throw ex;
                log.Error(ex.Message, ex);
            }

            return list;
        }

        //Get Last Updated Date
        public string GetLastDate(int User)
        {
            string lastDate = string.Empty;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["STRMDConnectionString"].ConnectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("GetMOMLastDate", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@User", User);
                    var result = command.ExecuteScalar();
                    if (result!=null && result!=string.Empty)
                        lastDate = Convert.ToDateTime(result).ToLongDateString();
                    conn.Close();
                }

               
            }
            catch (Exception ex)
            {

                //throw ex;
                log.Error(ex.Message, ex);
            }

            return lastDate;
        }

        //Get Pending MOM Tasks
        public IList<ActivityModel> GetMOMPendingData(int User, int StatusId)
        {
            List<ActivityModel> list = new List<ActivityModel>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["STRMDConnectionString"].ConnectionString))
                {
                    conn.Open();
                    //SqlCommand command = new SqlCommand("GetMOMData", conn);
                    SqlCommand command = new SqlCommand("GetMOMPending", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@User", User);
                    command.Parameters.AddWithValue("@StatusId", StatusId);
                    SqlDataReader sDr = command.ExecuteReader();
                    if (sDr != null)
                    {
                        while (sDr.Read())
                        {
                            ActivityModel model = new ActivityModel();
                            model.ID = Convert.ToInt32(sDr["ID"]);
                            model.Task = Convert.ToString(sDr["Task"]);
                            model.Hours = Convert.ToString(sDr["Hours"]);
                            model.Percentage = Convert.ToString(sDr["Percentage"]);
                            list.Add(model);
                        }
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {

                //throw ex;
                log.Error(ex.Message, ex);
            }

            return list;
        }

    }
}
