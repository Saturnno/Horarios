using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("Meses")]
    public class Mes
    {
        [Key]
        public int Id { get; set; }
        [StringLength(250)]
        public string Nombre { get; set; }
    }
}
