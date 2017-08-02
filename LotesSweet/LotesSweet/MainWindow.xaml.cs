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
using com.sweetandcoffee.LogicaNegocio;
using com.sweetandcoffee.Entidades;
using System.Configuration;

namespace LotesSweet
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LotesBol lotes = new LotesBol();
            Lotes.ItemsSource = lotes.Todos();
        }

        private void btnCorregir_Click(object sender, RoutedEventArgs e)
        {
            ELote lote = ((Button)sender).Tag as ELote;
            /*
            
            MessageBox.Show(lote.Descripcion);
            */
            Diferencias diferencias = new Diferencias(lote.Codigo,lote.Diferencia);
            diferencias.Owner = this;
            diferencias.ShowDialog();
        }

        private void btnImprimirDiferencias_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
