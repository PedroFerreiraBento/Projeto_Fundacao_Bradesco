using System;
using System.Collections.Generic;
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
            // adicionar_valorInvestido(lb_valorInvestido)
            //adicionar_dataAtual(dataAtual);
            //if(outraTaxa){
            //  adicionar_taxa(outraTaxa/100)
            //}else{
            // adicionar_taxa(6,25/100)
            //} 
            Close();
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
