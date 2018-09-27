using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("Maestros")]
    public class Maestro
    {
        [Key]
        public int Id { get; set; }


        [Display(Name = "Nombre Del Maestro")]
        [StringLength(250)]
        public string Nombre { get; set; }
        [Display(Name = "Contrato Super")]
        [StringLength(250)]
        public string Contrato { get; set; }

        [Display(Name = "Contrato Confidencial")]
        [StringLength(250)]
        public string ContratoConfidencial { get; set; }
        public int? ProgramaEducativoId { get; set; }
        public int? UnidadId { get; set; }
        public int? DepartamentoId { get; set; }
        [StringLength(256)]
        public string Disponibilidad { get; set; }

        public int? NombramientoId { get; set; }
        public int Orden { get; set; }
        [ForeignKey("NombramientoId")]
        public Nombramiento Nombramiento { get; set; }
        [ForeignKey("UnidadId")]
        public Unidad Unidad { get; set; }
        [ForeignKey("DepartamentoId")]
        public Departamento Departamento { get; set; }
        [ForeignKey("ProgramaEducativoId")]
        public ProgramaEducativo ProgramaEducativo { get; set; }

    }
}
