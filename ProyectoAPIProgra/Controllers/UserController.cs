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
    public class UserController : ApiController
    {
        [HttpPost]
        [Route("api/IniciarSesion")]
        public IniciarSesion_Result IniciarSesion(UserEnt entidad)
        {
            using (var bd = new ProyectoPrograAvanzadaEntities())
            {
                return bd.IniciarSesion(entidad.Email, entidad.Password).FirstOrDefault();
            }
        }


        [HttpPost]
        [Route("api/RegistrarUsuario")]
        public int RegistrarUsuario(UserEnt entidad)
        {
            using (var bd = new ProyectoPrograAvanzadaEntities())
            {

                return bd.RegistrarUsuario(entidad.Email, entidad.Password, entidad.Name);
            }
        }
        }

    }
