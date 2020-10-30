using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoDeArmas.Models
{
    public class Arma
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(250)")]
        [Required]
        public string Nombre { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string Img { get; set; }

    }
}
