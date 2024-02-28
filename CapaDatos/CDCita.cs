using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.Sql;

namespace CapaDatos
{
    public class CDCita
    {
        private int dIdCita;
        private String dFecha, dHora, dEstado, dIdCliente, dIdBarbero;
 

        public CDCita() { }
        public CDCita(int pIdCita, string pFecha, string pHora, string pEstado, string pIdCliente, string pIdBarbero)
        {
            this.dIdCita = pIdCita;
            this.dFecha = pFecha;
            this.dHora = pHora;
            this.dEstado = pEstado;
            this.dIdCliente = pIdCliente;
            this.dIdBarbero = pIdBarbero;
        }
        public int IdCita
        {
            get { return dIdCita; }
            set { dIdCita = value; }
        }
        public string Fecha
        {
            get { return dFecha; }
            set { dFecha = value; }
        }

        public string Hora
        {
            get { return dHora; }
            set { dHora = value; }
        }

        public string Estado
        {
            get { return dEstado; }
            set { dEstado = value; }
        }

        public string IdCliente
        {
            get { return dIdCliente; }
            set { dIdCliente = value; }
        }

        public string IdBarbero
        {
            get { return dIdBarbero; }
            set { dIdBarbero = value; }
        }

        public string Insertar(CDCita objCita)
        {
            string mensaje = "";
            //creamos un nuevo objeto de tipo SqlConnection
            SqlConnection sqlCon = new SqlConnection();
            //trataremos de hacer algunas operaciones con la tabla
            try
            {
                //asignamos a sqlCon la conexión con las base de datos a traves de la clase que creamos
                sqlCon.ConnectionString = ConexionDB.miconexion;
                //Escribo el nombre del procedimiento almacenado que utilizaré, en este caso SuplidorInsertar
                SqlCommand micomando = new SqlCommand("CitaInsectar", sqlCon);
                sqlCon.Open(); //Abro la conexióna
                               //indico que se ejecutara un procedimiento almacenado
                micomando.CommandType = CommandType.StoredProcedure;
                micomando.Parameters.AddWithValue("@pFecha", objCita.Fecha);
                micomando.Parameters.AddWithValue("@pHora", objCita.Hora);
                micomando.Parameters.AddWithValue("@pEstado", objCita.Estado);
                micomando.Parameters.AddWithValue("@pIdCliente", objCita.IdCliente);
                micomando.Parameters.AddWithValue("@pIdBarbero", objCita.IdBarbero);
                //Metodo Insertar
                mensaje = micomando.ExecuteNonQuery() == 1 ? "Datos actualizados correctamente!" :
                                                 "No se pudo actualizar correctamente los datos!";
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
            return mensaje;
        }//Metodo
         //método para actualizar los datos del Suplidor. Recibirá el objeto objSuplidor como parámetro
        public string Actualizar(CDCita objCita)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = ConexionDB.miconexion;
                SqlCommand micomando = new SqlCommand("Citactualizar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;
                micomando.Parameters.AddWithValue("@pFecha", objCita.Fecha);
                micomando.Parameters.AddWithValue("@pHora", objCita.Hora);
                micomando.Parameters.AddWithValue("@pEstado", objCita.Estado);
                micomando.Parameters.AddWithValue("@pIdCliente", objCita.IdCliente);
                micomando.Parameters.AddWithValue("@pIdBarbero", objCita.IdBarbero);
                mensaje = micomando.ExecuteNonQuery() == 1 ? "Datos actualizados correctamente!" :
                "No se pudo actualizar correctamente los datos!";
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
            return mensaje;
        }
        //Método para consultar datos filtrados de la tabla. Se recibe el valor del parámetro
        public DataTable CitaConsultar(String miparametro)
        {
            DataTable dt = new DataTable(); //Se Crea DataTable que tomará los datos de los Suplidores
            SqlDataReader leerDatos; //Creamos el DataReader
            try
            {
                SqlCommand sqlCmd = new SqlCommand(); //Establecer el comando
                sqlCmd.Connection = new ConexionDB().dbconexion; //Conexión que va a usar el comando
                sqlCmd.Connection.Open(); //Se abre la conexión
                sqlCmd.CommandText = "CitaConsultar"; //Nombre del Proc. Almacenado a usar
                sqlCmd.CommandType = CommandType.StoredProcedure; //Se trata de un proc. almacenado
                sqlCmd.Parameters.AddWithValue("@pvalor", miparametro); //Se pasa el valor a buscar
                leerDatos = sqlCmd.ExecuteReader(); //Llenamos el SqlDataReader con los datos resultantes
                dt.Load(leerDatos); //Se cargan los registros devueltos al DataTable
                sqlCmd.Connection.Close(); //Se cierra la conexión
            }
            catch (Exception ex)
            {
                dt = null; //Si ocurre algun error se anula el DataTable
            }
            return dt; ////Se retorna el DataTable segun lo ocurrido arriba
        }//Fin del método MostrarConFiltro

    }
}//Fin de la clase CDCliente