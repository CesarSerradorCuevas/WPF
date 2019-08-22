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

namespace Bezier01
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
        Path pth1 = new Path();
        PathGeometry pthg1 = new PathGeometry();
        PathFigure pthf1 = new PathFigure();
        BezierSegment bs1 = new BezierSegment();

        Path pth2 = new Path();
        Path pth3 = new Path();
        Path pth4 = new Path();
        //GeometryGroup gg1 = new GeometryGroup();
        EllipseGeometry eg1;
        EllipseGeometry eg2;
        EllipseGeometry eg3;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            eg1 = new EllipseGeometry(new Point(100, 200), 10, 10);
            eg2 = new EllipseGeometry(new Point(100, 400), 10, 10);
            eg3 = new EllipseGeometry(new Point(400, 400), 10, 10);
            
            pth2.Data = eg1;
            pth2.Stroke = Brushes.White;
            pth2.StrokeThickness = 4;
            pth2.Fill = Brushes.White;

            pth3.Data = eg2;
            pth3.Stroke = Brushes.White;
            pth3.StrokeThickness = 4;
            pth3.Fill = Brushes.White;

            pth4.Data = eg3;
            pth4.Stroke = Brushes.White;
            pth4.StrokeThickness = 4;
            pth4.Fill = Brushes.White;

            bs1.Point1 = eg1.Center;
            bs1.Point2 = eg2.Center;
            bs1.Point3 = new Point(400, 400);         

            pthf1.Segments.Add(bs1);
            pthf1.StartPoint = new Point(100, 100);
            pthg1.Figures.Add(pthf1);
            pth1.Data = pthg1;
            pth1.Stroke = Brushes.White;
            pth1.StrokeThickness = 4;

            pth1.MouseEnter += new MouseEventHandler(mouseEnterX);
            pth1.MouseLeave += new MouseEventHandler(mouseLeaveX);

            pth2.MouseMove += new MouseEventHandler(mouseMovePth2);
            pth3.MouseMove += new MouseEventHandler(mouseMovePth3);
            pth4.MouseMove += new MouseEventHandler(mouseMovePth4);

            GridA.Children.Add(pth1);
            GridA.Children.Add(pth2);
            GridA.Children.Add(pth3);
            GridA.Children.Add(pth4);
        }

        void mouseEnterX(object sender, MouseEventArgs e)
        {
            TBA.Text = "Mouse Over Line: True";
        }

        void mouseLeaveX(object sender, MouseEventArgs e)
        {
            TBA.Text = "Mouse Over Line: false";
        }

        void mouseMovePth2(object sender, MouseEventArgs e)
        {
            
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                
                eg1.Center = e.GetPosition(this);
                bs1.Point1 = eg1.Center;
                
            }
            
        }

        void mouseMovePth3(object sender, MouseEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                
                eg2.Center = e.GetPosition(this);
                bs1.Point2 = eg2.Center;
                
            }
            
        }

        void mouseMovePth4(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {

                eg3.Center = e.GetPosition(this);
                bs1.Point3 = eg3.Center;

            }

        }
    }
}
