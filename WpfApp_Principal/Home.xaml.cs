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
using LiveCharts;
using LiveCharts.Wpf;



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
            lb_saldoTotal.Text = lgUser.Rows[0]["Saldo"].ToString();

            this.PieChart();
            List<double> saldoValues = new List<double>();
            List<double> gastosValues = new List<double>();

            DBCon con = new DBCon();
            if (con.InitializeDB())
            {
                // Grafico de linhas
                DataTable table = con.ExecuteSelect("LogSaldo", new string[] { "Saldo" },
                    "WHERE UsuarioFK = " + lgUser.Rows[0]["Id"].ToString());

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    saldoValues.Add(Convert.ToDouble(table.Rows[i]["Saldo"].ToString()));
                }

                // Grafico de Pizza
                //select Categoria, sum(Valor) from Agenda GROUP BY Categoria
                table = con.ExecuteSelect("Agenda", new string[] { "Categoria", "sum(Valor) as sm" },
                    "WHERE UsuarioFK = " + lgUser.Rows[0]["Id"].ToString() +
                    "GROUP BY Categoria");

                foreach(DataRow i in table.Rows)
                {

                    if(i["Categoria"].ToString() == "Outros")
                    {
                        graf_outros.Values = new ChartValues<double> { Convert.ToDouble(i["sm"].ToString()) };
                    }
                    if (i["Categoria"].ToString() == "CustosFixos")
                    {
                        graf_custosFixos.Values = new ChartValues<double> { Convert.ToDouble(i["sm"].ToString()) };
                    }
                    if (i["Categoria"].ToString() == "Diversos")
                    {
                        graf_diversos.Values = new ChartValues<double> { Convert.ToDouble(i["sm"].ToString()) };
                    }
                    if (i["Categoria"].ToString() == "Casa")
                    {
                        graf_casa.Values = new ChartValues<double> { Convert.ToDouble(i["sm"].ToString()) };
                    }
                    if (i["Categoria"].ToString() == "Cartão")
                    {
                        graf_cartao.Values = new ChartValues<double> { Convert.ToDouble(i["sm"].ToString()) };
                    }
                    if (i["Categoria"].ToString() == "Pessoal")
                    {
                        graf_pessoal.Values = new ChartValues<double> { Convert.ToDouble(i["sm"].ToString()) };
                    }
                }

                //for (int i = 0; i < table.Rows.Count; i++)
                //{
                //    saldoValues.Add(Convert.ToDouble(table.Rows[i]["Saldo"].ToString()));
                //}
            }

            graficoLinha.AxisY.Clear();
            graficoLinha.AxisX.Clear();

            graficoLinha.AxisY.Add(
            new Axis
            {
                MinValue = 0
            });
            graficoLinha.AxisX.Add(
            new Axis
            {
                MinValue = 0
            });
            graficoLinha.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Saldo",
                    Values = new ChartValues<double>(saldoValues)
                }
            };
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



        //Grafico grf1_Geral - visao geral da conta logada

        public Func<ChartPoint, string> PointLabel { get; set; }
        public void PieChart()
        {
            PointLabel = chartPoint => string.Format("{0}({1:P})", chartPoint.Y, chartPoint.Participation);
            DataContext = this;
        }

        private void PieChart_DataClick(object sender, ChartPoint chartPoint)
        {
            var chart = (LiveCharts.Wpf.PieChart)chartPoint.ChartView;
            foreach (PieSeries pieSeries in chart.Series)
                pieSeries.PushOut = 0;
            var seleccionarSeries = (PieSeries)chartPoint.SeriesView;
            seleccionarSeries.PushOut = 8;
        }

        private void Btn_agendaClick(object sender, RoutedEventArgs e)
        {
            Agenda agd = new Agenda();
            agd.Show();
            this.Close();
        }

        private void CartesianChart_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_investimentosClick(object sender, RoutedEventArgs e)
        {
            Investimentos invs = new Investimentos();
            invs.Show();
            this.Close();
        }


    }
}

