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
            this.PieChart();
        }

        private void Btn_minhasFinancas_Click(object sender, RoutedEventArgs e)
        {
            Financias goFinancias = new Financias();
            goFinancias.Show();
            Close();
        }

        //Grafico grf1_Geral - visao geral da conta logada

        public Func<ChartPoint, string> PointLabel { get; set; }
        public void PieChart()
        {
            PointLabel = chartPoint => string.Format("{0}({1:P})", chartPoint.Y , chartPoint.Participation);
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
    }
}

