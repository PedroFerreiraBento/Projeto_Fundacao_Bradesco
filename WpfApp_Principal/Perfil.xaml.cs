using System;
using System.Collections.Generic;
using System.Data;
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

namespace WpfApp_Principal
{
    /// <summary>
    /// Lógica interna para Perfil.xaml
    /// </summary>
    public partial class Perfil : Window
    {
        public Perfil()
        {
            InitializeComponent();
            updateFields();
        }


        private void updateFields()
        {
            DataTable lgUser = (DataTable)App.Current.Properties["logged_user"];

            tb_nome.Text = lgUser.Rows[0]["Nome"].ToString();
            tb_saldo.Text = lgUser.Rows[0]["Saldo"].ToString();
            tb_meta.Text = lgUser.Rows[0]["Meta"].ToString();
            tb_email.Text = lgUser.Rows[0]["Email"].ToString();
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
