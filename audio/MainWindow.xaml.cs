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
        bool isLocked = false;
        static int next_mus = 0;

        string[] reserve = { }; 
        public MainWindow()
        {
            InitializeComponent();
            pls.IsEnabled = false;
            prev.IsEnabled = false;
            nxt.IsEnabled = false;
            rep.IsEnabled = false;
            but_sh.IsEnabled = false;
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
                reserve = musics;
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
                var brush = new ImageBrush(); brush.ImageSource = new BitmapImage(new
                Uri("C:\\Users\\mansu\\Downloads\\play.png", UriKind.Relative));
                Player.Pause();
                IsPaused = true;
                pls.Background = brush;  

            }
            else
            {
                
                Player.Pause();
                Player.Play();
                IsPaused = false;
                
            }
        }

        private void slider_changed(object s, RoutedPropertyChangedEventArgs<double> e)
        {
            TimeSpan ts = new TimeSpan((int)slider.Value);
            Player.Position = ts;
        }

        private void Audio_Opened(object s, RoutedEventArgs f)
        {
            slider.Maximum = Player.NaturalDuration.TimeSpan.Ticks;
            TimeRemain.Text = Player.NaturalDuration.TimeSpan.ToString(@"mm\:ss");
            Thread gg = new Thread(Timer);
            gg.Start();
        }

        private void Audio_Ended(object s, RoutedEventArgs j)
        {
            if (IsRepeatAble)
            {
                slider.Value = 0.0;
                Player.Stop();
                Player.Source = new Uri(musics[next_mus]);
                Player.Play();
            }
            IsEnded = true;
            Player.Stop();
            Player.Source = new Uri(musics[next_mus++]);
            slider.Value = 0.0;
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
            Player.Source = new Uri(musics[next_mus--]);
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
            Player.Source = new Uri(musics[next_mus++]);
            Player.Play();
        }

        private void repeat_current(object m, RoutedEventArgs j)
        {
            if (!IsRepeatAble)
            {
                IsRepeatAble = true;
            }
            else
            {
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
            but_sh.IsEnabled = true;
        }

        private void Timer()
        {
            while (true)
            {
                
                Dispatcher.Invoke(new Action(() =>
                {
                    slider.Value = Player.Position.Ticks;
                    TimeElapsed.Text = Player.Position.ToString("mm\\:ss");
                }
                ));
                Thread.Sleep(1000);
            }
        }

        private void shuff_music(object sender, RoutedEventArgs d)
        {
            if (!isLocked)
            {

                Random s = new Random();
                next_mus = 0;
                Player.Stop();
                musics = musics.OrderBy(x => s.Next()).ToArray();
                Player.Source = new Uri(musics[next_mus]);
                Player.Play();
                isLocked = true;
            }
            else
            {
                musics = reserve;
                isLocked = false;
            }
        }
    }
}
