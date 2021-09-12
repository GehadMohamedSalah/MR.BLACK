using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MRBLACK.Models.Database
{
    [Table("UserVisit")]
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
