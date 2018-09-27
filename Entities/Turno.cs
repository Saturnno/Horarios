using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("Turnos")]
    public class Turno
    {
        [Key]
        public int Id { get; set; }
        [StringLength(250)]
        public string Nombre { get; set; }
    }
}
