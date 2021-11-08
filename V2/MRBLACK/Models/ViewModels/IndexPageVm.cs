using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRBLACK.Models.ViewModels
{
    public class IndexPageVm
    {
        public List<SlideShowVm> SlideShow { get; set; } = new List<SlideShowVm>();
        public List<CategoryWithServiceIndex> categoryWithServices { get; set; }
        = new List<CategoryWithServiceIndex>();
        public List<ProvidersInIndexVm> Providers { get; set; }
        = new List<ProvidersInIndexVm>();
        public int Students { get; set; }
        public int CountProviders { get; set; }
        public int Books { get; set; }
        public int Services { get; set; }

    }
}
