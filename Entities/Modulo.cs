using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("Modulos")]
    public class Modulo
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Fecha Inicio")]
        public string FechaInicio { get; set; }
        [Display(Name ="Fecha Final")]
        public string FechaFinal { get; set; }
    }
}
