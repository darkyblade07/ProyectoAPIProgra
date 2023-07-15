using ProyectoAPIProgra.Entities;
using ProyectoAPIProgra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Net.Http;
using System.Net.Mail;

namespace ProyectoAPIProgra.Controllers
{
    public class UserController : ApiController
    {
        UtilitariosModel util = new UtilitariosModel();


        [HttpPost]
        [Route("api/IniciarSesion")]
       
        public UserEnt IniciarSesion(UserEnt entidad)
        {
            using (var bd = new ProyectoPrograAvanzadaEntities())
            {
                var user = bd.users.FirstOrDefault(u => u.Username == entidad.Username && u.Password == entidad.Password);

                if (user != null)
                {
                    var userEnt = new UserEnt
                    {
                        Username = user.Username,
                        Password = user.Password,
                    };

                    return userEnt;
                }
                else
                {
                    return null;
                }
            }
        }




        [HttpPost]
        [Route("api/RegistrarUsuario")]
        public int RegistrarUsuario(UserEnt entidad)
        {
            using (var bd = new ProyectoPrograAvanzadaEntities())
            {

                var newUser = new users
                {
                    Name = entidad.Name,
                    Email = entidad.Email,
                    Username = entidad.Username,
                    Password = entidad.Password,
                    Role_ID = 1,
                    State = true
                };

                bd.users.Add(newUser);
                bd.SaveChanges();

                return newUser.ID;
            }
            //return bd.RegistrarUsuario(entidad.Email, entidad.Password, entidad.Name); 
        }

        [HttpPost]
        [Route("api/RecuperarContrasenna")]
        public bool RecuperarContrasenna(UserEnt entidad)
        {
            using (var bd = new ProyectoPrograAvanzadaEntities())
            {
                var datos = (from x in bd.users
                             where x.Email == entidad.Email
                                && x.State == true
                             select x).FirstOrDefault();

                if (datos != null)
                {
                    string password = util.CreatePassword();
                    datos.Password = util.Encrypt(password);
                  
                    bd.SaveChanges();

                    string mensaje = "Hello " + datos.Name + ". a new password has been generated, please store it somewhere since you are NOT be able to change this password again, unless you recover it again. Password: " + password;
                    util.SendEmail(datos.Email, "Recuperar Contraseña", mensaje);
                    return true;
                }

                return false;
            }
        }

    }
}

    
