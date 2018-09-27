using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entities
{
    public class GrupoDisponibilidad
    {
        [Key]
        public int Id { get; set; }
        public int? GrupoId { get; set; }
        public int? ModuloId { get; set; }
        public int? MaestroId { get; set; }
        public int? TrimestreId { get; set; }
        public int? MateriaId { get; set; }
        public int Dia { get; set; }
        [ForeignKey("MaestroId")]
        public Maestro Maestro { get; set; }
        [ForeignKey("MateriaId")]
        public Materia Materia { get; set; }
        [ForeignKey("GrupoId")]
        public Grupo Grupo { get; set; }
        [ForeignKey("ModuloId")]
        public Modulo Modulo { get; set; }
        [ForeignKey("TrimestreId")]
        public Trimestre Trimestre { get; set; }
    }
}