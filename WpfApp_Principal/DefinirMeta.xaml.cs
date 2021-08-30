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
                float.Parse(lb_meta.Text);

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
