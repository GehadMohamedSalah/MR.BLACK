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

    }
}
