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

        private void Salvar(object sender, RoutedEventArgs e)
        {
            if (checkUpdateFields())
            {
                DBCon con = new DBCon();

                if (con.InitializeDB())
                {
                    DataTable lgUser = (DataTable)App.Current.Properties["logged_user"];

                    string[] parametros = new string[] { "@id_user", "@nome", "@saldo", "@meta" };
                    string[] valores = new string[] { lgUser.Rows[0]["Id"].ToString(), tb_nome.Text, tb_saldo.Text, tb_meta.Text };

                    con.ExecuteProcedure("update_perfil", parametros, valores);
                    con.updateUserData();
                }
            }
        }

        private bool checkUpdateFields()
        {
            var check = false;
            DataTable lgUser = (DataTable)App.Current.Properties["logged_user"];
            if (tb_nome.Text != lgUser.Rows[0]["Nome"].ToString())
            {
                if (lgUser.Rows[0]["Nome"].ToString().Length > 0)
                {
                    check = true;
                }
                else
                {
                    MessageBox.Show("Campo nome não pode estar vazio.");
                }
            }
            if (tb_nome.Text != lgUser.Rows[0]["Saldo"].ToString())
            {
                check = true;
            }
            if (tb_nome.Text != lgUser.Rows[0]["Meta"].ToString())
            {
                if (float.Parse(lgUser.Rows[0]["Meta"].ToString()) >= 0)
                {
                    check = true;
                }
                else
                {
                    check = false;
                    MessageBox.Show("Campo meta não pode ser negativo.");
                }
            }


            return check;
        }
    }
}
