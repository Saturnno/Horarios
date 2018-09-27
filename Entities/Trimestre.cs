using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("Trimestres")]
    public class Trimestre
    {
        [Key]
        public int Id { get; set; }
        [StringLength(250)]
        public string Nombre { get; set; }
        public int? MesId { get; set; }
        [ForeignKey("MesId")]
        public Mes Mes { get; set; }
    }
}
