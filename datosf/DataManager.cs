using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datosf
{
    public class DataManager
    {
        //PASO 1: Estabeler Cadena de Conexion con la Base de Datos
        private SqlConnection Conexion = new SqlConnection("data source = MARLIN; Database=EmpresaMarlin; Integrated Security=True;");
        //private SqlConnection Conexion = new SqlConnection("server=localhost\\SQLEXPRESS; Initial Catalog=University; Integrated Security=True;");
        //private SqlConnection Conexion = new SqlConnection("server=.\\SQLEXPRESS; Initial Catalog=University; Integrated Security=True;");
        //private SqlConnection Conexion = new SqlConnection("server=127.0.0.1\\SQLEXPRESS; Initial Catalog=University; Integrated Security=True;");
        // private SqlConnection Conexion = new SqlConnection("server=DESKTOP-57G3KOL\\SQLEXPRESS; Initial Catalog=University; Integrated Security=True; Connection Timeout=30;");


        //PASO 2: Crear Metodos para Abrir y Cerrar conexion con la Base de Datos

        public SqlConnection Conectar() // Metodo utilizado para abrir conexion o conectar con la base de datos
        {
            if (Conexion.State == ConnectionState.Closed)
            {
                Conexion.Open();
            }
            return Conexion;
        }

        public SqlConnection Cerrar() // Metodo utilizado para cerrar conexion o conectar con la base de datos
        {
            if (Conexion.State == ConnectionState.Open)
            {
                Conexion.Close();
            }
            return Conexion;
        }

        //PASO 3: Crear Metodos para ejecutar comandos SQL desde nuestra aplicacion

        public void Ejecutar(string sql)
        {
            SqlCommand oComando = new SqlCommand();
            oComando.Connection = Conexion;
            oComando.CommandText = sql;
            oComando.ExecuteNonQuery();

        }

        public void Ejecutar1(string sql, ref int numgenerado)
        {
            SqlCommand oComando = new SqlCommand();
            oComando.Connection = Conexion;
            oComando.CommandText = sql;
            numgenerado = Convert.ToInt32(oComando.ExecuteNonQuery());

        }

        //PASO 4: Crear Metodo para recuperar datos desde la base de datos y manejarlos como tabla virtual

        public DataTable Buscar(string sql)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            SqlCommand oComando = new SqlCommand();

            oComando.Connection = Conexion;
            oComando.CommandText = sql;
            oAdapter.SelectCommand = oComando;

            oAdapter.Fill(dt);

            return dt;
        }
    }
}
