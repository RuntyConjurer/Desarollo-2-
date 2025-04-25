using Sistema.Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema.Datos;

namespace Sistema.Negocios
{
    public class NPersona
    {
        

        public static DataTable Listar_proveedores()
        {
            DPersona datos = new DPersona();
            return datos.Listar_proveedores();
        }

        public static DataTable Listar_cliente()
        {
            DPersona datos = new DPersona();
            return datos.Listar_cliente();
        }

        public static DataTable Buscar(string valor)
        {
            DPersona datos = new DPersona();
            return datos.Buscar(valor);
        }

        public static DataTable Buscar_proveedores(string valor)
        {
            DPersona datos = new DPersona();
            return datos.Buscar_proveedores(valor);
        }

        public static DataTable Buscar_clientes(string valor)
        {
            DPersona datos = new DPersona();
            return datos.Buscar_clientes(valor);
        }

        public static string Insertar(string tipoPersona, string nombre, string tipoDocumento, string numDocumento, string direccion, string telefono, string email)
        {
            DPersona datos = new DPersona();
            Persona persona = new Persona
            {
                TipoPersona = tipoPersona,
                Nombre = nombre,
                TipoDocumento = tipoDocumento,
                NumDocumento = numDocumento,
                Direccion = direccion,
                Telefono = telefono,
                Email = email
            };
            return datos.Insertar(persona);
        }

        public static string Actualizar(int idPersona, string tipoPersona, string nombre, string tipoDocumento, string numDocumento, string direccion, string telefono, string email)
        {
            DPersona datos = new DPersona();
            Persona persona = new Persona
            {
                IdPersona = idPersona,
                TipoPersona = tipoPersona,
                Nombre = nombre,
                TipoDocumento = tipoDocumento,
                NumDocumento = numDocumento,
                Direccion = direccion,
                Telefono = telefono,
                Email = email
            };
            return datos.Actualizar(persona);
        }

        public static string Eliminar(int id)
        {
            DPersona datos = new DPersona();
            return datos.Eliminar(id);
        }
    }
}
