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
using static CreaSoft.Clases.Clientes;

namespace CreaSoft
{
    /// <summary>
    /// Lógica de interacción para Registro.xaml
    /// </summary>
    public partial class Registro : Window
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           

            try
            {
                // Obtener los valores de las textbox
                string nombre = Nombre.Text;
                string apellido = Apellido.Text;
                int cedula = int.Parse(Cedula.Text);
                string telefono = Telefono.Text;
                string direccion = Direccion.Text;
                string correo = Correo.Text;
                string tipoServicio = TipoServicio.Text;
                string descripcionServicio = DescripcionServicio.Text;

                // Crear una instancia de la clase Cliente
                Cliente cliente = new Cliente();

                // Asignar los valores a las propiedades
                cliente.Nombre = nombre;
                cliente.Apellido = apellido;
                cliente.Cedula = cedula;
                cliente.Telefono = telefono;
                cliente.Direccion = direccion;
                cliente.Correo = correo;
                cliente.TipoServicio = tipoServicio;
                cliente.DescripcionServicio = descripcionServicio;

                // Registrar el cliente
                Cliente.Registrar(cliente);

                // Mostrar mensaje de éxito
                MessageBox.Show("Guardado correctamente");
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error
                MessageBox.Show(ex.Message);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_3(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Hide();
          
            Buscar ventanaBuscar = new Buscar();
            ventanaBuscar.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Hide();
           
            Factura ventanaFactura = new Factura();
            ventanaFactura.Show();
        }
        private void Minimizar(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void Cerrar(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_c(object sender, RoutedEventArgs e)
        {
            this.Hide();

            MainWindow Inicio = new MainWindow();
            Inicio.Show();
        }

        private void Button_Click_L(object sender, RoutedEventArgs e)
        {
            Nombre.Text = "";
            Apellido.Text = "";
            Cedula.Text = "";
            Telefono.Text = "";
            Direccion.Text = "";
            Correo.Text = "";
            TipoServicio.Text = "";
            DescripcionServicio.Text = "";

        }
    }
}
