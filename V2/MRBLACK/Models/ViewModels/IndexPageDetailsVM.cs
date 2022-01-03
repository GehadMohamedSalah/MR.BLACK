using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRBLACK.Models.ViewModels
{
    public class IndexPageDetailsVM
    {
        public string ControllerName { get; set; }
        public string SearchStr { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
