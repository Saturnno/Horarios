using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("Departamentos")]
    public class Departamento
    {
        [Key]
        public int Id { get; set; }
        [StringLength(120)]
        public string Nombre { get; set; }
        [StringLength(120)]
        public string JefeDepartamento { get; set; }
        public int? UnidadId { get; set; }
        [ForeignKey("UnidadId")]
        public Unidad Unidad { get; set; }
    }
}
