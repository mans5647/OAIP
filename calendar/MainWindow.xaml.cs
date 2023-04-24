using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public class Point
    {


        public Point(string name, string iconPath, DateTime dt, bool sl)
        {
            Name = name;
            IconPath = iconPath;
            Date = dt;
            IsSelected = sl;
        }

        public string Name { get; set; }
        
        public string IconPath { get; set; }

        public DateTime Date { get; set; }
        public bool IsSelected { get; set; }

        
    }

    public class SelectedItems
    {

        public DateTime ItemsDate;
        public static List<Point> Values = new List<Point>(); 
    }



    public partial class MainWindow : Window
    {

        public static List<string> Months = new List<string> 
        { null, "January", "February", "March", "April", "May", "June", "July", "August", "September", "October",
        "November", "December"};

        public static readonly string EmptyDay = "C:\\Users\\mansu\\OAIP\\calendar\\bin\\Debug\\Images\\empty.png";
        public static List<string> Wear = new List<string>
        {
            null, // for easy order
            "C:\\Users\\mansu\\OAIP\\calendar\\bin\\Debug\\Images\\snk.png", // sneakers 1
            "C:\\Users\\mansu\\OAIP\\calendar\\bin\\Debug\\Images\\tshort.png", // ts 2
            "C:\\Users\\mansu\\OAIP\\calendar\\bin\\Debug\\Images\\cap.png", // cap 3
            "C:\\Users\\mansu\\OAIP\\calendar\\bin\\Debug\\Images\\hudi.png" // hudi 4
        };

        public static List<string> Names = new List<string> {"Sneakers", "T-Short", "Cap", "Hudi"};

        public static List<Point> temp = new List<Point>();
        public static List<icon> list = new List<icon>();

        public static string CurrentMonth = null;
        public static int CurrentYear = DateTime.Now.Year;
        public static int CurrentDay = DateTime.Now.Day;
        public static int MonthNumber = 0;
        public static DateTime CurrentDate;
        public MainWindow()
        {
            InitializeComponent();

            MonthNumber = DateTime.Now.Month;
            MonthDisplay.Text = Months[MonthNumber];
            
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Points.json"))
            {
                SelectedItems.Values = Serialize.from_json<List<Point>>();
            }
            
            UpdateDate();
        }

        private void DateChanged(object sender, SelectionChangedEventArgs e)
        {
            CurrentDate = ChangeDate.SelectedDate.Value;
            MonthNumber = ChangeDate.SelectedDate.Value.Month;
            MonthDisplay.Text = Months[MonthNumber];
            UpdateDate();

        }

        private void UpdateDate()
        {


            list.Clear();
            days.Children.Clear();
            for (int i = 0; i < DateTime.DaysInMonth(CurrentYear, MonthNumber); i++)
            {
                days.Children.Add(new icon(i + 1, EmptyDay));
                list.Add(new icon(i + 1, EmptyDay));
            }


            for (int i = 0; i < DateTime.DaysInMonth(CurrentYear, MonthNumber); i++)
            {
                for (int j = 0; j < SelectedItems.Values.Count; j++)
                {
                    if (Convert.ToInt32(list[i].DayNumber.Text) == SelectedItems.Values[j].Date.Day && MonthNumber == SelectedItems.Values[j].Date.Month)
                    {
                        days.Children.RemoveAt(i);
                        list.RemoveAt(i);
                        days.Children.Insert(i, new icon(SelectedItems.Values[j].Date.Day, SelectedItems.Values[j].IconPath));
                        list.Insert(i, new icon(SelectedItems.Values[j].Date.Day, SelectedItems.Values[j].IconPath));
                    }
                }
            }
        }

        private void PrevMonth(object sender, RoutedEventArgs e)
        {
            --MonthNumber;
            if (MonthNumber < 1)
            {
                MonthNumber = 12;
                CurrentYear--;
            }

            
            CurrentMonth = Months[MonthNumber];
            MonthDisplay.Text = Months[MonthNumber];
            UpdateDate();
        }

        private void NextMonth(object sender, RoutedEventArgs e)
        {
            ++MonthNumber;
            if (MonthNumber > 12)
            {
                MonthNumber = 1;
                CurrentYear++;
                
            }

            CurrentMonth = Months[MonthNumber];
            MonthDisplay.Text = Months[MonthNumber];
            UpdateDate();

        }

        private void upd(object sender, RoutedEventArgs e)
        {
            UpdateDate();
        }
    }
}
