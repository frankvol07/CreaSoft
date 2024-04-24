using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
namespace CreaSoft.Clases
{
    public class Conexion
    {
        public class ConexionSQL : IDisposable
        {
            public void Dispose()
            {
                if (_conexion != null && _conexion.State == ConnectionState.Open)
                {
                    _conexion.Close();
                }

                _conexion = null;
            }
            private string _cadenaConexion;
            private SqlConnection _conexion;

            public ConexionSQL(string cadenaConexion)
            {
                _cadenaConexion = cadenaConexion;
            }

            public bool AbrirConexion()
            {
                try
                {
                    _conexion = new SqlConnection(_cadenaConexion);
                    _conexion.Open();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al abrir la conexión: " + ex.Message);
                    return false;
                }
            }

            public void CerrarConexion()
            {
                if (_conexion != null && _conexion.State == ConnectionState.Open)
                {
                    _conexion.Close();
                }
            }

            public SqlConnection GetConexion()
            {
                if (_conexion == null || _conexion.State != ConnectionState.Open)
                {
                    throw new Exception("No hay una conexión abierta a la base de datos");
                }

                return _conexion;
            }

            // Métodos adicionales para ejecutar consultas SELECT, INSERT, UPDATE y DELETE
        }

    }

}
