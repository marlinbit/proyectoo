using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using datosf;


namespace negociossA
{
    public class Empleado
    { 
        public DataManager oBD = new DataManager();

        public void InsertarEmpleado(int ID, string nombre, string apellido, string Cedula, string Departamento, string Cargo, string sueldo,
            String FechaNacimiento, string sexo, string correo, string telefono, String FechaIngreso, string CuentaBancaria)
        {
            string sql;
            oBD.Conectar();

            sql = @"INSERT INTO Empleados (ID, nombre, apellido, Cedula,Departamento, Cargo, sueldo,
            FechaNacimiento,  sexo,  correo, telefono, FechaIngreso, CuentaBancaria)
                        VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')";

            sql = string.Format(sql, ID, nombre, apellido, Cedula, Departamento, Cargo, sueldo,
            FechaNacimiento, sexo, correo, telefono, FechaIngreso, CuentaBancaria);
            oBD.Ejecutar(sql);

            oBD.Cerrar();
            
        }

        public void ActualizarEmpleado( int ID, string nombre, string apellido, string Cedula, string Departamento, string Cargo, string sueldo,
            String  FechaNacimiento, string sexo, string correo, string telefono, String FechaIngreso, string CuentaBancaria)
        {
            string sql;
            oBD.Conectar();

            sql = @"UPDATE Empleados SET nombre='{1}',Apellido='{2}',Cedula='{3}',Departamento='{4}',Cargo='{5}',Sueldo='{6}',Fecha de Nacimiento='{7}',SEXO='{8}',Correo='{9}', 
                 Correo='{9}', Telefono='{10}',Fecha Ingreso='{11}', Cuenta Bancaria='{12}'  WHERE EmpleadoID='{9}')";

            sql = string.Format(sql, ID, nombre, apellido, Cedula, Departamento, Cargo, sueldo,
            FechaNacimiento, sexo, correo, telefono, FechaIngreso, CuentaBancaria);
            oBD.Ejecutar(sql);

            oBD.Cerrar();
        }

        public void EliminarEmpleado(int Id)
        {
            oBD.Conectar();

            string sql = "Delete From Empleados where EmpleadoID= {0}";
            sql = string.Format(sql, Id);

            oBD.Ejecutar(sql);

            oBD.Cerrar();
        }


        public DataTable CargarEmpleado()

        {
            System.Data.DataTable dt;

            oBD.Conectar();
            string sql;
            sql = @"Select EmpleadoID'Datos', 
                                Concat (Nombre,' ',Apellido) 'Nombre Completo',Cedula, FechaNacimiento 'Fecha', Telefono,  from Empleados";
            dt = oBD.Buscar(sql);

            oBD.Cerrar();

            return dt;

        }

    }
}

