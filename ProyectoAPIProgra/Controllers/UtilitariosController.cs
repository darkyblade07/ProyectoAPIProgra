using ProyectoAPIProgra.Entities;
using ProyectoAPIProgra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProyectoAPIProgra.Controllers
{
    public class UtilitariosController : ApiController
    {
        [HttpPost]
        [Route("api/RegistrarLog")]
        public void RegistrarLog(LogEnt entidad)
        {
            using (var bd = new ProyectoPrograAvanzadaEntities())
            {

                 bd.RegistrarLog(entidad.MensajeDeError, entidad.Origen, entidad.IdUsuario);
            }
        }
    }

}
