using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace DrawingBrush01.Extra
{
    class MyBackground
    {
        GeometryDrawing gd1 = new GeometryDrawing();
        GeometryDrawing gd2 = new GeometryDrawing();
        GeometryDrawing gd3 = new GeometryDrawing();
        GeometryDrawing gd4 = new GeometryDrawing();
        GeometryDrawing gd5 = new GeometryDrawing();

        GeometryDrawing gd6 = new GeometryDrawing();
        GeometryDrawing gd7 = new GeometryDrawing();
        GeometryDrawing gd8 = new GeometryDrawing();
        GeometryDrawing gd9 = new GeometryDrawing();
        GeometryDrawing gd10 = new GeometryDrawing();

        DrawingGroup dg1 = new DrawingGroup();
        DrawingBrush db1 = new DrawingBrush();

        public DrawingBrush backg()
        {
            gd1.Pen = new Pen(Brushes.White, 1);
            gd1.Geometry = new LineGeometry(new Point(0, 0), new Point(30, 0));
            dg1.Children.Add(gd1);
            /*
            gd2.Pen = new Pen(Brushes.White, 1);
            gd2.Geometry = new LineGeometry(new Point(0, 10), new Point(60, 10));
            dg1.Children.Add(gd2);
            */
            gd3.Pen = new Pen(Brushes.White, 0.5);
            gd3.Geometry = new LineGeometry(new Point(0, 10), new Point(30, 10));
            dg1.Children.Add(gd3);
            /*
            gd4.Pen = new Pen(Brushes.White, 1);
            gd4.Geometry = new LineGeometry(new Point(0, 30), new Point(60, 30));
            dg1.Children.Add(gd4);
            */
            gd5.Pen = new Pen(Brushes.White, 0.5);
            gd5.Geometry = new LineGeometry(new Point(0, 20), new Point(30, 20));
            dg1.Children.Add(gd5);




            gd6.Pen = new Pen(Brushes.White, 1);
            gd6.Geometry = new LineGeometry(new Point(0, 0), new Point(0, 30));
            dg1.Children.Add(gd6);
            /*
            gd7.Pen = new Pen(Brushes.White, 1);
            gd7.Geometry = new LineGeometry(new Point(10, 0), new Point(10, 60));
            dg1.Children.Add(gd7);
            */
            gd8.Pen = new Pen(Brushes.White, 0.5);
            gd8.Geometry = new LineGeometry(new Point(10, 0), new Point(10, 30));
            dg1.Children.Add(gd8);
            /*
            gd9.Pen = new Pen(Brushes.White, 1);
            gd9.Geometry = new LineGeometry(new Point(30, 0), new Point(30, 60));
            dg1.Children.Add(gd9);
            */
            gd10.Pen = new Pen(Brushes.White, 0.5);
            gd10.Geometry = new LineGeometry(new Point(20, 0), new Point(20, 30));
            dg1.Children.Add(gd10);

            db1.Drawing = dg1;
            db1.Viewport = new Rect(0, 0, 30, 30);
            db1.ViewportUnits = BrushMappingMode.Absolute;
            db1.TileMode = TileMode.Tile;

            return db1;
        }
    }
}
