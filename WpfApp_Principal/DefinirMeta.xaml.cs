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
    /// Interaction logic for DefinirMeta.xaml
    /// </summary>
    public partial class DefinirMeta : Window
    {
        public DefinirMeta()
        {
            InitializeComponent();
        }

        private void definir_meta_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(lb_meta.Text))
            {
                MessageBox.Show("Campo vazio");
                return;
            }

            try
            {
                DBCon con = new DBCon();

                if (con.InitializeDB())
                {
                    DataTable lgUser = (DataTable)App.Current.Properties["logged_user"];

                    string[] parametros = new string[] { "@id_user", "@newMeta" };
                    string[] valores = new string[] { lgUser.Rows[0]["Id"].ToString(), lb_meta.Text };

                    con.ExecuteProcedure("update_meta", parametros, valores);
                    con.updateUserData();
                }

            }
            catch
            {
                MessageBox.Show("Somente números no campo meta!");
                return;
            }

            MessageBox.Show("Meta definida!");
            Close();
        }
    }
}
