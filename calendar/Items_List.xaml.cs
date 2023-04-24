using System;
using System.Collections.Generic;
using System.IO;
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
using calendar;

namespace calendar
{
    /// <summary>
    /// Interaction logic for Items_List.xaml
    /// </summary>
    public partial class Items_List : Window
    {
        public static List<Item> tmp = new List<Item>();
        public static List<Point> temp = new List<Point>();
        public Items_List()
        {
            InitializeComponent();

            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Points.json"))
            {
                temp = Serialize.from_json<List<Point>>();
                for (int i = 0; i < 4; i++)
                {
                    if (temp[i].IsSelected && temp[i].Date.Month == MainWindow.MonthNumber && temp[i].Date.Day == MainWindow.CurrentDay)
                    {
                        Item s = new Item();
                        s.Image.Source = new BitmapImage(new Uri(temp[i].IconPath));
                        s.ItemName.Text = temp[i].Name;
                        s.ItemSelect.IsChecked = temp[i].IsSelected;
                        Box.Items.Add(s);
                        tmp.Add(s);
                    }
                    else if (!temp[i].IsSelected && temp[i].Date.Month == MainWindow.MonthNumber && temp[i].Date.Day == MainWindow.CurrentDay)
                    {
                        Item s = new Item();
                        s.Image.Source = new BitmapImage(new Uri(temp[i].IconPath));
                        s.ItemName.Text = temp[i].Name;
                        s.ItemSelect.IsChecked = temp[i].IsSelected;
                        Box.Items.Add(s);
                        tmp.Add(s);
                    }
                }
            }
                for (int i = 0; i < 4; i++)
                {
                    Item s = new Item();
                    s.Image.Source = new BitmapImage(new Uri(MainWindow.Wear[i + 1]));
                    s.ItemName.Text = MainWindow.Names[i];
                    s.ItemSelect.IsChecked = false;
                    Box.Items.Add(s);
                    tmp.Add(s);
                }
        }

        private void AddToList(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < tmp.Count; i++)
            {
                if (tmp[i].ItemSelect.IsChecked == true)
                {
                    DateTime t = new DateTime(MainWindow.CurrentYear, MainWindow.MonthNumber, MainWindow.CurrentDay);
                    SelectedItems.Values.Add(new Point(tmp[i].ItemName.Text, 
                    (tmp[i].Image.Source as BitmapImage).UriSource.AbsolutePath, t, true));
                    
                }
                
                
            }
            Serialize.to_json(SelectedItems.Values);
            Close();
        }
    }
}
