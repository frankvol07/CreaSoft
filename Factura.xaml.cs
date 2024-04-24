using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CreaSoft.Clases;
using iTextSharp.text;
using iTextSharp.text.pdf;
using static CreaSoft.Clases.Factura2;


namespace CreaSoft
{
    /// <summary>
    /// Lógica de interacción para Factura.xaml
    /// </summary>
    public partial class Factura : Window
    {
        public Factura()
        {
            InitializeComponent();
        }

       
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Tu lógica aquí
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Hide();
            
            Registro ventanaRegistro = new Registro();
            ventanaRegistro.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Hide();

            Buscar ventanaBuscar = new Buscar();
            ventanaBuscar.Show();
        }

        private void Minimizar(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void Cerrar(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            this.Hide();

            MainWindow Inicio = new MainWindow();
            Inicio.Show();
        }

        private void Button_Click_factura(object sender, RoutedEventArgs e)
        {
            try
            {
                var codigoCliente = txtcliente.Text; // TextBox donde se ingresa el código del cliente
                var conexion = new ConexionSqlServer();

                var cliente = conexion.ObtenerCliente(codigoCliente); // Obtener datos del cliente por código

                // Llamar al método estático GenerarPDF en la clase Factura
                Factura2.GenerarPDF(cliente, "factura.pdf");

                MessageBox.Show("Factura generada y guardada como 'factura.pdf'");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

            // Obtén el código de la factura desde la interfaz de usuario (textbox, dropdown, etc.)

        }
    }
}





