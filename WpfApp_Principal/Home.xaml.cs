using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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


namespace WpfApp_Principal
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
            DataTable lgUser = (DataTable)App.Current.Properties["logged_user"];

        }

        private void Btn_minhasFinancas_Click(object sender, RoutedEventArgs e)
        {
            Financias goFinancias = new Financias();
            goFinancias.Show();
            Close();
        }

        private void AbrirPerfil(object sender, RoutedEventArgs e)
        {
            Perfil p = new Perfil();
            p.Show();
            this.Close();
        }

        private void AbrirHome(object sender, RoutedEventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Close();
        }
        private void Sair(object sender, RoutedEventArgs e)
        {
            App.Current.Properties["logged_user"] = null;
            Login l = new Login();
            l.Show();
            this.Close();
        }

    }
}
//TESTE
