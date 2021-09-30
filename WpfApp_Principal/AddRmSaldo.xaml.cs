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
            if (cb_categoria.IsEnabled)
            {
                adicionar_remover(sender, e, false);
            }
            else
            {
                cb_categoria.IsEnabled = true;
                cb_categoria.Focus();
            }
        }

        private void adicionar_remover(object sender, RoutedEventArgs e, bool Adicionar)
        {
            if (string.IsNullOrEmpty(lb_saldo.Text))
            {
                MessageBox.Show("Preencha o campo valor");
                return;
            }

            try
            {
                DBCon con = new DBCon();

                if (con.InitializeDB())
                {
                    DataTable lgUser = (DataTable)App.Current.Properties["logged_user"];
                    string[] parametros, valores;
                    if (string.IsNullOrEmpty(lb_data.Text))
                    {
                        if (Adicionar)
                        {
                            parametros = new string[] { "@usuario", "@valor", "@tipo" };
                            valores = new string[] {
                                lgUser.Rows[0]["Id"].ToString(),
                                lb_saldo.Text,
                                Convert.ToInt32(Adicionar).ToString()
                            };
                        }
                        else
                        {
                            parametros = new string[] { "@usuario", "@valor", "@tipo", "@categoria" };
                            valores = new string[] {
                                lgUser.Rows[0]["Id"].ToString(),
                                lb_saldo.Text,
                                Convert.ToInt32(Adicionar).ToString(),
                                (cb_categoria.SelectedItem as ListBoxItem).Content.ToString()
                            };
                        }
                    }
                    else
                    {
                        if (Adicionar)
                        {
                            parametros = new string[] { "@usuario", "@valor", "@tipo", "@dataParaInserir" };
                            valores = new string[] {
                                lgUser.Rows[0]["Id"].ToString(),
                                lb_saldo.Text,
                                Convert.ToInt32(Adicionar).ToString(),
                                lb_data.Text
                            };
                        }
                        else
                        {
                            parametros = new string[] { "@usuario", "@valor", "@tipo", "@dataParaInserir", "@categoria" };
                            valores = new string[] {
                                lgUser.Rows[0]["Id"].ToString(),
                                lb_saldo.Text,
                                Convert.ToInt32(Adicionar).ToString(),
                                lb_data.Text,
                                (cb_categoria.SelectedItem as ListBoxItem).Content.ToString()
                            };
                        }
                    }
                    

                    con.ExecuteProcedure("update_saldo", parametros, valores);
                    con.updateUserData();
                }

            }
            catch
            {
                MessageBox.Show("Ocorreu um erro inesperado, tente novamente!");
                return;
            }

            
            if (Adicionar)
            {
                MessageBox.Show("O valor será adcionado na data informada!");
            }
            else
            {
                MessageBox.Show("O valor será retirado na data informada!");
            }
            Close();
        }



        private void cb_date_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string comboItem = (e.AddedItems[0] as ComboBoxItem).Tag as string;
            if(comboItem == "2")
            {
                foreach (var cmbi in cb_date.Items.Cast<ComboBoxItem>().Where(cmbi => (string)cmbi.Tag == 1.ToString()))
                    cmbi.IsSelected = true;
                cb_date.Visibility = Visibility.Hidden;
                gridDataSelect.Visibility = Visibility.Visible;
            }
        }


        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            cb_date.Visibility = Visibility.Visible;
            gridDataSelect.Visibility = Visibility.Hidden;
            lb_data.Text = "";

        }

    }
}
