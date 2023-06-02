using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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
using json_serializer;
using network;

namespace library_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Server srv;
        Socket sock;
        public MainWindow()
        {
            InitializeComponent();
            srv = new Server();
            srv.Bind(new IPEndPoint(IPAddress.Any, 9000));
            srv.Listen(100);
            Process();
            
        }

        private async void Process()
        {
            while (true)
            {
                var sc = await srv.Accept();
                box.Items.Add("Client connected");
                byte[] bf = new byte[100];
                await sc.ReceiveAsync(bf, SocketFlags.None);
                int i = 0;
                string msg = Encoding.UTF8.GetString(bf), str = null;
                while (msg[i] != '\0')
                {
                    str += msg[i];
                    i++;
                }

                box.Items.Add(str);
                
            }
        }



        private void SendMessage(object sender, RoutedEventArgs args)
        {
            if (text_field.Text.Length == 0)
            {
                return;
            }
            srv.SendAsync(Encoding.UTF8.GetBytes(text_field.Text));
        }
    }
}
