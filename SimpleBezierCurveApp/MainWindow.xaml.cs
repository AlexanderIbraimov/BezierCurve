using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SimpleBezierCurveApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private List<Point> points = new List<Point>();

        private void DrawPoint(Point point)
        {
            var elipse = new Ellipse();

            elipse.Width = 10;
            elipse.Height = 10;

            elipse.StrokeThickness = 4;
            elipse.Stroke = Brushes.Red;
            elipse.Margin = new Thickness(point.X - 2, point.Y - 2, 0, 0);

            canvas.Children.Add(elipse);
        }

        private void DrawLine(Point point1, Point point2)
        {
            var line = new Line();

            line.X1 = point1.X;
            line.Y1 = point1.Y;

            line.X2 = point2.X;
            line.Y2 = point2.Y;

            line.Stroke = Brushes.Green;
           
            canvas.Children.Add(line);
        }

        private void Update()
        {
            canvas.Children.Clear();
            var curve = Bezier.GetCurvePoints(points.ToArray());
            for (int i = 0; i < curve.Length - 1; i++)
            {
                DrawLine(curve[i], curve[i + 1]);
            }

            foreach (var p in points)
            {
                DrawPoint(p);
            }
        }

        private void canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var p = e.GetPosition(canvas);
            var x = p.X;
            var y = p.Y;
            var point = new Point(x, y);

            points.Add(point);
            Update();
        }

        private void ClearButtonClick(object sender, RoutedEventArgs e)
        {
            canvas.Children.Clear();
            points.Clear();
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            canvas.Children.Clear();
            if (points.Count > 0 )
            {
                points.RemoveAt(points.Count - 1);
                Update();
            }
        }
    }
}
