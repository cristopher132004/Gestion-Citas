using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using CapaDatos;

namespace CapaNegocio
{
    public class CNCliente
    {
        //Preparamos los datos para insertar un nuevo Cliente. A los parametros recibidos les pongo el prefijo p
        public static string Insertar(int pIdCliente, string pNombre, string pApellido, string pTelefono,
         string pCorreo, string pEstado)
        {
            CDCliente objCliente = new CDCliente();
            objCliente.IdCliente = pIdCliente;
            objCliente.Nombre = pNombre;
            objCliente.Telefono = pTelefono;
            objCliente.Correo = pCorreo;
            objCliente.Estado = pEstado;
            //Llamamos al método insertar del suplidor pasándole el objeto creado
            //y retornando el mensaje que indica si se pudo o no realizar la acción
            return objCliente.Insertar(objCliente);
        } //Fin del método Insertar

        public static string Actualizar(int pIdCliente, string pNombre, string pApellido, string pTelefono,
         string pCorreo, string pEstado)
        {
            CDCliente objCliente = new CDCliente();
            objCliente.IdCliente = pIdCliente;
            objCliente.Nombre = pNombre;
            objCliente.Apellido = pApellido;
            objCliente.Telefono = pTelefono;
            objCliente.Correo = pCorreo;
            objCliente.Estado = pEstado;
            //Llamamos al método insertar del suplidor pasándole el objeto creado
            //y retornando el mensaje que indica si se pudo o no realizar la acción
            return objCliente.Actualizar(objCliente);
        } //Fin del método Actualizar


          //Método utilizado para obtener un DataTable con todos los datos de la tabla
          //correspondiente
        public DataTable ObtenerSuplidor(string miparametro)
        {
            CDCliente objCliente = new CDCliente();
            DataTable dt = new DataTable(); //creamos un nuevo DataTable
                                            //El DataTable se llena con todos los datos devueltos
            dt = objCliente.ClienteConsultar(miparametro);
            return dt; //Se retorna el DataTable con los datos adquiridos
        }
    }
}
