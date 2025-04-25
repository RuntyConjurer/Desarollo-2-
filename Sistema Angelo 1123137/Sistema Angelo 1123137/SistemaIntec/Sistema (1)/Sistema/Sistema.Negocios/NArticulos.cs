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
    public class NArticulos
    {
        public static DataTable CategoriaSeleccionar()
        {
            //Instanciar la clase DCategoria
            DArticulo datos = new DArticulo();
            return datos.CategoriaSeleccionar();
        }
        // listar artciulos
        public static DataTable Listar()
        {
            // Instanciamos la clase DArticulos
            DArticulo datos = new DArticulo();
            //ejeamos el metodo listar de la clase DArticulos
            return datos.Listar();

        }//fin del metodo listar

        //metodo buscar
        public static DataTable Buscar(string valor)
        {
            // Instanciamos la clase DArticulos
            DArticulo datos = new DArticulo();
            //ejeamos el metodo buscar de la clase DArticulos
            return datos.Buscar(valor);

        }//fin del metodo buscar

        public static DataTable BuscarCodigo(string valor)
        {
            // Instanciamos la clase DArticulos
            DArticulo datos = new DArticulo();
            //ejeamos el metodo buscar de la clase DArticulos
            return datos.BuscarCodigo(valor);

        }//fin del metodo buscar


        //metodo insertar
        public static string Insertar(int idcategoria, string codigo, string nombre, decimal precioventa, int stock, string descripcion, string imagen)
        {
            // Instanciamos la clase DArticulos
            DArticulo datos = new DArticulo();
            //declaramos una variable de tipo string para retornar el mensaje  - PENDIENTE


            //Antes de insertar la categoria, debemosc crear un objeto, porque  es lo que requiere el metodo 
            //insertar de la capa de datos

            Articulo articulos = new Articulo();

            articulos.IdCategoria = idcategoria;
            articulos.Codigo = codigo;
            articulos.Nombre = nombre;
            articulos.PrecioVenta = precioventa;
            articulos.Stock = stock;
            articulos.Descripcion = descripcion;
            articulos.Imagen = imagen;

            //insertamos la articulo
            return datos.Insertar(articulos);

        }//fin del metodo insertar

        public static string Actualizar(int idarticulo, int idcategoria, string codigo, string nombre, decimal precioventa, int stock, string descripcion, string imagen)
        {
            // Instanciamos la clase DCategoria
            DArticulo datos = new DArticulo();
            //declaramos una variable de tipo string para retornar el mensaje  - PENDIENTE


            //Antes de insertar la categoria, debemosc crear un objeto, porque  es lo que requiere el metodo 
            //insertar de la capa de datos
            Articulo articulos = new Articulo();

            articulos.IdArticulo = idarticulo;
            articulos.IdCategoria = idcategoria;
            articulos.Codigo = codigo;
            articulos.Nombre = nombre;
            articulos.PrecioVenta = precioventa;
            articulos.Stock = stock;
            articulos.Descripcion = descripcion;
            articulos.Imagen = imagen;


            //insertamos la articulo
            return datos.Actualizar(articulos);

        }//fin del metodo Actualizar

        //metodo eliminar
        public static string Eliminar(int id)
        {
            // Instanciamos la clase DCategoria
            DArticulo datos = new DArticulo();
            //ejeamos el metodo eliminar de la clase DCategoria
            return datos.Eliminar(id);
        }//fin del metodo eliminar


        //metodo activar
        public static string Activar(int id)
        {
            // Instanciamos la clase DCategoria
            DArticulo datos = new DArticulo();
            //ejeamos el metodo activar de la clase DCategoria
            return datos.Activar(id);
        }//fin del metodo activar


        //metodo desactivar
        public static string Desactivar(int id)
        {
            // Instanciamos la clase DCategoria
            DArticulo datos = new DArticulo();
            //ejeamos el metodo desactivar de la clase DCategoria
            return datos.Desactivar(id);
        }//fin del metodo desactivar

    }
}
