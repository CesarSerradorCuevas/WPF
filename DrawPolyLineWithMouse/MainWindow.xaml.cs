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

namespace PolyLineTest
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        bool drawLine;
        int counter = 0;
        Polyline pl1 = new Polyline();
        PointCollection pc1 = new PointCollection();
        Point p1 = new Point();
        Line l1 = new Line();     


        private void GridA_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                drawLine = true;

                l1.Stroke = new SolidColorBrush(Colors.White);
                l1.StrokeThickness = 6;
                l1.StrokeStartLineCap = PenLineCap.Round;

                if (counter > 0)
                {
                    GridA.Children.Remove(pl1);
                }
                
                pl1.Stroke = new SolidColorBrush(Colors.White);
                pl1.StrokeThickness = 6;
                pl1.StrokeLineJoin = PenLineJoin.Round;
                pl1.StrokeStartLineCap = PenLineCap.Round;
                pl1.StrokeEndLineCap = PenLineCap.Round;
                p1 = e.GetPosition(this);
                pc1.Add(p1);
                pl1.Points = pc1;
               
                
                GridA.Children.Add(pl1);
                counter++;

            }

        }

        private void GridA_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.RightButton == MouseButtonState.Pressed)
            {
                drawLine = false;
                GridA.Children.Remove(l1);
                counter = 0;
                pl1 = new Polyline();
                pc1 = new PointCollection();
            }
            
        }
     

        private void GridA_MouseMove(object sender, MouseEventArgs e)
        {
            if (counter != 0 && drawLine == true)
            {
                GridA.Children.Remove(l1);
                l1.X1 = pc1[pc1.Count - 1].X;
                l1.Y1 = pc1[pc1.Count - 1].Y;
                l1.X2 = e.GetPosition(this).X;
                l1.Y2 = e.GetPosition(this).Y;

                GridA.Children.Add(l1);
            }
        }
    }
}
