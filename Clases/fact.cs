using System;
using System.Data;
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Windows;
using System.Drawing; 
using System.Drawing.Imaging;
using System.Text;
using iTextSharp.text.pdf.codec;
using iTextSharp.text.pdf.parser;
using iTextSharp.text.pdf.draw;
using iTextSharp.text.pdf.events;

namespace Creasoft.Clases
{
    public class GeneradorPDF
    {
        public void GenerarFacturaPDF(string codigo)
        {
            string connectionString = "Data Source=DESKTOP-FFL0MHR\\SQLEXPRESS;Initial Catalog=CreaSoft;Integrated Security=True";
            string query = "SELECT NOMBRE, APELLIDO, CORREO, TIPO_DE_SERVICIO, DESCRIPCIÓN,TELÉFONO FROM Clientes WHERE CÓDIGO = @Codigo";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Codigo", codigo);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string nombre = reader["NOMBRE"].ToString();
                        string apellido = reader["APELLIDO"].ToString();
                        string correo = reader["CORREO"].ToString();
                        string Tipo = reader["TIPO_DE_SERVICIO"].ToString();
                        string Descripcion = reader["DESCRIPCIÓN"].ToString();

                        string folderPath = "C:\\Users\\Francis\\FactsCrea\\";
                        string filePath = folderPath + nombre + " " + apellido + ".pdf";

                        using (FileStream fs = new FileStream(filePath, FileMode.Create))
                        {
                            Document doc = new Document();
                            PdfWriter writer = PdfWriter.GetInstance(doc, fs);

                            // Agregar evento para el encabezado
                            writer.PageEvent = new HeaderEvent();

                            doc.Open();

                            // Agregar el logo
                            string logoPath = "C:\\Users\\Francis\\source\\repos\\CreaSoft\\Photoroom-20240314_192110 (1).png"; // Reemplaza con la ruta correcta del logo
                            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(logoPath); // Se especifica el nombre completo de la clase Image
                            logo.ScaleAbsolute(100f, 100f); // Ajusta el tamaño del logo según tus necesidades
                            doc.Add(logo);

                            // Agregar los datos de la factura
                            doc.Add(new Paragraph("Factura"));
                            doc.Add(Chunk.NEWLINE);
                            doc.Add(new Paragraph($"Nombre: {nombre} {apellido}"));
                            doc.Add(new Paragraph($"Correo: {correo}"));
                            doc.Add(new Paragraph($"Servicio: {Tipo}"));
                            doc.Add(new Paragraph($"Descripción: {Descripcion}"));

                            // Agregar el código de barras
                            Barcode128 barcode = new Barcode128();
                            barcode.Code = codigo;
                            barcode.StartStopText = false;
                            iTextSharp.text.Image code128Image = barcode.CreateImageWithBarcode(writer.DirectContent, BaseColor.BLACK, BaseColor.BLACK);
                            doc.Add(code128Image);

                            doc.Close();
                        }

                        MessageBox.Show("Factura generada correctamente");
                    }
                    else
                    {
                        MessageBox.Show("Cliente no encontrado");
                    }
                }
            }
        }

        // Clase para manejar el evento de encabezado en el PDF
        public class HeaderEvent : PdfPageEventHelper
        {
            public override void OnEndPage(PdfWriter writer, Document doc)
            {
                PdfPTable headerTable = new PdfPTable(1);
                headerTable.TotalWidth = doc.PageSize.Width - doc.LeftMargin - doc.RightMargin;
                headerTable.DefaultCell.Border = 0;

                

                headerTable.WriteSelectedRows(0, -1, doc.LeftMargin, doc.PageSize.GetTop(doc.TopMargin) + 10, writer.DirectContent);
            }
        }
    }
}
