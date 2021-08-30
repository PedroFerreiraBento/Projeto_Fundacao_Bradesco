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
    /// Interaction logic for AddRmSaldo.xaml
    /// </summary>
    public partial class AddRmSaldo : Window
    {
        public AddRmSaldo()
        {
            InitializeComponent();
        }

        private void add_saldo_Click(object sender, RoutedEventArgs e)
        {
            adicionar_remover(sender, e, true);
        }

        private void rm_saldo_Click(object sender, RoutedEventArgs e)
        {
            adicionar_remover(sender, e, false);
        }

        private void adicionar_remover(object sender, RoutedEventArgs e, bool Adicionar)
        {
            if (string.IsNullOrEmpty(lb_saldo.Text) || string.IsNullOrEmpty(lb_data.Text))
            {
                MessageBox.Show("Campos vazios");
                return;
            }

            try
            {
                float.Parse(lb_saldo.Text);

            }
            catch
            {
                MessageBox.Show("O campo saldo só aceita números!");
                return;
            }

            float salario = float.Parse(lb_saldo.Text);
            string data = lb_data.Text;

            if (Adicionar)
            {
                //conexão com o banco
                MessageBox.Show("Dinheiro adicionado!");
            }
            else
            {
                //conexão com o banco
                MessageBox.Show("Dinheiro removido!");

            }
            Close();
        }
    }
}
