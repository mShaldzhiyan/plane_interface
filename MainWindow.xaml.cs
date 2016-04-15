using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.ComponentModel;
using AirportLib.Plane;

namespace plane_interface
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PlaneConnection planecon = new PlaneConnection();
        List<PlaneContainer> planes = new List<PlaneContainer>();

        public MainWindow()
        {
            InitializeComponent();
            planes = planecon.PsInfo();
            PlanesList.ItemsSource = planes;
        }

        private void Refresh()
        {
            planes = planecon.PsInfo();
            PlanesList.ItemsSource = null;
            PlanesList.ItemsSource = planes;
        }


        private void PlanesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            planeInfo.Text = "";
            foreach (object o in PlanesList.SelectedItems)
            {
                planeInfo.Text += "Название: " +(o as PlaneContainer).Name + Environment.NewLine;
                planeInfo.Text += "Вместимость топливо: " + (o as PlaneContainer).CFuelcap + Environment.NewLine;
                planeInfo.Text += "Вместимость эконом: " + (o as PlaneContainer).CPpleco + Environment.NewLine;
                planeInfo.Text += "Вместимость вип: " + (o as PlaneContainer).CPplvip + Environment.NewLine;
                planeInfo.Text += "Готов к вылету: " + (o as PlaneContainer).IsReady + Environment.NewLine;
            }
                
        }

        private void buttonRefresh_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}
