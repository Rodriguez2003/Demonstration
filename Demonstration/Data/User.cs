using System;
using System.ComponentModel.DataAnnotations;

namespace Demonstration.Data
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }
        [StringLength(50)]
        public string Apellido { get; set; }
        public DateTime FechaCumpleaños { get; set; }
        public bool Estado { get; set; } = true;
    }
}
