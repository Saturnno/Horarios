using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("Materias")]
    public class Materia
    {
        public int Id { get; set; }
        public int? CategoriaId { get; set; }
        [StringLength(15)]
        public string Clave { get; set; }
        [Display(Name = "Nombre Materia")]
        [StringLength(250)]
        public string Nombre { get; set; }
        [StringLength(15)]
        public string Seriacion { get; set; }
        public int Creditos { get; set; }
        public decimal Horas { get; set; }
        [Display(Name = "Tipo Calificacion")]
        [StringLength(20)]
        public string TipoCalificacion { get; set; }
        [ForeignKey("CategoriaId")]
        public Categoria Categoria { get; set; }
    }
}
