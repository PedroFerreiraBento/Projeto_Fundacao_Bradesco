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
    public partial class Cadastrar : Window
    {
        public Cadastrar()
        {
            InitializeComponent();
        }

        private void Login_Open(object sender, RoutedEventArgs e)
        {
            Login page_login = new Login();
            page_login.Show();
            this.Close();
        }

        private void register(object sender, RoutedEventArgs e)
        {
            if (validar_registro())
            {
                DBCon con = new DBCon();

                if (con.InitializeDB())
                {
                    string[] parametros = new string[] { "@nome", "@email", "@senha" };
                    string[] valores = new string[] { tb_nome.Text, tb_email.Text, tb_senha.Password };

                    con.ExecuteProcedure("Register", parametros, valores);

                    MessageBox.Show("Cadastro concluido!");
                    limpar_campos();

                    Login goToLogin = new Login();
                    goToLogin.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Não foi possivel se conectar ao banco de dados. Entre em contato com o responsavel.");
                }
            }
        }

        private bool validar_registro()
        {
            bool verify_nome = tb_nome.Text.Trim(' ').Length != 0 ? true : false;
            bool verify_email = tb_email.Text.Trim(' ').Length != 0 ? true : false;
            bool verify_senha = tb_senha.Password.Trim(' ').Length != 0 ? true : false;
            bool verify_senha_confirmar = tb_senha_confirmar.Password.Trim(' ').Length != 0 ? true : false;
            bool verify_senhas_iguais = tb_senha.Password == tb_senha_confirmar.Password ? true : false;

            if (!verify_nome)
            {
                MessageBox.Show("O campo \"Nome\" é obrigatório!");
                return false;
            }
            else if (!verify_email)
            {
                MessageBox.Show("O campo \"Email\" é obrigatório!");
                return false;
            }
            else if (!verify_senha)
            {
                MessageBox.Show("O campo \"Senha\" é obrigatório!");
                return false;
            }
            else if (!verify_senha_confirmar)
            {
                MessageBox.Show("O campo \"Confirmar senha\" é obrigatório!");
                return false;
            }
            else if (!verify_senhas_iguais)
            {
                MessageBox.Show("Senhas divergentes!");
                return false;
            }

            return true;
        }
        private void limpar_campos()
        {
            tb_nome.Clear();
            tb_email.Clear();
            tb_senha.Clear();
            tb_senha_confirmar.Clear();
        }
    }
}
