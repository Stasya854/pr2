using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Threading;

namespace Snowfall3D
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer MyTimer;
        private Random rand = new Random();
        private Model3DGroup Snowflakes;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Snowflakes = new Model3DGroup();
            SnowflakeModel.Content = Snowflakes;

            for (int i = 0; i < 50; i++)
            {
                AddSnowflake();
            }

            MyTimer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(50) };
            MyTimer.Tick += MyTimer_Tick;
        }

        private void AddSnowflake()
        {
            GeometryModel3D snowflake = new GeometryModel3D();
            MeshGeometry3D mesh = new MeshGeometry3D();

            mesh.Positions = new Point3DCollection
            {
                new Point3D(-0.05, -0.05, 0),
                new Point3D(0.05, -0.05, 0),
                new Point3D(0, 0.05, 0)
            };
            mesh.TriangleIndices = new Int32Collection { 0, 1, 2 };

            snowflake.Geometry = mesh;
            snowflake.Material = new DiffuseMaterial(new SolidColorBrush(Colors.White));

            Transform3DGroup transformGroup = new Transform3DGroup();
            TranslateTransform3D translate = new TranslateTransform3D(rand.NextDouble() * 2 - 1, rand.NextDouble() * 2 - 1, rand.NextDouble());
            transformGroup.Children.Add(translate);

            snowflake.Transform = transformGroup;
            Snowflakes.Children.Add(snowflake);
        }

        private void MyTimer_Tick(object sender, EventArgs e)
        {
            foreach (GeometryModel3D model in Snowflakes.Children)
            {
                if (model.Transform is Transform3DGroup transformGroup && transformGroup.Children[0] is TranslateTransform3D translate)
                {
                    double newY = translate.OffsetY - 0.05;
                    if (newY < -1) newY = 1;
                    translate.OffsetY = newY;
                }
            }
        }

        private void StartAnimation(object sender, RoutedEventArgs e)
        {
            MyTimer.Start();
        }

        private void StopAnimation(object sender, RoutedEventArgs e)
        {
            MyTimer.Stop();
        }
    }
}
