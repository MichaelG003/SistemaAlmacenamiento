using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; //Necesario para el uso de [Key]
using System.ComponentModel.DataAnnotations.Schema; //Necesario para el uso de [DatabaseGenerated]

namespace SistemaAlmacenamiento.Models
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public int Id { get; set; }
        public string Ruc { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }

        [Column(TypeName = "timestamptz")]
        public DateTime FechaCreacion { get; set; }
        
        [Column(TypeName = "timestamptz")]
        public DateTime? FechaModificacion { get; set; } // Nueva columna
        public bool Estado { get; set; } = true; // Por defecto, los clientes estarán activos
    }
}