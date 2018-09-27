using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entities
{
    [Table("ProgramasEducativos")]
    public class ProgramaEducativo
    {
        [Key]
        public int Id { get; set; }
        public int? DepartamentoId { get; set; }
        [Display(Name = "Nombre")]
        [StringLength(250)]
        public string Nombre { get; set; }
        [Display(Name = "Abreviatura")]
        [StringLength(20)]
        public string Abreviatura { get; set; }
        [Display(Name = "Coordinador P.E. ")]
        [StringLength(120)]
        public string CordinadorAcademico { get; set; }
        public int? UnidadId { get; set; }
        [ForeignKey("Unidad")]
        public Unidad Unidad { get; set; }
        [ForeignKey("DepartamentoId")]
        public Departamento Departamento { get; set; }
    }
}
