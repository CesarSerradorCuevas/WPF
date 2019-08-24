using DrawingBrush01.Extra;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace DrawingBrush01
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool IsMouseDown;
        Vector xOffset;      
        Point initial;
        double mouseWheelCounter = 1;
        MyBackground mb1;
        Button b1;
        Point gridPosition;

        public MainWindow()
        {
            InitializeComponent();

            mb1 = new MyBackground();

            CanvasB.Background = mb1.backg();

            CanvasB.RenderTransform = new TranslateTransform { X = -5000, Y = -5000 };
            
            

            b1 = new Button();
            b1.Content = "Press";
            b1.Width = 100;
            b1.Height = 50;
            b1.Margin = new Thickness(5000, 5000, 0, 0);
            CanvasB.Children.Add(b1);

        }

        private void CanvasB_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            IsMouseDown = true;
            initial.X = e.GetPosition(CanvasB).X * mouseWheelCounter;
            initial.Y = e.GetPosition(CanvasB).Y * mouseWheelCounter;
        }

        private void CanvasB_MouseMove(object sender, MouseEventArgs e)
        {
            //gridPosition.X = e.GetPosition(CanvasB).X;
            //gridPosition.Y = e.GetPosition(CanvasB).Y;
            
            if (!IsMouseDown) return;

            xOffset = e.GetPosition(this) - initial;

            

            if (xOffset.X >= 0)
            {
                xOffset.X = 0;
            }

            if (xOffset.X <= ((-10000 * mouseWheelCounter) + SystemParameters.PrimaryScreenWidth))
            {
                xOffset.X = (-10000 * mouseWheelCounter) + SystemParameters.PrimaryScreenWidth;
            }


            

            if (xOffset.Y >= 0)
            {
                xOffset.Y = 0;
            }

            if (xOffset.Y <= ((-10000 * mouseWheelCounter) + SystemParameters.PrimaryScreenHeight))
            {
                xOffset.Y = (-10000 * mouseWheelCounter) + SystemParameters.PrimaryScreenHeight;
            }

            TransformGroup tg1 = new TransformGroup();
            tg1.Children.Add(new ScaleTransform(mouseWheelCounter, mouseWheelCounter));
            tg1.Children.Add(new TranslateTransform { X = xOffset.X, Y = xOffset.Y });

            CanvasB.RenderTransform = tg1;

            Debug.WriteLine("Window X: " + xOffset.X.ToString() + "  Window Y: " + xOffset.Y.ToString());
        }

        private void CanvasB_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            IsMouseDown = false;
        }

        private void CanvasB_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            gridPosition.X = e.GetPosition(CanvasB).X;
            gridPosition.Y = e.GetPosition(CanvasB).Y;

            if (e.Delta > 0)
            {
                mouseWheelCounter += 0.5;
            }
            else
            {
                mouseWheelCounter -= 0.5;
            }
            if (mouseWheelCounter > 2) mouseWheelCounter = 2;
            if (mouseWheelCounter < 0.5) mouseWheelCounter = 0.5;

            gridPosition.X *= mouseWheelCounter;
            gridPosition.Y *= mouseWheelCounter;

            Debug.WriteLine(mouseWheelCounter);


            xOffset = e.GetPosition(this) - gridPosition;



            if (xOffset.X >= 0)
            {
                xOffset.X = 0;
            }

            if (xOffset.X <= ((-10000 * mouseWheelCounter) + SystemParameters.PrimaryScreenWidth))
            {
                xOffset.X = (-10000 * mouseWheelCounter) + SystemParameters.PrimaryScreenWidth;
            }




            if (xOffset.Y >= 0)
            {
                xOffset.Y = 0;
            }

            if (xOffset.Y <= ((-10000 * mouseWheelCounter) + SystemParameters.PrimaryScreenHeight))
            {
                xOffset.Y = (-10000 * mouseWheelCounter) + SystemParameters.PrimaryScreenHeight;
            }

            TransformGroup tg1 = new TransformGroup();
            tg1.Children.Add(new ScaleTransform(mouseWheelCounter, mouseWheelCounter));
            tg1.Children.Add(new TranslateTransform { X = xOffset.X, Y = xOffset.Y });

            CanvasB.RenderTransform = tg1;

            

        }
    }
}
