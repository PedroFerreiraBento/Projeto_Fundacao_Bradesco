﻿using System;
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
    /// Interaction logic for Financias.xaml
    /// </summary>
    public partial class Financias : Window
    {
        public Financias()
        {
            InitializeComponent();

            float meta_definida = 1200;
            float total_dinheiro = 420;

            lb_saldo.Content = total_dinheiro;

            lb_meta.Content = meta_definida - total_dinheiro;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Home goHome = new Home();
            goHome.Show();
            Close();
        }

        private void btn_definirMetaNova(object sender, RoutedEventArgs e)
        {
            DefinirMeta openDefinirMeta = new DefinirMeta();
            openDefinirMeta.Show();
        }

        private void Btn_minhasFinancas_Click(object sender, RoutedEventArgs e)
        {
            AddRmSaldo openAddRmSaldo = new AddRmSaldo();
            openAddRmSaldo.Show();
        }
    }
}