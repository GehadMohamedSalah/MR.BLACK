using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mr_Black.Database
{
    [NotMapped]
    public class AspNetUserRoles : IdentityUserRole<string>
    {
    }
}
