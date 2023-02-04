using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Channels;
using System.Security.Cryptography.X509Certificates;
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
using System.Windows.Shell;

namespace tictak
{
    public partial class MainWindow : Window
    {

        int current_role = 1; // by default player is CROSSES i.e. ~~ 'X' ~~
        bool isDrawn = true;
        public List<Button> buttons;
        public MainWindow()
        {
            InitializeComponent();
            buttons = new List<Button> { b1, b2, b3, b4, b5, b6, b7, b7, b8, b9 };
        }

        private void DeclareWinner()
        {
            if (current_role == 1)
            {
                if (b1.Content == "X" && b2.Content == "X" && b3.Content == "X"
                    || b4.Content == "X" && b5.Content == "X" && b6.Content == "X"
                    || b7.Content == "X" && b8.Content == "X" && b9.Content == "X"
                    || b1.Content == "X" && b4.Content == "X" && b7.Content == "X"
                    || b2.Content == "X" && b5.Content == "X" && b8.Content == "X"
                    || b3.Content == "X" && b6.Content == "X" && b9.Content == "X"
                    || b1.Content == "X" && b5.Content == "X" && b9.Content == "X"
                    || b3.Content == "X" && b5.Content == "X" && b7.Content == "X")
                {
                    isDrawn = false;
                    MessageBox.Show("Player won!");
                }
            }
            else if (current_role == 0)
            {
                if (b1.Content == "O" && b2.Content == "O" && b3.Content == "O"
                    || b4.Content == "O" && b5.Content == "O" && b6.Content == "O"
                    || b7.Content == "O" && b8.Content == "O" && b9.Content == "O"
                    || b1.Content == "O" && b4.Content == "O" && b7.Content == "O"
                    || b2.Content == "O" && b5.Content == "O" && b8.Content == "O"
                    || b3.Content == "O" && b6.Content == "O" && b9.Content == "O"
                    || b1.Content == "O" && b5.Content == "O" && b9.Content == "O"
                    || b3.Content == "O" && b5.Content == "O" && b7.Content == "O")
                {
                    isDrawn = false;
                    MessageBox.Show("Player won!");
                }
            }
            
            if (b1.Content == "X" && b2.Content == "X" && b3.Content == "X"
                || b4.Content == "X" && b5.Content == "X" && b6.Content == "X"
                || b7.Content == "X" && b8.Content == "X" && b9.Content == "X"
                    || b1.Content == "X" && b4.Content == "X" && b7.Content == "X"
                    || b2.Content == "X" && b5.Content == "X" && b8.Content == "X"
                    || b3.Content == "X" && b6.Content == "X" && b9.Content == "X"
                    || b1.Content == "X" && b5.Content == "X" && b9.Content == "X"
                    || b3.Content == "X" && b5.Content == "X" && b7.Content == "X")
                    {
                        isDrawn = false;
                        MessageBox.Show("Computer won!");
                    }
            else if (current_role != 0)
            {
                    if (b1.Content == "O" && b2.Content == "O" && b3.Content == "O"
                    || b4.Content == "O" && b5.Content == "O" && b6.Content == "O"
                    || b7.Content == "O" && b8.Content == "O" && b9.Content == "O"
                    || b1.Content == "O" && b4.Content == "O" && b7.Content == "O"
                    || b2.Content == "O" && b5.Content == "O" && b8.Content == "O"
                    || b3.Content == "O" && b6.Content == "O" && b9.Content == "O"
                    || b1.Content == "O" && b5.Content == "O" && b9.Content == "O"
                    || b3.Content == "O" && b5.Content == "O" && b7.Content == "O")
                    {
                        isDrawn = false;
                        MessageBox.Show("Computer won!");
                    }
            }
            else
            {
                MessageBox.Show("Drawn!");
            }
        }

        private void BStart_Click(object snd,RoutedEventArgs AS)
        {
            isDrawn = true;
            current_role = 1;
            buttons = new List<Button> { b1, b2, b3, b4, b5, b6, b7, b8, b9 };
            foreach (Button but in buttons)
            {
                but.IsEnabled = true;
                but.Content = "";
            }
            switchrole.IsEnabled = true;
            return;
        }

        private void toggleRole(object sender, RoutedEventArgs ars)
        {
            if (current_role == 1)
            {
                current_role = 0;
                string s = "nulles";
                label1.Content = "Current role " + s;

            }
            else
            {
                current_role = 1;
                string s = "crosses";
                label1.Content = "Current role " + s;
            }
        }
        


        private void Button_Click(object sender, RoutedEventArgs args)
        {
           if (current_role == 1)
           {
                (sender as Button).Content = "X";
                (sender as Button).IsEnabled = false;
                buttons.Remove((sender as Button));
                Comp_Walk();
           }
           else
            {
                (sender as Button).Content = "O";
                (sender as Button).IsEnabled = false;
                buttons.Remove((sender as Button));
                Comp_Walk();
            }
            DeclareWinner();
        }

        private void Comp_Walk()
        {
            if (buttons.Count > 0)
            {
                if (current_role == 1)
                {
                    Random rand = new Random();
                    int pos = rand.Next(buttons.Count);
                    buttons[pos].Content = "O";
                    buttons[pos].IsEnabled = false;
                    buttons.RemoveAt(pos);
                    DeclareWinner();
                }
                else
                {
                    Random rand = new Random();
                    int pos = rand.Next(buttons.Count());
                    buttons[pos].Content = "X";
                    buttons[pos].IsEnabled = false;
                    buttons.RemoveAt(pos);
                    DeclareWinner();
                }
            }
        }

    }
}
