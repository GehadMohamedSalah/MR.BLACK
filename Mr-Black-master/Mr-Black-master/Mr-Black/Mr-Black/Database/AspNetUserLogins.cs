﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Mr_Black.Database
{
    [NotMapped]
    public partial class AspNetUserLogins : IdentityUserLogin<string>
    {
        [Key]
        [StringLength(128)]
        public string LoginProvider { get; set; }
        [Key]
        [StringLength(128)]
        public string ProviderKey { get; set; }
        public string ProviderDisplayName { get; set; }
    }
}
