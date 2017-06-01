using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace DataAccessLayer.Models
{
    public class Reports
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string StatusId { get; set; }
        public string StatusName { get; set; }
        public string SelectedStatus { get; set; }
        public IList<SelectListItem> Status { get; set; }
        public IList<ActivityModel> ReportsModel { get; set; }
        //public DataTable ReportsModel { get; set; }
    }
}
