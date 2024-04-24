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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using CreaSoft.Clases;
using static CreaSoft.Clases.Conexion;
namespace CreaSoft
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ConexionSQL _conexion;
        public MainWindow()
        {
            InitializeComponent();
            // Crear una instancia de la clase ConexionSQL
            _conexion = new ConexionSQL("Data Source=DESKTOP-FFL0MHR\\SQLEXPRESS;Initial Catalog=CreaSoft;Integrated Security=True");
            Loaded += MainWindow_Loaded;
           
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Abrir la conexión a la base de datos
            _conexion.AbrirConexion();

            // ... (ejecutar operaciones que requieren la conexión)

            // Cerrar la conexión (opcional)
            //_conexion.CerrarConexion();
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

        private void Button_ClickIN(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Usuario = usuario.Text;
            login.Contraseña = Contraseña.Password;
            login.Contraseña = txtPassword.Text;

            if (login.ValidarUsuario())
            {
                this.Hide();
                // Abrir la ventana Registro
                Registro ventanaRegistro = new Registro();
                ventanaRegistro.Show();
            }
            else
            {
                // Mostrar mensaje de error
                MessageBox.Show("Usuario o contraseña incorrectos");
            }



        }
        private void ImagenMouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void Cerrar (object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Enter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
               Button_ClickIN(sender, e);
            }
        }

        private void btnShowPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Contraseña.Visibility == Visibility.Visible)
            {
                Contraseña.Visibility = Visibility.Collapsed;
                txtPassword.Visibility = Visibility.Visible;
                txtPassword.Text = Contraseña.Password;
            }
            else
            {
                Contraseña.Visibility = Visibility.Visible;
                txtPassword.Visibility = Visibility.Collapsed;
            }
        }

    }
}

