using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace DataAccessLayer.Models
{
    public class Home
    {
        public string ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string SelectedProject { get; set; }
        public IList<SelectListItem> Project { get; set; }
    }
}
