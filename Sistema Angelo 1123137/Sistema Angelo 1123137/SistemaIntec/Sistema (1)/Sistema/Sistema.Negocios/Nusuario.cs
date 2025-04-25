using Sistema.datos;
using Sistema.Datos;
using Sistema.Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Negocios
{
    public class Nusuario
    {
        public static DataTable Listar()
        {

            // Instanciamos la clase DCategoria
            DUsuario datos = new DUsuario();
            //ejeamos el metodo listar de la clase DCategoria
            return datos.Listar();

        }//fin del metodo listar

        public static DataTable Listar_Rol()
        {
            DRol dRol = new DRol();
            return dRol.Listar();
        }
        //metodo buscar
        public static DataTable Buscar(string valor)
        {
            // Instanciamos la clase DCategoria
            DUsuario datos = new DUsuario();
            //ejeamos el metodo buscar de la clase DCategoria
            return datos.Buscar(valor);
        }//fin del metodo buscar


        //metodo insertar
        public static string Insertar(int idrol, string nombre, string tipodocumento, string numdocumento, string direccion, string telefono, string email, string clave)
        {
            // Instanciamos la clase DCategoria
            DUsuario datos = new DUsuario();
            //declaramos una variable de tipo string para retornar el mensaje  - PENDIENTE


            //Antes de insertar la categoria, debemosc crear un objeto, porque  es lo que requiere el metodo 
            //insertar de la capa de datos
            Usuario usuario = new Usuario();
            usuario.IdRol = idrol;
            usuario.Nombre = nombre;
            usuario.TipoDocumento = tipodocumento;
            usuario.NumDocumento = numdocumento;
            usuario.Direccion = direccion;
            usuario.Telefono = telefono;
            usuario.Email = email;
            usuario.Clave = clave;



            //insertamos la categoria
            return datos.Insertar(usuario);

        }//fin del metodo insertar

        public static string Actualizar(int idusuario, int idrol, string nombre, string tipodocumento, string numdocumento, string direccion, string telefono, string email, string clave)
        {
            // Instanciamos la clase DCategoria
            DUsuario datos = new DUsuario();
            //declaramos una variable de tipo string para retornar el mensaje  - PENDIENTE


            //Antes de insertar la categoria, debemosc crear un objeto, porque  es lo que requiere el metodo 
            //insertar de la capa de datos
            Usuario usuario = new Usuario();

            usuario.IdUsuario = idusuario;
            usuario.IdRol = idrol;
            usuario.Nombre = nombre;
            usuario.TipoDocumento = tipodocumento;
            usuario.NumDocumento = numdocumento;
            usuario.Direccion = direccion;
            usuario.Telefono = telefono;
            usuario.Email = email;
            usuario.Clave = clave;

            //insertamos la categoria
            return datos.Actualizar(usuario);

        }//fin del metodo Actualizar

        //metodo eliminar
        public static string Eliminar(int id)
        {
            // Instanciamos la clase DCategoria
            DUsuario datos = new DUsuario();
            //ejeamos el metodo eliminar de la clase DCategoria
            return datos.Eliminar(id);
        }//fin del metodo eliminar


        //metodo activar
        public static string Activar(int id)
        {
            // Instanciamos la clase DCategoria
            DUsuario datos = new DUsuario();
            //ejeamos el metodo activar de la clase DCategoria
            return datos.Activar(id);
        }//fin del metodo activar


        //metodo desactivar
        public static string Desactivar(int id)
        {
            // Instanciamos la clase DCategoria
            DUsuario datos = new DUsuario();
            //ejeamos el metodo desactivar de la clase DCategoria
            return datos.Desactivar(id);
        }//fin del metodo desactivar

        //metodo existe usuario
        public static string Existe(string valor)
        {
            // Instanciamos la clase DCategoria
            DUsuario datos = new DUsuario();
            //ejeamos el metodo existe de la clase DCategoria
            return datos.Existe(valor);
        }//fin del metodo existe

    }
}
