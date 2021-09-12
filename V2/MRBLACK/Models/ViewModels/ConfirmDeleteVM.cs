using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRBLACK.Models.ViewModels
{
    public class ConfirmDeleteVM
    {
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string Title { get; set; }
        public int? PkFieldIntVal { get; set; }
        public string PkFieldStrVal { get; set; }
    }
}