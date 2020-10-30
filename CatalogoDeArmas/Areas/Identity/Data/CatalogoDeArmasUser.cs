using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CatalogoDeArmas.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the CatalogoDeArmasUser class
    public class CatalogoDeArmasUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "varchar(100)")]
        public string Nombre { get; set;  }

        [PersonalData]
        [Column(TypeName = "varchar(100)")]
        public string Apellido { get; set; }
    }
}
