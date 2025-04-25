using Sistema.Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema.Datos;

namespace Sistema.datos
{
    public class DUsuario
    {
        // listar los usuarios que hay en la base de datos
        public DataTable Listar()
        {
            //Para obtener los datos de la base de datos se necesita un sqldatareader

            SqlDataReader Resultado;

            //como necestiamos tornar un datatable vamos a crear un objeto
            DataTable Tabla = new DataTable();

            // creamos la conexion a la base de datos con un objeto
            SqlConnection SqlConnection = new SqlConnection();
            try
            {
                //obtener al cadena de conexion
                SqlConnection = Conexion.getInstancia().CrearConexion();
                //necestiamos un comando para enviara sqlserver
                SqlCommand Comando = new SqlCommand("usuario_listar", SqlConnection);
                //decirle que va a ejecutar un procedimiento almacenado
                Comando.CommandType = CommandType.StoredProcedure;
                //abrir la conexion
                SqlConnection.Open();
                //ejecutar el comando
                Resultado = Comando.ExecuteReader();
                //llenar la tabla con los datos, lo convertimos en un datatable
                Tabla.Load(Resultado);

                //retornar la tabla
                return Tabla;


            }
            catch (Exception ex)
            {

                throw ex;// si ocurre un error lo va a informar
            }
            finally
            {
                //cerrar la conexion a la base de datos
                if (SqlConnection.State == ConnectionState.Open)
                {
                    SqlConnection.Close();
                }
            }
        }//fin del metodo listar
        public DataTable Listar_Rol()
        {
            //Para obtener los datos de la base de datos se necesita un sqldatareader

            SqlDataReader Resultado;

            //como necestiamos tornar un datatable vamos a crear un objeto
            DataTable Tabla = new DataTable();

            // creamos la conexion a la base de datos con un objeto
            SqlConnection SqlConnection = new SqlConnection();
            try
            {
                //obtener al cadena de conexion
                SqlConnection = Conexion.getInstancia().CrearConexion();
                //necestiamos un comando para enviara sqlserver
                SqlCommand Comando = new SqlCommand("rol_listar", SqlConnection);
                //decirle que va a ejecutar un procedimiento almacenado
                Comando.CommandType = CommandType.StoredProcedure;
                //abrir la conexion
                SqlConnection.Open();
                //ejecutar el comando
                Resultado = Comando.ExecuteReader();
                //llenar la tabla con los datos, lo convertimos en un datatable
                Tabla.Load(Resultado);

                //retornar la tabla
                return Tabla;


            }
            catch (Exception ex)
            {

                throw ex;// si ocurre un error lo va a informar
            }
            finally
            {
                //cerrar la conexion a la base de datos
                if (SqlConnection.State == ConnectionState.Open)
                {
                    SqlConnection.Close();
                }
            }
        }//fin del metodo listar

        //buscar un usuario
        public DataTable Buscar(string valor)
        {
            //Para obtener los datos de la base de datos se necesita un sqldatareader
            SqlDataReader Resultado;
            //como necestiamos tornar un datatable vamos a crear un objeto
            DataTable Tabla = new DataTable();
            // creamos la conexion a la base de datos con un objeto
            SqlConnection SqlConnection = new SqlConnection();
            try
            {
                //obtener al cadena de conexion
                SqlConnection = Conexion.getInstancia().CrearConexion();
                //necestiamos un comando para enviara sqlserver
                SqlCommand Comando = new SqlCommand("usuario_buscar", SqlConnection);
                //decirle que va a ejecutar un procedimiento almacenado
                Comando.CommandType = CommandType.StoredProcedure;
                //enviar el parametro
                Comando.Parameters.Add("@valor", SqlDbType.VarChar).Value = valor;
                //abrir la conexion
                SqlConnection.Open();
                //ejecutar el comando
                Resultado = Comando.ExecuteReader();
                //llenar la tabla con los datos, lo convertimos en un datatable
                Tabla.Load(Resultado);
                //retornar la tabla
                return Tabla;

            }
            catch (Exception ex)
            {
                throw ex;// si ocurre un error lo va a informar
            }
            finally
            {
                //cerrar la conexion a la base de datos
                if (SqlConnection.State == ConnectionState.Open)
                {
                    SqlConnection.Close();
                }
            }
        }//fin del metodo buscar


