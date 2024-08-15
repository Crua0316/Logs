using System;
using System.ComponentModel.DataAnnotations;

namespace Logs.Models
{
    public class EventLog
    {
        public int Id { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        [StringLength(255)]
        public string Descripcion { get; set; }

        [Required]
        [StringLength(50)]
        public string TipoEvento { get; set; }
    }
}

