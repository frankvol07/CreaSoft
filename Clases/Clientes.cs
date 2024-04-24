using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using static CreaSoft.Clases.Conexion;
using System.Windows;
using System.Windows.Documents;
using System.Data;
using System.Windows.Controls;

namespace CreaSoft.Clases
{
    public class Clientes
    {

        public class Cliente
        {
            private int _id;
            private string _codigo;
            private string _nombre;
            private string _apellido;
            private int _cedula;
            private string _telefono;
            private string _direccion;
            private string _correo;
            private string _tipoServicio;
            private string _descripcionServicio;

            // Propiedades para acceder a los campos

            public int Id { get => _id; set => _id = value; }
            public string Codigo { get => _codigo; set => _codigo = value; }
            public string Nombre { get => _nombre; set => _nombre = value; }
            public string Apellido { get => _apellido; set => _apellido = value; }
            public int Cedula { get => _cedula; set => _cedula = value; }
            public string Telefono { get => _telefono; set => _telefono = value; }
            public string Direccion { get => _direccion; set => _direccion = value; }
            public string Correo { get => _correo; set => _correo = value; }
            public string TipoServicio { get => _tipoServicio; set => _tipoServicio = value; }
            public string DescripcionServicio { get => _descripcionServicio; set => _descripcionServicio = value; }

            // Métodos para CRUD (Crear, Leer, Actualizar, Eliminar)

            public static void Registrar(Cliente cliente)
            {
                string cadenaConexion = "Data Source=DESKTOP-FFL0MHR\\SQLEXPRESS;Initial Catalog=CreaSoft;Integrated Security=True";

                using (ConexionSQL conexion = new ConexionSQL(cadenaConexion))
               
                {
                    if (conexion.AbrirConexion())
                    {
                        SqlCommand comando = new SqlCommand("INSERT INTO Clientes (NOMBRE, APELLIDO, CÉDULA, TELÉFONO, DIRECCIÓN, CORREO, TIPO_DE_SERVICIO, DESCRIPCIÓN) VALUES (@nombre, @apellido, @cedula, @telefono, @direccion, @correo, @tipoServicio, @descripcionServicio)", conexion.GetConexion());
                        comando.Parameters.AddWithValue("@nombre", cliente.Nombre);
                        comando.Parameters.AddWithValue("@apellido", cliente.Apellido);
                        comando.Parameters.AddWithValue("@cedula", cliente.Cedula);
                        comando.Parameters.AddWithValue("@telefono", cliente.Telefono);
                        comando.Parameters.AddWithValue("@direccion", cliente.Direccion);
                        comando.Parameters.AddWithValue("@correo", cliente.Correo);
                        comando.Parameters.AddWithValue("@tipoServicio", cliente.TipoServicio);
                        comando.Parameters.AddWithValue("@descripcionServicio", cliente.DescripcionServicio);

                        comando.ExecuteNonQuery();

                        conexion.CerrarConexion();
                    }
                }
                // Implementar la lógica para registrar un cliente en la base de datos
            }

            public static List<Cliente> BuscarPorNombre(string nombre)
            {
                string cadenaConexion = "Data Source=DESKTOP-FFL0MHR\\SQLEXPRESS;Initial Catalog=CreaSoft;Integrated Security=True";

                List<Cliente> clientes = new List<Cliente>();

                using (ConexionSQL conexion = new ConexionSQL(cadenaConexion))
                {
                    if (conexion.AbrirConexion())
                    {
                        SqlCommand comando = new SqlCommand("SELECT * FROM Clientes WHERE NOMBRE LIKE @nombre", conexion.GetConexion());
                        comando.Parameters.AddWithValue("@nombre", "%" + nombre + "%");

                        SqlDataReader reader = comando.ExecuteReader();

                        while (reader.Read())
                        {
                            Cliente cliente = new Cliente();
                            cliente.Id = int.Parse(reader["Id"].ToString());
                            cliente.Codigo = reader["CÓDIGO"].ToString();
                            cliente.Nombre = reader["Nombre"].ToString();
                            cliente.Apellido = reader["Apellido"].ToString();
                            cliente.Cedula = int.Parse(reader["CÉDULA"].ToString());
                            cliente.Telefono = reader["TELÉFONO"].ToString();
                            cliente.Direccion = reader["DIRECCIÓN"].ToString();
                            cliente.Correo = reader["Correo"].ToString();
                            cliente.TipoServicio = reader["TIPO_DE_SERVICIO"].ToString();
                            cliente.DescripcionServicio = reader["DESCRIPCIÓN"].ToString();

                            clientes.Add(cliente);
                        }

                        conexion.CerrarConexion();
                    }
                }

                return clientes;
                // Implementar la lógica para buscar clientes por nombre
            }

