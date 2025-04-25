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
    public class NCategorias
    {
        //Listar Categorias
        public static DataTable Listar()
        {
            //Instanciar la clase DCategoria
            DCategorias datos = new DCategorias();
            return datos.Listar();
        }

        //Insertar una Categoria
        public static string Insertar(string nombre, string descripcion) //TOdos los parametros de los articulos hay que ponerles,
        {
            //instanciar la clase DCategoria
            DCategorias datos = new DCategorias();
            //debemos crear una categoria
            Categoria categoria = new Categoria();
            categoria.Nombre = nombre;
            categoria.Descripcion = descripcion;
            //insertar la categoria
            return datos.Insertar(categoria);
        }

        //Buscar una Categoria
        public static DataTable Buscar(string valor)
        {
            //Instanciar la clase DCategoria
            DCategorias datos = new DCategorias();
            return datos.Buscar(valor);
        }

        //Actualizar una Categoria
        public static string Actualizar(int id, string nombre, string descripcion)
        {
            //instanciar la clase DCategoria
            DCategorias datos = new DCategorias();
            //debemos crear una categoria
            Categoria categoria = new Categoria();
            //inicializar los atributos de la categoria
            categoria.IdCategoria = id;
            categoria.Nombre = nombre;
            categoria.Descripcion = descripcion;
            //insertar la categoria
            return datos.Actualizar(categoria);
        }

        //Eliminar una Categoria
        public static string Eliminar(int id)
        {
            //instanciar la clase DCategoria
            DCategorias datos = new DCategorias();
            return datos.Eliminar(id);
        }

        //Activar una Categoria
        public static string Activar(int id)
        {
            //instanciar la clase DCategoria
            DCategorias datos = new DCategorias();
            return datos.Activar(id);
        }

        //Desactivar una Categoria
        public static string Desactivar(int id)
        {
            //instanciar la clase DCategoria
            DCategorias datos = new DCategorias();
            return datos.Desactivar(id);

        }
    }
    
}
