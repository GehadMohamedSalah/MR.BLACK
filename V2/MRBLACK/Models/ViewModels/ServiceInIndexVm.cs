using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRBLACK.Models.ViewModels
{
    public class ServiceInIndexVm
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal TotalPrice { get; set; }
        public string LeefCategoryName { get; set; }
        public string ProviderName { get; set; }
        public string ProviderImageUrl { get; set; }
        public int ProviderRate { get; set; }
    }
}
