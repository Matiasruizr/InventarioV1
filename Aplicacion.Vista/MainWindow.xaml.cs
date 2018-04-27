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
    }
}
