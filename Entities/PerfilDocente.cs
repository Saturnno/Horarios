using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("PerfilesDocentes")]
    public class PerfilDocente
    {
        [Key]
        public int Id { get; set; }
        public int? MaestroId { get; set; }
        [Display(Name = "Materia")]
        public int? MateriaId { get; set; }
        [ForeignKey("MaestroId")]
        public Maestro Maestro { get; set; }
        [ForeignKey("MateriaId")]
        public Materia Materia { get; set; }
    }
}
