using System;
using System.Windows;
using System.Windows.Media.Media3D;
using System.Windows.Threading;

namespace My3DApp
{
    public partial class MainWindow : Window
    {
        private RotateTransform3D myYRotate, myZRotate, myYRotate2, myZRotate2;
        private AxisAngleRotation3D myYAxis, myZAxis, myYAxis2, myZAxis2;
        private Transform3DGroup myTransform1, myTransform2;
        private DispatcherTimer MyTimer;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Перетворення для 1 об'єкта
            myYRotate = new RotateTransform3D();
            myYAxis = new AxisAngleRotation3D { Axis = new Vector3D(0, 1, 0), Angle = 0 };
            myYRotate.Rotation = myYAxis;

            myZRotate = new RotateTransform3D();
            myZAxis = new AxisAngleRotation3D { Axis = new Vector3D(0, 0, 1), Angle = 0 };
            myZRotate.Rotation = myZAxis;

            myTransform1 = new Transform3DGroup();
            MyModel.Transform = myTransform1;
            myTransform1.Children.Add(myYRotate);
            myTransform1.Children.Add(myZRotate);

            // Перетворення для 2 об'єкта
            myYRotate2 = new RotateTransform3D();
            myYAxis2 = new AxisAngleRotation3D { Axis = new Vector3D(0, 1, 0), Angle = 0 };
            myYRotate2.Rotation = myYAxis2;

            myZRotate2 = new RotateTransform3D();
            myZAxis2 = new AxisAngleRotation3D { Axis = new Vector3D(0, 0, 1), Angle = 0 };
            myZRotate2.Rotation = myZAxis2;

            myTransform2 = new Transform3DGroup();
            MyModel2.Transform = myTransform2;
            myTransform2.Children.Add(myYRotate2);
            myTransform2.Children.Add(myZRotate2);

            // Таймер
            MyTimer = new DispatcherTimer();
            MyTimer.Tick += MyTimer_Tick;
            MyTimer.Interval = TimeSpan.FromMilliseconds(10);
        }

        private void MyTimer_Tick(object sender, EventArgs e)
        {
            myYAxis.Angle += 1;
            myZAxis.Angle += 1;
            myYAxis2.Angle -= 2;
            myZAxis2.Angle -= 2;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MyTimer.Start();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            MyTimer.Stop();
        }
    }
}
