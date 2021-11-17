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

namespace ToggleSwitch
{
    /// <summary>
    /// Interaction logic for ToggleButton.xaml
    /// </summary>
    public partial class ToggleButton : UserControl
    {
        Thickness LeftSide = new Thickness(-39, 0, 0, 0);
        Thickness CenterSide = new Thickness(0, 0, 0, 0);
        Thickness RightSide = new Thickness(0, 0, -39, 0);
        SolidColorBrush Off = new SolidColorBrush(Color.FromRgb(135, 206, 250));
        SolidColorBrush nothing = new SolidColorBrush(Color.FromRgb(160, 160, 160));
        SolidColorBrush On = new SolidColorBrush(Color.FromRgb(130, 190, 125));
        private int Toggled = 0;

        public ToggleButton()
        {
            InitializeComponent();
            Back.Fill = nothing;
            Toggled = 0;
            Dot.Margin = CenterSide;
            //CenterPt = Mouse.GetPosition(Dot as FrameworkElement);
            
        }

        public int Toggled1 { get => Toggled; set => Toggled = value; }

        //private void Dot_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
            //if (!Toggled)
            //{
            //    Back.Fill = On;
            //    Toggled = true;
            //    Dot.Margin = RightSide;

            //}
            //else
            //{

            //    Back.Fill = Off;
            //    Toggled = false;
            //    Dot.Margin = LeftSide;

            //}
        //}

        private void Back_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // 滑动块在主窗口的位置
            Point dotPt = Dot.TransformToAncestor(Application.Current.MainWindow).Transform(new Point(0, 0));
            // 鼠标在主窗口的位置
            Point mousePt = Mouse.GetPosition(Application.Current.MainWindow);

            if (mousePt.X > dotPt.X && Toggled < 1)
            {
                Toggled += 1;
            }
            else if (mousePt.X < dotPt.X && Toggled > -1)
            {
                Toggled -= 1;
            }

            SwitchStyle(Toggled);

        }


        private void SwitchStyle(int toggle)
        {
            switch (toggle)
            {
                case -1:
                    Back.Fill = Off;
                    Dot.Margin = LeftSide;
                    break;
                case 0:
                    Back.Fill = nothing;
                    Dot.Margin = CenterSide;
                    break;
                case 1:
                    Back.Fill = On;
                    Dot.Margin = RightSide;
                    break;
                default:
                    break;
            }
        }
    }
}
