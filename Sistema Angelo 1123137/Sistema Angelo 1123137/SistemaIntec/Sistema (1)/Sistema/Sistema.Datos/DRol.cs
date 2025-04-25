using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema.datos;

namespace Sistema.Datos
{
    public class DRol
    {
        public DataTable Listar()
        {
            //Necesitamos un objeto de tipo DataTable para devolver el resultado de la consulta
            DataTable Tabla = new DataTable();
            //Necesitamos un objeto de tipo SqlDataReader para traer la data desde la BD
            SqlDataReader Resultado;
            //Necesitamos un objeto de tipo SqlConnection para conectarnos a la BD
            SqlConnection sqlConnection = new SqlConnection();

            try
            {
                //obtener la cadena de conexion
                sqlConnection = Conexion.getInstancia().CrearConexion();
                //crear el comando que le vamos a enviar a SQL Server
                SqlCommand Comando = new SqlCommand("rol_listar", sqlConnection);
                //le debemos decir que es un procedimiento almacenado lo que va a ejecutar
                Comando.CommandType = CommandType.StoredProcedure;
                //abrir la conexion
                sqlConnection.Open();
                //ejecutamos el comando
                Resultado = Comando.ExecuteReader();
                //no podemos manipular un SqlDataReader, por lo que debemos convertirlo
                //en un DataTable
                Tabla.Load(Resultado);
                //retornamos la Tabla
                return Tabla;
            }
            catch (Exception ex)
            {

                throw ex; //si ocurre un error, envialo para verlo
            }
            finally
            {
                //siempre debemos cerrar la conexion una vez terminemos la ejecucion
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }//Fin del Metodo Listar
    }
}
