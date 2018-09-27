using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("Unidades")]
    public class Unidad
    {
        public int Id { get; set; }
        [StringLength(150)]
        public string Nombre { get; set; }
        [StringLength(256)]
        public string Direccion { get; set; }
        [StringLength(100)]
        public string Director { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Telefono { get; set; }
        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }
    }
}
