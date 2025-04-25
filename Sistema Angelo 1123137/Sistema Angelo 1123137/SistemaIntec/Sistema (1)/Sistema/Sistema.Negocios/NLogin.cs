using Sistema.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Negocios
{
    public class NLogin
    {
        public static DataTable Login (String email, string clave)
        {
            DLogin dlogin = new DLogin();
            return dlogin.Login(email, clave);
        }
    }
}
