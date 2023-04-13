using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace budget_app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        
        public class Note
        {
            public string NoteName { get; set; }
            public string NoteType { get; set; }

            private int amount_ { get; set; }
            public int amount
            {
                get
                {
                    return amount_;
                }

                set
                {
                    if (value < 0)
                    {
                        IsIncome = false;
                        amount = +amount;
                    }
                    else
                    {
                        IsIncome = true;
                        amount = value;
                    }
                }
            }


            
            public bool IsIncome { get; set; }
            

            public DateTime NoteTime;

            public Note(string name, string type, int amount, DateTime NoteTime, bool income)
            {
                NoteName = name;
                NoteType = type;
                amount_ = amount;
                this.NoteTime = NoteTime;
                IsIncome = income;
            }
        }
        public static List<Note> change_list = new List<Note>();
        public static List<Note> temp_list = new List<Note>();
        public static List<Note> main_list;
        public static List<string> types = new List<string>();

        public string current_note = null;

        bool allow_write = false;
        bool is_current_time = true;
        bool is_income = false;
        int index;

        public class Other
        {
            public List<string> tp = new List<string>();
            public int all;
            public Other(List<string> types, int all)
            {
                tp = types;
                this.all = all;
            }
        }


        DateTime Date = new DateTime();

        int p = 0;
        
        public MainWindow()
        {
            
            InitializeComponent();
            if (File.Exists("C:\\Users\\mansu\\data.json"))
            {
                main_list = Serialize.Read();
            }

            else
            {
                main_list = new List<Note>();
            }

            if (File.Exists("C:\\Users\\mansu\\other.json"))
            {
                Other tmp = Serialize.Get_Other();
                NTypes.ItemsSource = tmp.tp;
                types = tmp.tp;
                if (tmp.all < 0)
                {
                    p = 0;
                }
                p = tmp.all;
            }

            

            from_date.SelectedDate = DateTime.Now;
            foreach (var i in main_list)
            {
                if (i.NoteTime == from_date.SelectedDate)
                {
                    change_list.Add(i);
                }
            }

            data1.ItemsSource = change_list;
            
            
        }

        private void note_type_changed(object sender, SelectionChangedEventArgs e)
        {
            current_note = NTypes.SelectedValue as string;
            allow_write = true;

        }

        private void add_note_type(object sender, RoutedEventArgs e)
        {
            type_n f = new type_n();
            f.Show();

        }

        private void add_note_Click(object sender, RoutedEventArgs e)
        {
            if (!allow_write)
            {
                MessageBox.Show("Type has not been initialized!");
                return;
            }
            if (summ.Text.Length == 0)
            {
                MessageBox.Show("Initial budget cannot be null");
                return;
            }

            if (note_name.Text.Length == 0)
            {
                MessageBox.Show("Note name cannot be empty");
                return;
            }

            if (is_current_time)
            {
                if (Convert.ToInt32(summ.Text) < 0)
                {
                    if (p < 0)
                    {
                        p = 0;
                    }
                    p -= Convert.ToInt32(summ.Text);
                }
                is_income = true;
                p += Convert.ToInt32(summ.Text);
                Note instance_1 = new Note(note_name.Text, current_note, Convert.ToInt32(summ.Text), DateTime.Now, is_income);

                temp_list = main_list;
                temp_list.Add(instance_1);
                data1.Items.Refresh();
                data1.ItemsSource = temp_list;
                Serialize.WriteObject(temp_list);
                Serialize.Other(new Other(types, p));
                
                
            }

            else
            {
                if (Convert.ToInt32(summ.Text) < 0)
                {
                    is_income = false;
                    if (p < 0)
                    {
                        p = 0;
                    }
                    
                    p -= Convert.ToInt32(summ.Text);
                }
                is_income = true;
                p += Convert.ToInt32(summ.Text);
                Note instance = new Note(note_name.Text, current_note, Convert.ToInt32(summ.Text), from_date.SelectedDate.Value, is_income);
                temp_list = main_list;
                temp_list.Add(instance);
                change_list.Add(instance);
                data1.Items.Refresh();
                data1.ItemsSource = change_list;
                Serialize.WriteObject(temp_list);
                Serialize.Other(new Other(types, p));
            }

            money.Text = p.ToString();
            
        }

        private void change_note_Click(object sender, RoutedEventArgs e)
        {
            
            if (note_name.Text.Length != 0 && summ.Text.Length != 0 && allow_write)
            {
                if (data1.SelectedItem != null)
                {

                    Note sel = data1.SelectedItem as Note;
                    
                    if (Convert.ToInt32(summ.Text) < 0)
                    {
                        is_income = false;
                        if (p < 0)
                        {
                            p = 0;
                        }
                        p -= Convert.ToInt32(summ.Text);
                    }
                    
                    is_income = true;
                    p += Convert.ToInt32(summ.Text);
                    change_list[index] = new Note(note_name.Text, current_note, Convert.ToInt32(summ.Text), DateTime.Now, is_income);
                    for (int i = 0; i < main_list.Count; i++)
                    {
                        if (main_list[i].NoteName == sel.NoteName)
                        {
                            main_list[i] = new Note(note_name.Text, current_note, Convert.ToInt32(summ.Text), sel.NoteTime, is_income);
                            break;
                        }
                    }
                    data1.ItemsSource = change_list;
                    data1.Items.Refresh();
                    Serialize.WriteObject(main_list);
                    Serialize.Other(new Other(types, p));
                }
                else
                {
                    MessageBox.Show("Select note to change it first!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("To change, all fields should be filled");
                return;
            }
            money.Text = p.ToString();
        }

        private void del_note_Click(object sender, RoutedEventArgs e)
        {
            if (data1.SelectedItem != null)
            {
                Note tmp = data1.SelectedItem as Note;
                change_list.RemoveAt(index);
                for (int i = 0; i < main_list.Count; i++)
                {
                    if (tmp.NoteName == main_list[i].NoteName)
                    {
                        main_list.RemoveAt(i);
                        break;
                    }
                }
                if (p < 0)
                {
                    p = 0;
                }
                p -= tmp.amount;
                data1.ItemsSource = change_list;
                data1.Items.Refresh();
                Serialize.WriteObject(main_list);
                Serialize.Other(new Other(types, p));
            }
            money.Text = p.ToString();
        }

        
        
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NTypes.ItemsSource = types.ToArray();
        }

        private void date_changed(object sender, SelectionChangedEventArgs e)
        {

            Date = Convert.ToDateTime(from_date.Text);
            is_current_time = false;
            change_list.Clear();
            for (int i = 0; i < main_list.Count; i++)
            {
                if (main_list[i].NoteTime == from_date.SelectedDate)
                {
                    change_list.Add(main_list[i]);
                }
            }
            data1.Items.Refresh();
            data1.ItemsSource = change_list;
            money.Text = p.ToString();

        }

        private void Note_selected(object sender, SelectionChangedEventArgs e)
        {
            
            if (data1.SelectedItem != null)
            {
                index = data1.SelectedIndex;
                Note selected = data1.SelectedItem as Note;

                note_name.Text = selected.NoteName;
                NTypes.Text = selected.NoteType;
                summ.Text = selected.amount.ToString();
            }
        }
    }
}
