using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRBLACK.Models.ViewModels
{
    public class CategoryWithServiceIndex
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public List<ServiceInIndexVm> Services { get; set; } = new List<ServiceInIndexVm>();
    }
}
