using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MRBLACK.Models.Database
{
    [Table("RequestServiceStep")]
    public partial class RequestServiceStep
    {
        [Key]
        public int Id { get; set; }
        public string StepDesc { get; set; }
    }
}
