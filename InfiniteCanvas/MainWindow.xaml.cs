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

        public MainWindow()
        {
            InitializeComponent();

            MyBackground mb1 = new MyBackground();

            GridA.Background = mb1.backg();

            GridA.RenderTransform = new TranslateTransform { X = -5000, Y = -5000 };
        }

        private void GridA_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            IsMouseDown = true;
            initial = e.GetPosition(GridA);
        }

        private void GridA_MouseMove(object sender, MouseEventArgs e)
        {
            if (!IsMouseDown) return;

            xOffset = e.GetPosition(this) - initial;

            

            if (xOffset.X >= 0)
            {
                xOffset.X = 0;
            }

            if (xOffset.X <= (-10000 + SystemParameters.PrimaryScreenWidth))
            {
                xOffset.X = -10000 + SystemParameters.PrimaryScreenWidth;
            }


            

            if (xOffset.Y >= 0)
            {
                xOffset.Y = 0;
            }

            if (xOffset.Y <= (-10000 + SystemParameters.PrimaryScreenHeight))
            {
                xOffset.Y = -10000 + SystemParameters.PrimaryScreenHeight;
            }

            GridA.RenderTransform = new TranslateTransform { X = xOffset.X, Y = xOffset.Y };

            Debug.WriteLine("Window X: " + xOffset.X.ToString() + "  Window Y: " + xOffset.Y.ToString());
        }

        private void GridA_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            IsMouseDown = false;
        }
    }
}
