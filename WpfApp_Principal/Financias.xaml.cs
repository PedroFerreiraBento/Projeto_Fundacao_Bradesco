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
    /// Interaction logic for Financias.xaml
    /// </summary>
    public partial class Financias : Window
    {
        public Financias()
        {
            InitializeComponent();
            updateFields();
        }


        private void btn_definirMetaNova(object sender, RoutedEventArgs e)
        {
            DefinirMeta openDefinirMeta = new DefinirMeta();
            openDefinirMeta.Show();
        }

        private void Btn_minhasFinancas_Click(object sender, RoutedEventArgs e)
        {
            AddRmSaldo openAddRmSaldo = new AddRmSaldo();
            openAddRmSaldo.Show();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            updateFields();
        }

        public void updateFields()
        {
            DataTable lgUser = (DataTable)App.Current.Properties["logged_user"];

            float meta_definida = float.Parse(lgUser.Rows[0]["Meta"].ToString());
            float total_dinheiro = float.Parse(lgUser.Rows[0]["Saldo"].ToString());

            lb_saldo.Content = total_dinheiro;
            lb_metaAtual.Content = meta_definida;
            lb_meta.Content = (meta_definida - total_dinheiro) >= 0 ? (meta_definida - total_dinheiro) : 0;
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
