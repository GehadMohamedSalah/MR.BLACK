using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using MRBLACK.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRBLACK.Models.ViewModels
{
    public class MembershipVM
    {
        public int Id { get; set; }
        public string EnName { get; set; }
        public string ArName { get; set; }
        public IFormFile FormFile { get; set; }
        public string ImgPath { get; set; }
        public int MembershipType { get; set; }
        public List<MembershipLink> MembershipLinkList { get; set; }
        public List<int> DeletedLinks { get; set; }
    }
}