        //insertar un usuario

        public string Insertar(Usuario usuario)
        {
            // como vamos a devolver un string, decalramos una variable donde tendremos ese valor
            string respuesta = "";
            // creamos la conexion a la base de datos con un objeto
            SqlConnection SqlConnection = new SqlConnection();
            try
            {

                // obtenemos la cadena de conexion
                SqlConnection = Conexion.getInstancia().CrearConexion();
                //necesitamos crear el comando
                SqlCommand Comando = new SqlCommand("usuario_insertar", SqlConnection);
                //decirle que va a ejecutar un procedimiento almacenado
                Comando.CommandType = CommandType.StoredProcedure;
                //enviar los parametros
                Comando.Parameters.Add("@idrol", SqlDbType.Int).Value = usuario.IdRol;
                Comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = usuario.Nombre;
                Comando.Parameters.Add("@tipo_documento", SqlDbType.VarChar).Value = usuario.TipoDocumento;
                Comando.Parameters.Add("@num_documento", SqlDbType.VarChar).Value = usuario.NumDocumento;
                Comando.Parameters.Add("@direccion", SqlDbType.VarChar).Value = usuario.Direccion;
                Comando.Parameters.Add("@telefono", SqlDbType.VarChar).Value = usuario.Telefono;
                Comando.Parameters.Add("@email", SqlDbType.VarChar).Value = usuario.Email;
                Comando.Parameters.Add("@clave", SqlDbType.VarChar).Value = usuario.Clave;



                //abrir la conexion
                SqlConnection.Open();
                //ejecutar el comando
                respuesta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo insertar el registro";


            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                //cerrar la conexion a la base de datos
                if (SqlConnection.State == ConnectionState.Open)
                {
                    SqlConnection.Close();
                }
            }
            return respuesta;

        }//fin del metodo insertar

        //editar un usuario

        public string Actualizar(Usuario usuario)
        {
            // como vamos a devolver un string, decalramos una variable donde tendremos ese valor
            string respuesta = "";
            // creamos la conexion a la base de datos con un objeto
            SqlConnection SqlConnection = new SqlConnection();
            try
            {

                // obtenemos la cadena de conexion
                SqlConnection = Conexion.getInstancia().CrearConexion();
                //necesitamos crear el comando
                SqlCommand Comando = new SqlCommand("usuario_actualizar", SqlConnection);
                //decirle que va a ejecutar un procedimiento almacenado
                Comando.CommandType = CommandType.StoredProcedure;
                //enviar los parametros
                Comando.Parameters.Add("@idusuario", SqlDbType.Int).Value = usuario.IdUsuario;
                Comando.Parameters.Add("@idrol", SqlDbType.Int).Value = usuario.IdRol;
                Comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = usuario.Nombre;
                Comando.Parameters.Add("@tipo_documento", SqlDbType.VarChar).Value = usuario.TipoDocumento;
                Comando.Parameters.Add("@num_documento", SqlDbType.VarChar).Value = usuario.NumDocumento;
                Comando.Parameters.Add("@direccion", SqlDbType.VarChar).Value = usuario.Direccion;
                Comando.Parameters.Add("@telefono", SqlDbType.VarChar).Value = usuario.Telefono;
                Comando.Parameters.Add("@email", SqlDbType.VarChar).Value = usuario.Email;
                Comando.Parameters.Add("@clave", SqlDbType.VarChar).Value = usuario.Clave;

                //abrir la conexion
                SqlConnection.Open();
                //ejecutar el comando
                respuesta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo Actualizar el registro";


            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                //cerrar la conexion a la base de datos
                if (SqlConnection.State == ConnectionState.Open)
                {
                    SqlConnection.Close();
                }
            }
            return respuesta;

        }//fin del metodo Actualizar

        //eliminar usuario

