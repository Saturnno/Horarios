using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("CargasAcademicas")]
    public class CargaAcademica
    {
        [Key]
        public int Id { get; set; }
        public int? MaestroId { get; set; }
        public int? TrimestreId { get; set; }
        public int Año { get; set; }
        public int? GruposId { get; set; }
        public int? materiaId { get; set; }
        public int? GrupoId { get; set; }
        public int? TurnoId { get; set; }
        public int? ModuloId { get; set; }
        [ForeignKey("MaestroId")]
        public Maestro Maestro { get; set; }
        [ForeignKey("TrimestreId")]
        public Trimestre Trimestre { get; set; }
        [ForeignKey("GruposId")]
        public Grupo Grupos { get; set; }
        [ForeignKey("TurnosId")]
        public Turno Turno { get; set; }
        [ForeignKey("ModuloId")]
        public Modulo Modulo { get; set; }
    }
}
