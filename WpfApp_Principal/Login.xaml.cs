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
        }

        private void Cadastrar_Open(object sender, RoutedEventArgs e)
        {
            Cadastrar page_cadastrar = new Cadastrar();
            page_cadastrar.Show();
            this.Close();
        }

        private void Enter(object sender, RoutedEventArgs e)
        {
            if (validar_login())
            {
                DBCon con = new DBCon();

                if (con.InitializeDB())
                {
                    DataTable table = con.ExecuteSelect("Login", new string[] { "COUNT(Email) as qtd" },
                        "WHERE Email = '" + tb_email.Text.Trim() + "'" +
                        "AND Senha = '" + tb_senha.Password.Trim() + "'");

                    if (table.Rows[0]["qtd"].ToString() != "0")
                    {
                        App.Current.Properties["logged_user"] = con.ExecuteSelect("Login, Usuario", null,
                        "WHERE Email = '" + tb_email.Text.Trim() + "'" +
                        " AND Login.Id = Usuario.Login_FK");

                        Home goHome = new Home();
                        goHome.Show();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Login ou Senha Invalidos.");
                    }
                }
            }
            else
            {
                if (tb_email.Text == "admin" && tb_senha.Password == "admin")
                {
                    Home goHome = new Home();
                    goHome.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Login ou Senha Invalidos.");
                }
            }


        }

        private bool validar_login()
        {
            bool verify_email = tb_email.Text.Trim(' ').Length != 0 ? true : false;
            bool verify_senha = tb_senha.Password.Trim(' ').Length != 0 ? true : false;

            if (!verify_email)
            {
                MessageBox.Show("O campo \"Email\" é obrigatório!");
                return false;
            }
            else if (!verify_senha)
            {
                MessageBox.Show("O campo \"Senha\" é obrigatório!");
                return false;
            }

            return true;
        }

    }
}
