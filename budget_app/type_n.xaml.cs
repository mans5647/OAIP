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
using System.Windows.Shapes;

namespace budget_app
{
    
    public partial class type_n : Window
    {
        
        public type_n()
        {
            InitializeComponent();

        }

        private void invoke(object sender, RoutedEventArgs e)
        {
            if (note.Text.Length != 0)
            {
                MainWindow.types.Add(note.Text);
                Close();
            }
        }

        

        private void win_closed(object sender, EventArgs e)
        {

        }
    }
}
