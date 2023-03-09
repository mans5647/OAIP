using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace audio
{

    public partial class MainWindow : Window
    {
        bool IsPaused = true;
        bool IsRepeatAble = false;
        bool IsEnded = false;
        int current_rep = 0;
        static int next_mus = 0;
        
        public MainWindow()
        {
            InitializeComponent();
            pls.IsEnabled = false;
            prev.IsEnabled = false;
            nxt.IsEnabled = false;
            rep.IsEnabled = false;
            Thread th = new Thread(Timer);
            th.Start();
        }

        string[] musics = { };
        private void browse(object O, RoutedEventArgs arg)
        {
            CommonOpenFileDialog select_music = new CommonOpenFileDialog { IsFolderPicker = true };
            var r = select_music.ShowDialog();
            if (r == CommonFileDialogResult.Ok)
            {
                musics = Directory.GetFiles(select_music.FileName, "*.mp3");
                foreach (string fl in musics)
                {
                    string f = System.IO.Path.GetFileName(fl);
                    MusicBox.Items.Add(f);
                }
            }
            
            Player.Source = new Uri(musics[next_mus]);
            Player.Play();
            IsPaused = false;
            EnableMusic();
        }

        private void Play_Stop(object s, RoutedEventArgs f)
        {
            if (!IsPaused)
            {
                Player.Pause();
                IsPaused = true;
                pls.Content = "Resume";
                
            }
            else
            {
                Player.Play();
                IsPaused = false;
                pls.Content = "Pause";
            }
        }
        
        private void slider_changed(object s, RoutedPropertyChangedEventArgs<double> e)
        {
            Player.Position = new TimeSpan(0,0,0,(int)slider.Value);
        }

        private void Audio_Opened(object s, RoutedEventArgs f)
        {
            slider.Maximum = (double)Player.NaturalDuration.TimeSpan.TotalSeconds;
        }

        private void Audio_Ended(object s, RoutedEventArgs j)
        {
            IsEnded = true;
            Player.Source = new Uri(musics[next_mus++]);
            slider.Value = 0.0;
            Player.Play();
        }

        private void PreviousMusic(object s, RoutedEventArgs h)
        {
            if (IsRepeatAble)
            {
                return;
            }
            next_mus--;
            if (next_mus < 0)
            {
                next_mus = musics.Length - 1;
            }
            Player.Stop();
            Player.Source = new Uri(musics[next_mus]);
            Player.Play();
            
        }

        private void NextMusic(object g, RoutedEventArgs j)
        {
            if (IsRepeatAble)
            {
                return;
            }
            next_mus++;
            if (next_mus > musics.Length - 1)
            {
                next_mus = 0;
            }
            Player.Stop();
            Player.Source = new Uri(musics[next_mus]);
            Player.Play();
        }

        private void repeat_current(object m, RoutedEventArgs j)
        {
            if (!IsRepeatAble)
            {
                rep.Content = "Disable";
                Player.Source = new Uri(musics[next_mus]);
                IsRepeatAble = true;
            }    
            else
            {
                rep.Content = "Repeat";
                IsRepeatAble = false;
            }
        }

        private void EnableMusic()
        {
            pls.IsEnabled = true;
            prev.IsEnabled = true;
            nxt.IsEnabled = true;
            rep.IsEnabled = true;
            slider.IsEnabled = true;
        }

        private void Timer()
        {

            while (true)
            {
                this.Dispatcher.Invoke(() => { slider.Value = Player.Position.Seconds; });
            }
        }
    }
}
