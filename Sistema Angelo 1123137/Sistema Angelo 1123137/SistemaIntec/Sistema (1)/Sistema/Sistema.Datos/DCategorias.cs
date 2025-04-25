using Sistema.datos;
using Sistema.Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Datos
{
    public class DCategorias
    {
        //Metodo para listar las categorias
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
                SqlCommand Comando = new SqlCommand("categoria_listar", sqlConnection);
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

        //Insertar Categorias
        public string Insertar(Categoria categoria)
        {
            //Necesitamos un objeto de tipo SqlConnection para conectarnos a la BD
            SqlConnection sqlConnection = new SqlConnection();
            string respuesta = "";

            try
            {
                //traemos la cadena de conexion
                sqlConnection = Conexion.getInstancia().CrearConexion();
                //configurar el comando a la base de datos
                SqlCommand Comando = new SqlCommand("categoria_insertar", sqlConnection);
                Comando.CommandType = CommandType.StoredProcedure;
                //configuramos los parametros
                Comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = categoria.Nombre;
                Comando.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = categoria.Descripcion;
                //abrimos la conexion
                sqlConnection.Open();
                //Ejecutar el comando
                respuesta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo insertar el registro";
            }
            catch (Exception ex)
            {

                respuesta = ex.Message;
            }
            finally
            {
                //siempre debemos cerrar la conexion una vez terminemos la ejecucion
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }

            return respuesta;
        }//fin del metodo Insertar

        //Buscar una Categoria
        public DataTable Buscar(string valor)
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
                SqlCommand Comando = new SqlCommand("categoria_buscar", sqlConnection);
                //le debemos decir que es un procedimiento almacenado lo que va a ejecutar
                Comando.CommandType = CommandType.StoredProcedure;
                //pasamos el parametro
                Comando.Parameters.Add("@valor", SqlDbType.VarChar).Value = valor;
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
        }//fin del metodo buscar

        //Actualizar una categoria
        public string Actualizar(Categoria categoria)
        {
            //Necesitamos un objeto de tipo SqlConnection para conectarnos a la BD
            SqlConnection sqlConnection = new SqlConnection();
            string respuesta = "";

            try
            {
                //traemos la cadena de conexion
                sqlConnection = Conexion.getInstancia().CrearConexion();
                //configurar el comando a la base de datos
                SqlCommand Comando = new SqlCommand("categoria_actualizar", sqlConnection);
                Comando.CommandType = CommandType.StoredProcedure;
                //configuramos los parametros
                Comando.Parameters.Add("@idcategoria", SqlDbType.Int).Value = categoria.IdCategoria;
                Comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = categoria.Nombre;
                Comando.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = categoria.Descripcion;
                //abrimos la conexion
                sqlConnection.Open();
                //Ejecutar el comando
                respuesta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo actualizar el registro";
            }
            catch (Exception ex)
            {

                respuesta = ex.Message;
            }
            finally
            {
                //siempre debemos cerrar la conexion una vez terminemos la ejecucion
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }

            return respuesta;
        }//fin del metodo Actualizar

        //Eliminar una Categoria
        public string Eliminar(int id)
        {
            //Necesitamos un objeto de tipo SqlConnection para conectarnos a la BD
            SqlConnection sqlConnection = new SqlConnection();
            string respuesta = "";
            try
            {
                //traemos la cadena de conexion
                sqlConnection = Conexion.getInstancia().CrearConexion();
                //configurar el comando a la base de datos
                SqlCommand Comando = new SqlCommand("categoria_eliminar", sqlConnection);
                Comando.CommandType = CommandType.StoredProcedure;
                //configuramos los parametros
                Comando.Parameters.Add("@idcategoria", SqlDbType.Int).Value = id;
                //abrimos la conexion
                sqlConnection.Open();
                //Ejecutar el comando
                respuesta = Comando.ExecuteNonQuery() >= 1 ? "OK" : "No se pudo eliminar el registro";
            }
            catch (Exception ex)
            {

                respuesta = ex.Message;
            }
            finally
            {
                //siempre debemos cerrar la conexion una vez terminemos la ejecucion
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
            return respuesta;
        }//fin del metodo Eliminar

        //Activar Categorias
        public string Activar(int id)
        {
            //Necesitamos un objeto de tipo SqlConnection para conectarnos a la BD
            SqlConnection sqlConnection = new SqlConnection();
            string respuesta = "";
            try
            {
                //traemos la cadena de conexion
                sqlConnection = Conexion.getInstancia().CrearConexion();
                //configurar el comando a la base de datos
                SqlCommand Comando = new SqlCommand("categoria_activar", sqlConnection);
                Comando.CommandType = CommandType.StoredProcedure;
                //configuramos los parametros
                Comando.Parameters.Add("@idcategoria", SqlDbType.Int).Value = id;
                //abrimos la conexion
                sqlConnection.Open();
                //Ejecutar el comando
                respuesta = Comando.ExecuteNonQuery() >= 1 ? "OK" : "No se pudo activar el registro";
            }
            catch (Exception ex)
            {

                respuesta = ex.Message;
            }
            finally
            {
                //siempre debemos cerrar la conexion una vez terminemos la ejecucion
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
            return respuesta;
        }//fin del metodo Activar

        //Desactivar Categorias
        public string Desactivar(int id)
        {
            //Necesitamos un objeto de tipo SqlConnection para conectarnos a la BD
            SqlConnection sqlConnection = new SqlConnection();
            string respuesta = "";
            try
            {
                //traemos la cadena de conexion
                sqlConnection = Conexion.getInstancia().CrearConexion();
                //configurar el comando a la base de datos
                SqlCommand Comando = new SqlCommand("categoria_desactivar", sqlConnection);
                Comando.CommandType = CommandType.StoredProcedure;
                //configuramos los parametros
                Comando.Parameters.Add("@idcategoria", SqlDbType.Int).Value = id;
                //abrimos la conexion
                sqlConnection.Open();
                //Ejecutar el comando
                respuesta = Comando.ExecuteNonQuery() >= 1 ? "OK" : "No se pudo desactivar el registro";
            }
            catch (Exception ex)
            {

                respuesta = ex.Message;
            }
            finally
            {
                //siempre debemos cerrar la conexion una vez terminemos la ejecucion
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
            return respuesta;
        }//fin del metodo Eliminar

        //Determinar si una Categoria Existe
        public string Existe(string valor)
        {
            //Necesitamos un objeto de tipo SqlConnection para conectarnos a la BD
            SqlConnection sqlConnection = new SqlConnection();
            string respuesta = "";

            try
            {
                //traemos la cadena de conexion
                sqlConnection = Conexion.getInstancia().CrearConexion();
                //configurar el comando a la base de datos
                SqlCommand Comando = new SqlCommand("categoria_existe", sqlConnection);
                Comando.CommandType = CommandType.StoredProcedure;
                //configuramos los parametros
                Comando.Parameters.Add("@valor", SqlDbType.Int).Value = valor;
                //abrimos la conexion
                sqlConnection.Open();
                //Ejecutar el comando
                respuesta = Comando.ExecuteNonQuery() == 1 ? "1" : "0";
            }
            catch (Exception ex)
            {

                respuesta = ex.Message;
            }
            finally
            {
                //siempre debemos cerrar la conexion una vez terminemos la ejecucion
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
            return respuesta;
        }
    }
}
