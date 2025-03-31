using System.Windows;
using System.Windows.Media.Media3D;

namespace WpfApplication1
{
    public partial class MainWindow : Window
    {
        private RotateTransform3D myYRotate, myXRotate;
        private AxisAngleRotation3D myYAxis, myXAxis;
        private Transform3DGroup myTransform1, myTransform2;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            myYRotate = new RotateTransform3D();
            myYAxis = new AxisAngleRotation3D();
            myYAxis.Axis = new Vector3D(0, 1, 0);
            myYAxis.Angle = 10;
            myYRotate.Rotation = myYAxis;

            myXRotate = new RotateTransform3D();
            myXAxis = new AxisAngleRotation3D();
            myXAxis.Axis = new Vector3D(1, 0, 0);
            myXAxis.Angle = 10;
            myXRotate.Rotation = myXAxis;

            myTransform1 = new Transform3DGroup();
            myTransform2 = new Transform3DGroup();

            MyModel.Transform = myTransform1;
            MyModel2.Transform = myTransform2;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            myTransform1.Children.Add(new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 1, 0), 10)));
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            myTransform2.Children.Add(new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(1, 0, 0), 10)));
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            myTransform1.Children.Add(new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(1, 0, 0), 10)));
        }
    }
}
