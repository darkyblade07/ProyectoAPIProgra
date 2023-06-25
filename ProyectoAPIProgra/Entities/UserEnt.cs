using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoAPIProgra.Entities
{
    public class UserEnt
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool State { get; set; }
        public int RolID { get; set; }
        public string ConfirmPassword { get; set; }

        public string RoleName { get; set; }
    }
}