using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MRBLACK.Models.Database
{
    public partial class UserVisit
    {
        [Key]
        public int Id { get; set; }
        [Column("IPAddress")]
        public string Ipaddress { get; set; }
        [Column("OS")]
        public string Os { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string VisitDateTime { get; set; }
        public string Location { get; set; }
    }
}
