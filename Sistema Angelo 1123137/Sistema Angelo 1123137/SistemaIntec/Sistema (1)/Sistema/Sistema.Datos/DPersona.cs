using Sistema.Entidad;
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
    public class DPersona
    {
        public DataTable Listar()
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlConnection = new SqlConnection();
            try
            {
                SqlConnection = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("persona_listar", SqlConnection);
                Comando.CommandType = CommandType.StoredProcedure;
                SqlConnection.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlConnection.State == ConnectionState.Open)
                {
                    SqlConnection.Close();
                }
            }
        }//Fin del metodo listar Persona

        public DataTable Listar_proveedores()
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlConnection = new SqlConnection();
            try
            {
                SqlConnection = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("persona_listar_proveedores", SqlConnection);
                Comando.CommandType = CommandType.StoredProcedure;
                SqlConnection.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlConnection.State == ConnectionState.Open)
                {
                    SqlConnection.Close();
                }
            }
        }//Fin del metodo Persona_listar_proveedores

        public DataTable Listar_cliente()
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlConnection = new SqlConnection();
            try
            {
                SqlConnection = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("persona_listar_clientes", SqlConnection);
                Comando.CommandType = CommandType.StoredProcedure;
                SqlConnection.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlConnection.State == ConnectionState.Open)
                {
                    SqlConnection.Close();
                }
            }
        }//Fin del metodo listar 


        public DataTable Buscar(string valor)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlConnection = new SqlConnection();
            try
            {
                SqlConnection = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("persona_buscar", SqlConnection);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@valor", SqlDbType.VarChar).Value = valor;
                SqlConnection.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlConnection.State == ConnectionState.Open)
                {
                    SqlConnection.Close();
                }
            }
        }//Fin del metodo Buscar

        public DataTable Buscar_proveedores(string valor)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlConnection = new SqlConnection();
            try
            {
                SqlConnection = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("persona_buscar_proveedores", SqlConnection);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@valor", SqlDbType.VarChar).Value = valor;
                SqlConnection.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlConnection.State == ConnectionState.Open)
                {
                    SqlConnection.Close();
                }
            }
        }//FIn del metodo Buscar_Proveedores

        public DataTable Buscar_clientes(string valor)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlConnection = new SqlConnection();
            try
            {
                SqlConnection = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("persona_buscar_clientes", SqlConnection);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@valor", SqlDbType.VarChar).Value = valor;
                SqlConnection.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlConnection.State == ConnectionState.Open)
                {
                    SqlConnection.Close();
                }
            }
        }//Fin del metodo Buscar_Clientes

        public string Insertar(Persona persona)
        {
            string respuesta = "";
            SqlConnection SqlConnection = new SqlConnection();
            try
            {
                SqlConnection = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("persona_insertar", SqlConnection);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@tipo_persona", SqlDbType.VarChar).Value = persona.TipoPersona;
                Comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = persona.Nombre;
                Comando.Parameters.Add("@tipo_documento", SqlDbType.VarChar).Value = persona.TipoDocumento;
                Comando.Parameters.Add("@num_documento", SqlDbType.VarChar).Value = persona.NumDocumento;
                Comando.Parameters.Add("@direccion", SqlDbType.VarChar).Value = persona.Direccion;
                Comando.Parameters.Add("@telefono", SqlDbType.VarChar).Value = persona.Telefono;
                Comando.Parameters.Add("@email", SqlDbType.VarChar).Value = persona.Email;
                SqlConnection.Open();
                respuesta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo insertar el registro";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (SqlConnection.State == ConnectionState.Open)
                {
                    SqlConnection.Close();
                }
            }
            return respuesta;
        }

        public string Actualizar(Persona persona)
        {
            string respuesta = "";
            SqlConnection SqlConnection = new SqlConnection();
            try
            {
                SqlConnection = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("persona_actualizar", SqlConnection);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@idpersona", SqlDbType.Int).Value = persona.IdPersona;
                Comando.Parameters.Add("@tipo_persona", SqlDbType.VarChar).Value = persona.TipoPersona;
                Comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = persona.Nombre;
                Comando.Parameters.Add("@tipo_documento", SqlDbType.VarChar).Value = persona.TipoDocumento;
                Comando.Parameters.Add("@num_documento", SqlDbType.VarChar).Value = persona.NumDocumento;
                Comando.Parameters.Add("@direccion", SqlDbType.VarChar).Value = persona.Direccion;
                Comando.Parameters.Add("@telefono", SqlDbType.VarChar).Value = persona.Telefono;
                Comando.Parameters.Add("@email", SqlDbType.VarChar).Value = persona.Email;
                SqlConnection.Open();
                respuesta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo actualizar el registro";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (SqlConnection.State == ConnectionState.Open)
                {
                    SqlConnection.Close();
                }
            }
            return respuesta;
        }

        public string Eliminar(int idpersona)
        {
            string respuesta = "";
            SqlConnection SqlConnection = new SqlConnection();
            try
            {
                SqlConnection = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("persona_eliminar", SqlConnection);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@idpersona", SqlDbType.Int).Value = idpersona;
                SqlConnection.Open();
                respuesta = Comando.ExecuteNonQuery() >= 1 ? "OK" : "No se pudo eliminar el registro";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (SqlConnection.State == ConnectionState.Open)
                {
                    SqlConnection.Close();
                }
            }
            return respuesta;
        }
    }
}
