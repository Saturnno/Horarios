using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("Grupos")]
    public class Grupo
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nombre del grupo")]
        public string Nombre { get; set; }
        public int Ano { get; set; }
        public string Aula { get; set; }
        public int? TrimestreId { get; set; }

        public int? ProgramaEducativoId { get; set; }

        public int? TurnoId { get; set; }
        [ForeignKey("TurnoId")]
        public Turno Turno { get; set; }
        [ForeignKey("ProgramaEducativoId")]
        public ProgramaEducativo ProgramaEducativo { get; set; }
        [ForeignKey("TrimestreId")]
        public Trimestre Trimestre { get; set; }
    }
}