            public static Cliente BuscarPorCodigo(string codigo)
            {
                string cadenaConexion = "Data Source=DESKTOP-FFL0MHR\\SQLEXPRESS;Initial Catalog=CreaSoft;Integrated Security=True";
                Cliente cliente = null;

                using (ConexionSQL conexion = new ConexionSQL(cadenaConexion))
                {
                    if (conexion.AbrirConexion())
                    {
                        SqlCommand comando = new SqlCommand("SELECT * FROM Clientes WHERE CÓDIGO = @codigo", conexion.GetConexion());
                        comando.Parameters.AddWithValue("@codigo", codigo);

                        SqlDataReader reader = comando.ExecuteReader();

                        if (reader.Read())
                        {
                            cliente = new Cliente();
                            cliente.Id = int.Parse(reader["Id"].ToString());
                            cliente.Codigo = reader["CÓDIGO"].ToString();
                            cliente.Nombre = reader["Nombre"].ToString();
                            cliente.Apellido = reader["Apellido"].ToString();
                            cliente.Cedula = int.Parse(reader["CÉDULA"].ToString());
                            cliente.Telefono = reader["TELÉFONO"].ToString();
                            cliente.Direccion = reader["DIRECCIÓN"].ToString();
                            cliente.Correo = reader["Correo"].ToString();
                            cliente.TipoServicio = reader["TIPO_DE_SERVICIO"].ToString();
                            cliente.DescripcionServicio = reader["DESCRIPCIÓN"].ToString();
                        }

                        conexion.CerrarConexion();
                    }
                }

                return cliente;
                // Implementar la lógica para buscar un cliente por código
            }

            public void Eliminar(string codigo)
            {
                string cadenaConexion = "Data Source=DESKTOP-FFL0MHR\\SQLEXPRESS;Initial Catalog=CreaSoft;Integrated Security=True";

                using (ConexionSQL conexion = new ConexionSQL(cadenaConexion))
                {
                    if (conexion.AbrirConexion())
                    {
                        SqlCommand comando = new SqlCommand("DELETE FROM Clientes WHERE CÓDIGO = @codigo", conexion.GetConexion());
                        comando.Parameters.AddWithValue("@codigo", codigo);

                        int filasAfectadas = comando.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            // Se eliminó el cliente exitosamente
                            MessageBox.Show("Cliente eliminado con éxito");
                        }
                        else
                        {
                            // No se encontró ningún cliente con el código especificado
                            MessageBox.Show("No se encontró ningún cliente con el código " + codigo);
                        }

                        conexion.CerrarConexion();
                    }
                }
            }
            // Implementar la lógica para eliminar un cliente de la base de datos
        }

        private string connectionString;

        public Clientes(string connectionString)
        {
            this.connectionString = connectionString;
        }


        public void MostrarDatosCliente(DataGrid dataGrid)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Clientes"; // Assuming "Clientes" is your table name
                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGrid.ItemsSource = dataTable.DefaultView; // Use DefaultView for WPF binding
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar datos de clientes: " + ex.Message);
            }
        }



    }

}

