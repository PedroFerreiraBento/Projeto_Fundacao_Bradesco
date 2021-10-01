using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;

namespace WpfApp_Principal
{
    /// <summary>
    /// Interaction logic for Investimentos.xaml
    /// </summary>
    public partial class Investimentos : Window
    {


        public Investimentos()
        {
            InitializeComponent();

            string dataAtual = DateTime.Now.ToString("yyyy-M-d");
            string[] dataAtual1 = dataAtual.Split('-');
            double diaAtual = Convert.ToDouble(dataAtual1[2]);

            DBCon con = new DBCon();
            DataTable lgUser = (DataTable)App.Current.Properties["logged_user"];
            double VI, AA = 0;
            string DI = "";
            if (con.InitializeDB())
            {
                DataTable table = con.ExecuteSelect("Investimento", new string[] { "ValorInvestido", "AumentoAno", "AnoInvestimento" },
                    "WHERE UsuarioFK = " + lgUser.Rows[0]["Id"].ToString());
                if(table.Rows.Count > 0)
                {
                    VI = double.Parse(table.Rows[0]["ValorInvestido"].ToString());
                    AA = double.Parse(table.Rows[0]["AumentoAno"].ToString());
                    DI = table.Rows[0]["AumentoAno"].ToString();

                    DI = DI.Split('-')[2];


                    int DataSub = 5 - int.Parse(DI);
                    double lucroInvestimento = VI * (AA / ((DataSub - 365) * -1));
                    double[] dias = { lucroInvestimento, VI * (AA/((DataSub-1 - 365) * -1)), VI * (AA/((DataSub-1 - 365) * -3)),
                VI * (AA/((DataSub-1 - 365) * -5)), VI * (AA/((DataSub-1 - 365) * - 10))};
                    graficoInvestimentos.Series = new SeriesCollection
                    {
                        new LineSeries
                        {
                            Values = new ChartValues<double> {dias[4], dias[3], dias[2], dias[1], dias[0]}
                        },
                    };
                    lb_valorInvestido.Content = lucroInvestimento;
                }
            }





        }

        private void Btn_novoInvestimentoClick(object sender, RoutedEventArgs e)
        {
            NovoInvestimento novoInvestimento = new NovoInvestimento();
            novoInvestimento.Show();
        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }

        private void Btn_removerInvestimentoClick(object sender, RoutedEventArgs e)
        {

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
