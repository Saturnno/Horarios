using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("ProgramasEducativosDetalle")]
    public class ProgramaEducativoDetalle
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Programa Educativo")]
        public int? ProgamaEducativoId { get; set; }

        [Display(Name = "Materias")]
        public int? MateriaId { get; set; }
        [Display(Name = "Trimestre")]
        public int? TrimestreId { get; set; }
        [ForeignKey("ProgamaEducativoId")]
        public ProgramaEducativo ProgramaEducativo { get; set; }
        [ForeignKey("MateriaId")]
        public Materia Materia { get; set; }
        [ForeignKey("TrimestreId")]
        public Trimestre Trimestre { get; set; }
    }
}
