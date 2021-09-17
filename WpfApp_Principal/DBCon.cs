using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp_Principal
{
    class DBCon
    {
        // Set Conection
        SqlConnection conexao;

        public bool InitializeDB()
        {
            try
            {
                conexao = new SqlConnection();
                conexao.ConnectionString = Properties.Settings.Default.Con_Str;
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return false;
            }
            
        }
        public bool ExecuteProcedure(string name, string[] parameters, string[] values)        {
            try
            {
                SqlCommand sql_query = new SqlCommand(name, this.conexao);
                sql_query.CommandType = CommandType.StoredProcedure;

                for (int i = 0; i < parameters.Length; i++)
                {
                    sql_query.Parameters.AddWithValue(parameters[i], values[i]);
                }

                conexao.Open();
                sql_query.ExecuteNonQuery();
                conexao.Close();

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return false;
            }
        }

        public DataTable ExecuteSelect(string table, string[] parameters = null, string condition = "")
        {
            try
            {
                // Montar a query
                string selectQuery = "SELECT ";
                selectQuery += parameters != null ? string.Join(", ", parameters) : "* ";
                selectQuery += " FROM " + table + " " + condition;
                //MessageBox.Show(selectQuery);
                
                // Preparar o comando
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(selectQuery, this.conexao);
                
                // Recebimento de valores
                DataTable dt = new DataTable();
                dt.Clear();
                adapter.Fill(dt);

                return dt;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return new DataTable();
            }
        }

        public DataTable updateUserData() {
            var dadosAtuais = (DataTable)App.Current.Properties["logged_user"];
            var userData = dadosAtuais.Rows[0];

            App.Current.Properties["logged_user"] = this.ExecuteSelect("Login, Usuario", null,
                            "WHERE Email = '" + userData["Email"] + "'" +
                            " AND Login.Id = Usuario.Login_FK");

            dadosAtuais = (DataTable)App.Current.Properties["logged_user"];
            return dadosAtuais;
        }
    }
}
