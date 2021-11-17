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

namespace ToggleClass
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool? isChecked = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Toggle_Click(object sender, RoutedEventArgs e)
        {

            Point relativePoint = tg.TransformToAncestor(this)
                              .Transform(new Point(0, 0));

            Point mousePt = Mouse.GetPosition(this);


            if (isChecked == false)
            {
                isChecked = null;
                tg.IsChecked = null;
            }
            else if(isChecked  == true)
            {
                isChecked = null;
                tg.IsChecked = null;
            }
            else
            {
                // toggle控件的定位点在左上角，因此需要28的调节
                if (relativePoint.X + 28 < mousePt.X)
                {
                    isChecked = true;
                    tg.IsChecked = true;
                }
                else
                {
                    isChecked = false;
                    tg.IsChecked = false;
                }
            }
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePt = Mouse.GetPosition(this);
            txt.Text = $"{mousePt.X},{mousePt.Y}";
        }
    }
}
