using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MRBLACK.Models.Database
{
    public partial class Group
    {
        [Key]
        public int Id { get; set; }
        [Remote("IsUniqueRow", "Group", ErrorMessage = "لا يمكن تكرار الاسم", AdditionalFields = nameof(Id))]
        public string ArName { get; set; }
        [Remote("IsUniqueRow", "Group", ErrorMessage = "لا يمكن تكرار الاسم", AdditionalFields = nameof(Id))]
        public string EnName { get; set; }
        public int? DptCountryId { get; set; }
        public int? DptUniversityId { get; set; }
        public int? DptCollegeId { get; set; }
        public int? DepartmentId { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        public virtual Department Department { get; set; }
    }
}
