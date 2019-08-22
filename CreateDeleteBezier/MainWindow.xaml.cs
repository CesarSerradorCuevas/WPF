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

namespace Bezier03
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
 
        PathGeometry pathGeo1;
        PathFigure pathFigure1;
        BezierSegment bezier1;
        Path[] pathArray = new Path[100];

        LinearGradientBrush myBrush;
        int curveModeCounter = 0;
        int pathCounter = 0;
        bool drawLineOnOff = false;
        Vector controlPointDirectionOne;

        public MainWindow()
        {
            InitializeComponent();
            bezier1 = new BezierSegment();
            pathFigure1 = new PathFigure();
            controlPointDirectionOne = new Vector();

            myBrush = new LinearGradientBrush();
            myBrush.GradientStops.Add(new GradientStop(Color.FromRgb(0, 255, 0), 0.0));
            myBrush.GradientStops.Add(new GradientStop(Color.FromRgb(0, 200, 0), 1.0));

        }

        private void GridA_MouseMove(object sender, MouseEventArgs e)
        {
            
            controlPointDirectionOne = pathFigure1.StartPoint - e.GetPosition(this);           

            bezier1.Point1 = pathFigure1.StartPoint + new Vector((controlPointDirectionOne.X * 0.5)* -1, 0);
            bezier1.Point2 = e.GetPosition(this) + new Vector(controlPointDirectionOne.X * 0.5, 0);
            bezier1.Point3 = e.GetPosition(this);
        }

        private void GridA_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            if (e.LeftButton == MouseButtonState.Pressed && drawLineOnOff == true)
            {

                curveModeCounter++;               

                if (curveModeCounter == 1)
                {
                    bezier1.Point1 = e.GetPosition(this) + new Vector(100, 0);                  
                   
                    pathFigure1.StartPoint = e.GetPosition(this);
                    pathFigure1.Segments.Add(bezier1);

                    pathGeo1 = new PathGeometry();
                    pathGeo1.Figures.Add(pathFigure1);

                    pathArray[pathCounter] = new Path();
                    pathArray[pathCounter].Stroke = myBrush;
                    pathArray[pathCounter].StrokeThickness = 4;
                    pathArray[pathCounter].StrokeDashArray = new DoubleCollection() { 2, 1 };
                    pathArray[pathCounter].StrokeDashOffset = 0;
                    pathArray[pathCounter].Focusable = true;
                    pathArray[pathCounter].Data = pathGeo1;
                    pathArray[pathCounter].Name = "path" + pathCounter.ToString();                   
                    

                    pathArray[pathCounter].MouseDown += new MouseButtonEventHandler((object s1, MouseButtonEventArgs e1) => {

                        if (e1.LeftButton == MouseButtonState.Pressed && curveModeCounter == 0)
                        {
                            for (int i = 0; i < pathCounter; i++)
                            {
                                if (pathArray[i].IsMouseOver)
                                {
                                    pathArray[i].Stroke = Brushes.Aqua;
                                    pathArray[i].Focus();
                                    TBB.Text = "Path Name: " + pathArray[i].Name;
                                }
                            }
                            

                        }
                    });

                    pathArray[pathCounter].KeyDown += new KeyEventHandler((object s1, KeyEventArgs e1) => {

                        if (e1.Key == Key.Delete)
                        {

                            for (int i = 0; i < pathCounter; i++)
                            {
                                if (pathArray[i].IsFocused)
                                {
                                    GridA.Children.Remove(pathArray[i]);
                                    pathArray[i] = new Path();
                                }
                            }

                            

                        }
                    });
                    
                    pathArray[pathCounter].MouseLeave += new MouseEventHandler((object s1, MouseEventArgs e1) => {


                        for (int i = 0; i < pathCounter; i++)
                        {
                            if (pathArray[i].IsFocused)
                            {
                                pathArray[i].Stroke = myBrush;
                            }
                        }
                        

                    });
                                       

                    GridA.Children.Add(pathArray[pathCounter]);

                    

                }
                if (curveModeCounter == 2)
                {

                    pathArray[pathCounter].StrokeDashArray = null;
                    

                    curveModeCounter = 0;
                    bezier1 = new BezierSegment();
                    pathFigure1 = new PathFigure();

                    pathCounter++;
                }


                
            }
            /*
            if (e.LeftButton == MouseButtonState.Pressed && drawLineOnOff == false)
            {
                TBB.Text = "";

                for (int i = 0; i < pathCounter; i++)
                    {
                        
                        TBB.Text += "Path Name: " + pathArray[i]?.Name.ToString() + "\n";
                    }
                

            }
            */
        }

        private void GridA_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (curveModeCounter == 0)
            {
                drawLineOnOff = false;
                TBA.Text = "OFF";
                TBA.Foreground = Brushes.LightPink;
                curveModeCounter = 0;
            }
            
            
        }

        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            drawLineOnOff = true;
            TBA.Text = "ON";
            TBA.Foreground = Brushes.LightGreen;
        }
    }
}
