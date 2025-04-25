using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Sistema.Entidad;
using System.Threading.Tasks;

namespace Sistema.datos
{
    internal class Conexion
    {
        // pametros apra conectarnos a la base de datos
        private string Base;
        private string Servidor;
        private string Usuario;
        private string Clave;
        private bool Seguridad;//esto indicas si nos conectamos con seguridad o no
        private static Conexion Con = null;

        //constructor
        private Conexion()
        {
            this.Base = "dbsistema"; // 
            this.Servidor = "DESKTOP-0SGG8PH";
            this.Usuario = ""; // No se usa
            this.Clave = "";   // No se usa
            this.Seguridad = true; //  usando Windows Authentication
        }
        //metodo para crear una instancia de la cadena de conexion
        public SqlConnection CrearConexion()
        {
            SqlConnection Cadena = new SqlConnection();
            try
            {
                Cadena.ConnectionString = "Server=" + this.Servidor + "; Database=" + this.Base + ";";
                if (this.Seguridad)
                {
                    Cadena.ConnectionString = Cadena.ConnectionString + "Integrated Security = SSPI";
                }
                else
                {
                    Cadena.ConnectionString = Cadena.ConnectionString + "User Id=" + this.Usuario + "; Password=" + this.Clave + ";";
                }
            }
            catch (Exception ex)
            {
                Cadena = null;
                throw ex;//informa cual fue el error
            }
            return Cadena;//retorna la cadena de conexion
        }
        //queremos que esta calse pueda ser manipulada desde afuera
        //crearemos un singleton
        public static Conexion getInstancia()
        {
            if (Con == null)
            {
                Con = new Conexion();
            }
            return Con;
        }
    }
}
