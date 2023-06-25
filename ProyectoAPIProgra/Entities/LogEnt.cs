using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoAPIProgra.Entities
{
    public class LogEnt
    {
        public DateTime FechaHora { get; set; }
        public string MensajeDeError { get; set; }
        public string Origen { get; set; }
        public int IdUsuario { get; set; }
      
    }
}