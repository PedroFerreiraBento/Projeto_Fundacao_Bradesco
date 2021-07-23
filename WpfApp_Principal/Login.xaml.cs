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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace WpfApp_Principal
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            MessageBox.Show("Ola");
        }

        private void Cadastrar_Open(object sender, RoutedEventArgs e)
        {
            Cadastrar page_cadastrar = new Cadastrar();
            page_cadastrar.Show();
            this.Close();
        }

        private void Enter(object sender, RoutedEventArgs e)
        {
            if (tb_email.Text == "admin" && tb_senha.Text == "admin")
            {
                Home page_home = new Home();

                Application.Current.Properties["x"] = "xxxx";
                

                page_home.Show();
                this.Close();
            }
        }


    }
}
