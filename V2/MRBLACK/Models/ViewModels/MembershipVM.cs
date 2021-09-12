using Microsoft.AspNetCore.Http;
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
        public bool IsProvider { get; set; }
        public List<MembershipLink> MembershipLinkList { get; set; }
        public List<int> DeletedLinks { get; set; }
    }
}
