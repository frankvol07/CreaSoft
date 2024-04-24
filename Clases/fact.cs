using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace CreaSoft.Clases
{
    public class Factura2
    {

        public static void GenerarPDF(Cliente cliente, string rutaArchivo)
        {
            // Crear un documento PDF
            Document document = new Document();

            // Crear un escritor para el PDF y asociarlo al documento
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(rutaArchivo, FileMode.Create));

            // Abrir el documento para agregar contenido
            document.Open();

            // Agregar contenido al PDF
            document.Add(new Paragraph("Factura"));
            document.Add(new Paragraph($"Código del Cliente: {cliente.Codigo}"));
            document.Add(new Paragraph($"Nombre: {cliente.Nombre} {cliente.Apellido}"));
            document.Add(new Paragraph($"Correo: {cliente.Correo}"));
            document.Add(new Paragraph($"Teléfono: {cliente.Telefono}"));
            document.Add(new Paragraph($"Tipo de Servicio: {cliente.TipoDeServicio}"));

            // Cerrar el documento para finalizar el PDF
            document.Close();
        }
        public class Cliente
        {
            public string Codigo { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Correo { get; set; }
            public string Telefono { get; set; }
            public string TipoDeServicio { get; set; }
        }
        public class ConexionSqlServer
        {
            // Ejemplo de cadena de conexión, cámbiala según tu configuración
            private string connectionString = "Data Source=DESKTOP-FFL0MHR\\SQLEXPRESS;Initial Catalog=CreaSoft;Integrated Security=True";

            public Cliente ObtenerCliente(string codigoCliente)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Consulta para obtener datos del cliente por código
                    string query = "SELECT CÓDIGO, NOMBRE, APELLIDO, CORREO, TELÉFONO, TIPO_DE_SERVICIO FROM Cliente WHERE CÓDIGO = @codigoCliente";

                    SqlCommand command = new SqlCommand(query, connection);

                    // Usar parámetros para evitar inyecciones SQL
                    command.Parameters.AddWithValue("@codigoCliente", codigoCliente);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        Cliente cliente = new Cliente
                        {
                            Codigo = reader["CODIGO"].ToString(),
                            Nombre = reader["NOMBRE"].ToString(),
                            Apellido = reader["APELLIDO"].ToString(),
                            Correo = reader["CORREO"].ToString(),
                            Telefono = reader["TELEFONO"].ToString(),
                            TipoDeServicio = reader["TIPODESERVICIO"].ToString()
                        };

                        return cliente;
                    }
                    else
                    {
                        throw new Exception("Cliente no encontrado");
                    }
                }
               }
   
        }
    }
}






