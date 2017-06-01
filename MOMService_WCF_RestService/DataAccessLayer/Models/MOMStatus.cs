using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
//using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DataAccessLayer.Models
{
    public class MOMStatus
    {
        public string UserId { get; set; }
        public string UserName { get; set; }

        //[DisplayName("User")]
        //[Required(ErrorMessage = "Select User")]
        public string SelectedUser { get; set; }
        public IList<SelectListItem> User { get; set; }


        public string SelectedCount { get; set; }
        public IList<SelectListItem> Count { get; set; }

        //    public Home()
        //{
        //    this.Activities = new List<ActivityModel>();
        //}


        public List<ActivityModel> Activities { get; set; }

        //[DisplayName("Date")]
        //[Required(ErrorMessage = "Select Date")]
        //public DateTime? Date { get; set; }
        public string Date { get; set; }
        public string Result { get; set; }

        public string LastDate { get; set; }
        public string PendingStatus { get; set; }
    }

    public class ActivityModel
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Date { get; set; }
        //[DisplayName("Task")]
        //[Required(ErrorMessage = "Required")]
        public string Task { get; set; }

        //[DisplayName("Hours")]
        //[Required(ErrorMessage = "Required")]
        //[RegularExpression(@"^[0-9]$", ErrorMessage = "Invalid")]
        //[Range(01, 09, ErrorMessage = "Invalid")]
        public string Hours { get; set; }

        //[DisplayName("Percentage")]
        //[Required(ErrorMessage = "Required")]
        //[RegularExpression(@"^(?:100|[1-9]?[0-9])$", ErrorMessage = "Invalid")]
        //[Range(01, 100, ErrorMessage = "Invalid")]
        public string Percentage { get; set; }

        //public string Project { get; set; }
        public int StatusId { get; set; }
        public string Status { get; set; }
        public bool IsChecked { get; set; }
    }

}
