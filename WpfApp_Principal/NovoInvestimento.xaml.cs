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
    /// Interaction logic for NovoInvestimento.xaml
    /// </summary>
    public partial class NovoInvestimento : Window
    {
        Boolean outraTaxa;
        public NovoInvestimento()
        {
            InitializeComponent();
        }

        private void add_investimento_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(lb_valorInvestido.Text))
            {
                MessageBox.Show("Campo vazio");
                return;
            }

            MessageBox.Show("Investimento Adicionado!");

            //pseudo código
            try
            {
                DBCon con = new DBCon();

                if (con.InitializeDB())
                {
                    DataTable lgUser = (DataTable)App.Current.Properties["logged_user"];
                    string[] parametros, valores;

                    parametros = new string[] { "@usuario", "@valor", "@aumentoAno" };
                    string taxa;
                    if (outraTaxa)
                    {
                        taxa = (double.Parse(lb_outraTaxa.Text) / 100).ToString();
                    }
                    else
                    {
                        taxa = (6.25 / 100).ToString();
                    }
                    
                    valores = new string[] {
                        lgUser.Rows[0]["Id"].ToString(),
                        lb_valorInvestido.Text,
                        taxa
                    };
                    con.ExecuteProcedure("insert_investimento", parametros, valores);
                    con.updateUserData();

                    Close();
                }
            }
            catch
            {
                MessageBox.Show("Ocorreu um erro inesperado, tente novamente!");
                return;
            }
        }

        private void outraTaxa_Checked(object sender, RoutedEventArgs e)
        {
            outraTaxa = true;
        }
        private void taxaSelic_Checked(object sender, RoutedEventArgs e)
        {
            outraTaxa = false;
        }
    }
}
