using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SelectionInCanvas01
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RectangleGeometry selectBox;
        Rect recTemp;
        RectangleGeometry recHitResult;
        Path pth1;
        Point mouseFirstClick;
        int mouseSelectionCounter;
        DoubleAnimation myDoubleAnimation;
        List<Path> hits = new List<Path>();
        

        public MainWindow()
        {
            InitializeComponent();

            selectBox = new RectangleGeometry();
            recTemp = new Rect();
            pth1 = new Path();
            recHitResult = new RectangleGeometry();

            Rect rec1 = new Rect(100, 50, 50, 50);

            RectangleGeometry myRectangleGeometry1 = new RectangleGeometry();
            myRectangleGeometry1.Rect = rec1;
            
            FormattedText ft1 = new FormattedText("Cesar", CultureInfo.GetCultureInfo("es-ES"), FlowDirection.LeftToRight, new Typeface("Verdana"), 12, Brushes.White, VisualTreeHelper.GetDpi(this).PixelsPerDip);

            GeometryGroup gg1 = new GeometryGroup();

            gg1.Children.Add(myRectangleGeometry1);
            gg1.Children.Add(ft1.BuildGeometry(new Point(rec1.Location.X + 7, rec1.Location.Y + 15)));

            Path myPath1 = new Path();
            myPath1.Fill = Brushes.LemonChiffon;
            myPath1.Stroke = Brushes.Black;
            myPath1.StrokeThickness = 1;
            myPath1.Data = gg1;
            myPath1.Name = "Cesar";


            Rect rec2 = new Rect(100, 150, 50, 50);

            RectangleGeometry myRectangleGeometry2 = new RectangleGeometry();
            myRectangleGeometry2.Rect = rec2;

            FormattedText ft2 = new FormattedText("Isabel", CultureInfo.GetCultureInfo("es-ES"), FlowDirection.LeftToRight, new Typeface("Verdana"), 12, Brushes.White, VisualTreeHelper.GetDpi(this).PixelsPerDip);

            GeometryGroup gg2 = new GeometryGroup();

            gg2.Children.Add(myRectangleGeometry2);
            gg2.Children.Add(ft2.BuildGeometry(new Point(rec2.Location.X + 7, rec2.Location.Y + 15)));

            Path myPath2 = new Path();
            myPath2.Fill = Brushes.LemonChiffon;
            myPath2.Stroke = Brushes.Black;
            myPath2.StrokeThickness = 1;
            myPath2.Data = gg2;
            myPath2.Name = "Isabel";


            Rect rec3 = new Rect(100, 250, 50, 50);

            RectangleGeometry myRectangleGeometry3 = new RectangleGeometry();
            myRectangleGeometry3.Rect = rec3;

            FormattedText ft3 = new FormattedText("Nuria", CultureInfo.GetCultureInfo("es-ES"), FlowDirection.LeftToRight, new Typeface("Verdana"), 12, Brushes.White, VisualTreeHelper.GetDpi(this).PixelsPerDip);

            GeometryGroup gg3 = new GeometryGroup();

            gg3.Children.Add(myRectangleGeometry3);
            gg3.Children.Add(ft3.BuildGeometry(new Point(rec3.Location.X + 7, rec3.Location.Y + 15)));

            Path myPath3 = new Path();
            myPath3.Fill = Brushes.LemonChiffon;
            myPath3.Stroke = Brushes.Black;
            myPath3.StrokeThickness = 1;
            myPath3.Data = gg3;
            myPath3.Name = "Nuria";

            GridA.Children.Add(myPath1);
            GridA.Children.Add(myPath2);
            GridA.Children.Add(myPath3);

        }

        private void GridA_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            mouseSelectionCounter++;
            mouseFirstClick = InputManager.Current.PrimaryMouseDevice.GetPosition(this);

            myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = 1;
            myDoubleAnimation.To = 0.5;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.5));
            myDoubleAnimation.AutoReverse = true;
            myDoubleAnimation.RepeatBehavior = RepeatBehavior.Forever;

            pth1.BeginAnimation(Path.OpacityProperty, myDoubleAnimation);

        }

        private void GridA_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && mouseSelectionCounter == 1)
            {
                GridA.Children.Remove(pth1);

                recTemp = new Rect(mouseFirstClick, e.GetPosition(this) - mouseFirstClick);               
                selectBox.Rect = recTemp;
                pth1.Data = selectBox;
                pth1.Stroke = Brushes.LightBlue;
                pth1.StrokeThickness = 2;
                pth1.StrokeDashArray = new DoubleCollection() { 6, 2 };
                pth1.StrokeDashCap = PenLineCap.Round;
                pth1.Opacity = 1;
                recHitResult.Rect = recTemp;
                GridA.Children.Add(pth1);

               
            }

            
        }

        private void GridA_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Released)
            {
                hits.Clear();
                mouseSelectionCounter = 0;
                GridA.Children.Remove(pth1);
                selectBox = new RectangleGeometry();
                recTemp = new Rect();
                pth1 = new Path();

                //HitTestResult result = VisualTreeHelper.HitTest(GridA, e.GetPosition(this));
                //Debug.WriteLine((result.VisualHit as Path).Name);

                GeometryHitTestParameters parameters = new GeometryHitTestParameters(recHitResult);

                HitTestResultCallback callback = new HitTestResultCallback((HitTestResult result) => {
                    GeometryHitTestResult geometryResult = (GeometryHitTestResult)result;
                    Path visual = result.VisualHit as Path;
                    if (visual != null && geometryResult.IntersectionDetail == IntersectionDetail.FullyInside)
                    {
                        hits.Add(visual);
                        
                    }
                    return HitTestResultBehavior.Continue;
                });

                VisualTreeHelper.HitTest(this, null, callback, parameters);

                foreach (Path x in hits)
                {
                    Debug.WriteLine(x.Name);
                }
                
            }
            
        }

        private void Window_MouseLeave(object sender, MouseEventArgs e)
        {
            mouseSelectionCounter = 0;
            GridA.Children.Remove(pth1);
            selectBox = new RectangleGeometry();
            recTemp = new Rect();
            pth1 = new Path();
        }

        private void Window_MouseEnter(object sender, MouseEventArgs e)
        {
           
        }
    }
}
