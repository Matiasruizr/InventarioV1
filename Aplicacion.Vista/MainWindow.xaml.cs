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
using Aplicacion.DALC;

namespace Aplicacion.Vista
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static INVENTARIOV1Entities conector; //Generar como elemento estatico para acceder desde otra capa

        public MainWindow()
        {
            InitializeComponent();
            if (conector == null)
            {
                conector = new INVENTARIOV1Entities();
            }
        }
   
        private void btnAgregarObjeto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OBJETO o = new OBJETO();

                o.ID_OBJETO = txtIdObjeto.Text;
                o.NOMBRE = txtNombreObjeto.Text;
                o.CANTIDAD = Int32.Parse(txtCantidadObjeto.Text);
                o.PRECIO = Int32.Parse(txtPrecioObjeto.Text);
                o.MARCA = txtMarcaobjeto.Text;

                conector.OBJETOes.Add(o);
                conector.SaveChanges();

                MessageBox.Show("Se agrego correctamente");
            }catch( Exception ex){
                MessageBox.Show(ex.ToString());
            }
           
        }

        private void btnListarObjetos_Click(object sender, RoutedEventArgs e)
        {
            dtgListarObjetos.ItemsSource = null;
            dtgListarObjetos.ItemsSource = conector.OBJETOes.ToList();
        }

        private void btnEliminarObjeto_Click(object sender, RoutedEventArgs e)
        {
            try{
                OBJETO o = conector.OBJETOes.First(
                  ob => ob.ID_OBJETO == this.txtEliminarObjeto.Text
                  );

                conector.OBJETOes.Remove(o);
                conector.SaveChanges();
                MessageBox.Show("Se elimino");
            } catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
          
        }
    }
}