        public string Eliminar(int idusuario)
        {
            // como vamos a devolver un string, decalramos una variable donde tendremos ese valor
            string respuesta = "";
            // creamos la conexion a la base de datos con un objeto
            SqlConnection SqlConnection = new SqlConnection();
            try
            {
                // obtenemos la cadena de conexion
                SqlConnection = Conexion.getInstancia().CrearConexion();
                //necesitamos crear el comando
                SqlCommand Comando = new SqlCommand("usuario_eliminar", SqlConnection);
                //decirle que va a ejecutar un procedimiento almacenado
                Comando.CommandType = CommandType.StoredProcedure;
                //enviar los parametros
                Comando.Parameters.Add("@idusuario", SqlDbType.Int).Value = idusuario;
                SqlConnection.Open();
                //ejecutar el comando
                respuesta = Comando.ExecuteNonQuery() >= 1 ? "OK" : "No se pudo Eliminar el registro";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                //cerrar la conexion a la base de datos
                if (SqlConnection.State == ConnectionState.Open)
                {
                    SqlConnection.Close();
                }

            }
            return respuesta;
        }//fin del metodo eliminar



        //activar usuario
        public string Activar(int idusuario)
        {
            // como vamos a devolver un string, decalramos una variable donde tendremos ese valor
            string respuesta = "";
            // creamos la conexion a la base de datos con un objeto
            SqlConnection SqlConnection = new SqlConnection();
            try
            {
                // obtenemos la cadena de conexion
                SqlConnection = Conexion.getInstancia().CrearConexion();
                //necesitamos crear el comando
                SqlCommand Comando = new SqlCommand("usuario_activar", SqlConnection);
                //decirle que va a ejecutar un procedimiento almacenado
                Comando.CommandType = CommandType.StoredProcedure;
                //enviar los parametros
                Comando.Parameters.Add("@idusuario", SqlDbType.Int).Value = idusuario;
                //abrir la conexion
                SqlConnection.Open();
                //ejecutar el comando
                respuesta = Comando.ExecuteNonQuery() >= 1 ? "OK" : "No se pudo Activar el registro";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                //cerrar la conexion a la base de datos
                if (SqlConnection.State == ConnectionState.Open)
                {
                    SqlConnection.Close();
                }

            }
            return respuesta;
        }//fin del metodo activar

        public string Desactivar(int idusuario)
        {
            // como vamos a devolver un string, decalramos una variable donde tendremos ese valor
            string respuesta = "";
            // creamos la conexion a la base de datos con un objeto
            SqlConnection SqlConnection = new SqlConnection();
            try
            {
                // obtenemos la cadena de conexion
                SqlConnection = Conexion.getInstancia().CrearConexion();
                //necesitamos crear el comando
                SqlCommand Comando = new SqlCommand("usuario_desactivar", SqlConnection);
                //decirle que va a ejecutar un procedimiento almacenado
                Comando.CommandType = CommandType.StoredProcedure;
                //enviar los parametros
                Comando.Parameters.Add("@idusuario", SqlDbType.Int).Value = idusuario;
                //abrir la conexion
                SqlConnection.Open();
                //ejecutar el comando
                respuesta = Comando.ExecuteNonQuery() >= 1 ? "OK" : "No se pudo desactivar el registro";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                //cerrar la conexion a la base de datos
                if (SqlConnection.State == ConnectionState.Open)
                {
                    SqlConnection.Close();
                }

            }
            return respuesta;
        }//fin del metodo desactivar

        //metodo existe usuario
        public string Existe(string valor)
        {
            // como vamos a devolver un string, decalramos una variable donde tendremos ese valor
            string respuesta = "";
            // creamos la conexion a la base de datos con un objeto
            SqlConnection SqlConnection = new SqlConnection();
            try
            {
                // obtenemos la cadena de conexion
                SqlConnection = Conexion.getInstancia().CrearConexion();
                //necesitamos crear el comando
                SqlCommand Comando = new SqlCommand("usuario_existe", SqlConnection);
                //decirle que va a ejecutar un procedimiento almacenado
                Comando.CommandType = CommandType.StoredProcedure;
                //enviar los parametros
                Comando.Parameters.Add("@valor", SqlDbType.VarChar).Value = valor;
                //abrir la conexion
                SqlConnection.Open();
                //ejecutar el comando
                respuesta = Convert.ToString(Comando.ExecuteScalar());
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                //cerrar la conexion a la base de datos
                if (SqlConnection.State == ConnectionState.Open)
                {
                    SqlConnection.Close();
                }
            }
            return respuesta;
        }//fin del metodo existe



    }
}
