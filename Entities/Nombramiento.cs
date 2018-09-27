using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("Nombramientos")]
    public class Nombramiento
    {
        [Key]
        public int Id { get; set; }
        [StringLength(250)]
        public string Nombre { get; set; }
        public decimal MaxHoras { get; set; }
    }
}
