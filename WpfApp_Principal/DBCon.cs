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

        // SQL Query

        // Execute Query
    }
}
