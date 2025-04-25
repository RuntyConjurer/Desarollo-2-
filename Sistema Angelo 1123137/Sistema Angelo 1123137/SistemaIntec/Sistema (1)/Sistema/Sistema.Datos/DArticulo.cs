using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema.Entidad;
using Sistema.datos;

namespace Sistema.Datos
{
    public class DArticulo
    {
        //Metodo para listar los articulo
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
                SqlCommand Comando = new SqlCommand("articulo_listar", sqlConnection);
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
        }//

        public DataTable CategoriaSeleccionar()
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
                SqlCommand Comando = new SqlCommand("categoria_seleccionar", sqlConnection);
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
        }//
        //Insertar Articulo
        public string Insertar(Articulo articulo)
        {
            //Necesitamos un objeto de tipo SqlConnection para conectarnos a la BD
            SqlConnection sqlConnection = new SqlConnection();
            string respuesta = "";

            try
            {
                //traemos la cadena de conexion
                sqlConnection = Conexion.getInstancia().CrearConexion();
                //configurar el comando a la base de datos
                SqlCommand Comando = new SqlCommand("articulo_insertar", sqlConnection);
                Comando.CommandType = CommandType.StoredProcedure;
                //configuramos los parametros
                Comando.Parameters.Add("@idcategoria", SqlDbType.Int).Value = articulo.IdCategoria;
                Comando.Parameters.Add("@codigo", SqlDbType.VarChar).Value = articulo.Codigo;
                Comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = articulo.Nombre;
                Comando.Parameters.Add("@precio_venta", SqlDbType.Decimal).Value = articulo.PrecioVenta;
                Comando.Parameters.Add("@stock", SqlDbType.Int).Value = articulo.Stock;
                Comando.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = articulo.Descripcion;
                Comando.Parameters.Add("@imagen", SqlDbType.VarChar).Value = articulo.Imagen;
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

        //editar una articulo

        public string Actualizar(Articulo articulos)
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
                SqlCommand Comando = new SqlCommand("articulo_actualizar", SqlConnection);
                //decirle que va a ejecutar un procedimiento almacenado
                Comando.CommandType = CommandType.StoredProcedure;
                //enviar los parametros
                Comando.Parameters.Add("@idarticulo", SqlDbType.Int).Value = articulos.IdArticulo;
                Comando.Parameters.Add("@idcategoria", SqlDbType.Int).Value = articulos.IdCategoria;
                Comando.Parameters.Add("@codigo", SqlDbType.VarChar).Value = articulos.Codigo;
                Comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = articulos.Nombre;
                Comando.Parameters.Add("@precio_venta", SqlDbType.Decimal).Value = articulos.PrecioVenta;
                Comando.Parameters.Add("@stock", SqlDbType.Int).Value = articulos.Stock;
                Comando.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = articulos.Descripcion;
                Comando.Parameters.Add("@imagen", SqlDbType.VarChar).Value = articulos.Imagen;
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

        //eliminar articulos

        public string Eliminar(int idarticulo)
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
                SqlCommand Comando = new SqlCommand("articulo_eliminar", SqlConnection);
                //decirle que va a ejecutar un procedimiento almacenado
                Comando.CommandType = CommandType.StoredProcedure;
                //enviar los parametros
                Comando.Parameters.Add("@idarticulo", SqlDbType.Int).Value = idarticulo;
                //abrir la conexion
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



        //activar Articulos
        public string Activar(int idarticulo)
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
                SqlCommand Comando = new SqlCommand("articulo_activar", SqlConnection);
                //decirle que va a ejecutar un procedimiento almacenado
                Comando.CommandType = CommandType.StoredProcedure;
                //enviar los parametros
                Comando.Parameters.Add("@idarticulo", SqlDbType.Int).Value = idarticulo;
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

        public string Desactivar(int idarticulo)
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
                SqlCommand Comando = new SqlCommand("articulo_desactivar", SqlConnection);
                //decirle que va a ejecutar un procedimiento almacenado
                Comando.CommandType = CommandType.StoredProcedure;
                //enviar los parametros
                Comando.Parameters.Add("@idarticulo", SqlDbType.Int).Value = idarticulo;
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
                SqlCommand Comando = new SqlCommand("articulo_buscar", sqlConnection);
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

        public DataTable BuscarCodigo(string valor)
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
                SqlCommand Comando = new SqlCommand("articulo_buscar_codigo", sqlConnection);
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
    }
}

