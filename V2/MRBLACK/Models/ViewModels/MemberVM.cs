using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRBLACK.Models.ViewModels
{
    public class MemberVM
    {
        public string Name { get; set; }
        public string MembershipNumber { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string MembershipType { get; set; }
        public string Gender { get; set; }
        public decimal Balance { get; set; }
    }
}
