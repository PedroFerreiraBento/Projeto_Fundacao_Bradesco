using System;
using System.Collections.Generic;
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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Set Conection
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.Con_Str;

            // SQL Query
            //string queryInsert = "INSERT INTO tabela(nome) VALUES (@nome)";
            //SqlCommand sql_Insert = new SqlCommand(queryInsert, con);
            //sql_Insert.Parameters.Add(new SqlParameter("@nome", "Pedro"));

            // Execute Query
            con.Open();
            //sql_Insert.ExecuteNonQuery();
            MessageBox.Show("Conexao Realizada");
            con.Close();

        }
    }
}
