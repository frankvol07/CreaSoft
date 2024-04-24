using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CreaSoft.Clases.Conexion;

namespace CreaSoft.Clases
{
    public class Login
    {
        string cadenaConexion = "Data Source=DESKTOP-FFL0MHR\\SQLEXPRESS;Initial Catalog=CreaSoft;Integrated Security=True";

        private string _usuario;
        private string _contraseña;

        public string Usuario { get => _usuario; set => _usuario = value; }
        public string Contraseña { get => _contraseña; set => _contraseña = value; }

        public bool ValidarUsuario()
        {
            // Implementar la lógica para validar el usuario en la tabla Empleados
            bool usuarioValido = false;

            using (ConexionSQL conexion = new ConexionSQL(cadenaConexion))
            {
                if (conexion.AbrirConexion())
                {
                    SqlCommand comando = new SqlCommand("SELECT * FROM Login WHERE Usuario = @usuario AND Contraseña = @contrasena", conexion.GetConexion());
                    comando.Parameters.AddWithValue("@usuario", Usuario);
                    comando.Parameters.AddWithValue("@contrasena", Contraseña); // Hash password before storing (security best practice)

                    SqlDataReader reader = comando.ExecuteReader();

                    usuarioValido = reader.HasRows;

                    conexion.CerrarConexion();
                }
            }

            return usuarioValido;
        }
    }
    }