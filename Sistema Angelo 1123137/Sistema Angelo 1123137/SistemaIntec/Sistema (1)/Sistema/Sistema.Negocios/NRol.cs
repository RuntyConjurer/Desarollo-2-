using Sistema.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Negocios
{
    public class NRol
    {
        public static DataTable Listar()
        {
            //Instanciar la clase DCategoria
            DRol datos = new DRol();
            return datos.Listar();
        }
    }
}
