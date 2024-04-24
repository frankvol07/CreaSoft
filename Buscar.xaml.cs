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
using static CreaSoft.Clases.Clientes;

namespace CreaSoft
{
    /// <summary>
    /// Lógica de interacción para Buscar.xaml
    /// </summary>
    public partial class Buscar : Window
    {
        private string connectionString = "Data Source=DESKTOP-FFL0MHR\\SQLEXPRESS;Initial Catalog=CreaSoft;Integrated Security=True";

        public Buscar()
        {

            InitializeComponent();
        }
      

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            
            Registro ventanaRegistro = new Registro();
            ventanaRegistro.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var codigo = Busqueda.Text;

            if (string.IsNullOrEmpty(codigo))
            {
                MessageBox.Show("Debe ingresar un código para realizar la búsqueda");
                return;
            }

            var cliente = Cliente.BuscarPorCodigo(codigo);

            if (cliente == null)
            {
                MessageBox.Show("No se encontró ningún cliente con el código " + codigo);
                return;
            }

            // Mostrar la información del cliente encontrado en un DataGrid
            DATAClientes.ItemsSource = new List<Cliente>() { cliente };
        }

        private void Button_Click_Eliminar(object sender, RoutedEventArgs e)
        {
            var codigo = Busqueda.Text;

            if (string.IsNullOrEmpty(codigo))
            {
                MessageBox.Show("Debe ingresar un código para eliminar un cliente");
                return;
            }

            var cliente = Cliente.BuscarPorCodigo(codigo);

            if (cliente == null)
            {
                MessageBox.Show("No se encontró ningún cliente con el código " + codigo);
                return;
            }

            var resultado = MessageBox.Show("¿Está seguro de eliminar el cliente " + cliente.Nombre + "?", "Eliminar cliente", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (resultado == MessageBoxResult.Yes)
            {
                cliente.Eliminar(codigo);
                MessageBox.Show("Cliente eliminado con éxito");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Hide();

            MainWindow Inicio = new MainWindow();
            Inicio.Show();
        }

        private void Button_Click_Act(object sender, RoutedEventArgs e)
        {
            Clientes clientes = new Clientes(connectionString);
            clientes.MostrarDatosCliente(DATAClientes);
        }
    }
    }

