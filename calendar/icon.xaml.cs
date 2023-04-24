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

namespace calendar
{
    
    public partial class icon : UserControl
    {
        
        public icon(int day, string path)
        {
            InitializeComponent();
            this.DayNumber.Text = day.ToString();
            this.ImageSource.Source = new BitmapImage(new Uri(path));
        }

        private void Cliked(object sender, MouseButtonEventArgs e)
        {
            MainWindow.CurrentDay = Convert.ToInt32(DayNumber.Text);
            Items_List new_window = new Items_List();
            new_window.Show();
        }
    }
}
