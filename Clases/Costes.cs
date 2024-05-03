using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace CreaSoft.Clases
{
        public class ActualizarDatosCliente
        {
            public void ActualizarCliente(string codigo, DateTime fechaInicio, DateTime fechaEntrega, decimal precio)
            {
                string connectionString = "Data Source=DESKTOP-FFL0MHR\\SQLEXPRESS;Initial Catalog=CreaSoft;Integrated Security=True";
                string query = "UPDATE Clientes SET FECHA_INICIO = @FechaInicio, FECHA_ENTREGA = @FechaEntrega, PRECIO = @Precio WHERE CÓDIGO = @Codigo";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                        command.Parameters.AddWithValue("@FechaEntrega", fechaEntrega);
                        command.Parameters.AddWithValue("@Precio", precio);
                        command.Parameters.AddWithValue("@Codigo", codigo);

                        try
                        {
                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Datos actualizados correctamente");
                            }
                            else
                            {
                                MessageBox.Show("No se encontró ningún cliente con el código proporcionado");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al actualizar los datos del cliente: " + ex.Message);
                        }
                    }
                }
            }
    }
}

