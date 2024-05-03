using CreaSoft.Clases;
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

namespace CreaSoft
{
    /// <summary>
    /// Lógica de interacción para Costos.xaml
    /// </summary>
    public partial class Costos : Window
    {
        public Costos()
        {
            InitializeComponent();

        }

        private void Nombre_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Registro(object sender, RoutedEventArgs e)
        {
            this.Hide();

            Registro ventanaBuscar = new Registro();
            ventanaBuscar.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Busca(object sender, RoutedEventArgs e)
        {
            this.Hide();

            Buscar ventanaBuscar = new Buscar();
            ventanaBuscar.Show();
        }

        private void Factu(object sender, RoutedEventArgs e)
        {
            this.Hide();

            Factura ventanaBuscar = new Factura();
            ventanaBuscar.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_L(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_c(object sender, RoutedEventArgs e)
        {

        }
        private void Minimizar(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void Cerrar(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_Guardar(object sender, RoutedEventArgs e)
        {
            ActualizarDatosCliente actualizador = new ActualizarDatosCliente();
            actualizador.ActualizarCliente(Codigo_Cliente.Text, DateTime.Parse(Fecha_Inicio.Text), DateTime.Parse(Fecha_entrega.Text), decimal.Parse(Precio.Text));
        }
    }
}
