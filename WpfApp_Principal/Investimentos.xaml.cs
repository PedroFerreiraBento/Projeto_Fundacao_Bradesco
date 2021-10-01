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

            //subtração diaAtual com o dia do investimento inserido
            //lucroInvestimento = investimentoOriginal? * (taxa/((diferença de dias - 365) * -1))
            //colocar a label lb_valorInvestido com o lucro investimento 
            

            double[] dias = { 5 /*lucroInvestimento*/, 4/*investimentoOriginal? * (taxa/((diferença de dias-1 - 365) * -1))*/, /*investimentoOriginal? * (taxa/((diferença de dias-2 - 365) * -1))*/ 3,
                2 /*investimentoOriginal? * (taxa/((diferença de dias-3 - 365) * -1))*/, 1  /*investimentoOriginal? * (taxa/((diferença de dias-4 - 365) * -1))*/ };

            graficoInvestimentos.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Values = new ChartValues<double> {dias[4], dias[3], dias[2], dias[1], dias[0]}
                },
            };

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
