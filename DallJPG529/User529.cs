using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DallJPG529.Servicios529;
namespace DallJPG529
{
    public class User529
    {
        public void CrearUsuario(string pass, string user, int dni)
        {
            ProviderJPG.Instancia.Add(pass, user, dni);
        }

        public void Login(string user, string pass, int dni)
        {
            ProviderJPG.Instancia.Ingre(user, pass, dni);
            if (ProviderJPG.Instancia.a == 1)
            {
            }
        }
    }
}
