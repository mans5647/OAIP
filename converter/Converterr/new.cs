using Newtonsoft;
using Newtonsoft.Json;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace _p
{
    internal class osn
    {
        public static void deserializaciya(string sslka)
        {
            if (sslka.Contains("txt"))
            {
                List<fig> figs = new List<fig>();
                string[] figi = File.ReadAllLines(sslka);
                for (int i = 0; i < figi.Length; i += 4)
                {
                    fig a = new fig();
                    a.f1 = figi[i];
                    a.f2 = figi[i + 1];
                    a.f3 = figi[i + 2];
                    a.f4 = figi[i + 3];
                    figs.Add(a);
                    List<char> a1 = fr(a.f1);
                    List<char> a2 = fr(a.f2);
                    List<char> a3 = fr(a.f3);
                    List<char> a4 = fr(a.f4);
                    List<char> fr(string a);
                    {
                        List<char> b = a.ToCharArray().ToList();
                        return b;
                    }
                    int pos = 2;
                    char g;
                    ConsoleKeyInfo aa;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine($"Для перехода в режим редактирования нажмите F4, для выхода из этого режима - F10," +
                        $"\nСериализовать в .xml файл - F2,Сериализовать в .json файл - F3");
                        Console.SetCursorPosition(0, pos);
                        gg(a1, a2, a3, a4);
                        Console.SetCursorPosition(0, pos);
                        aa = Console.ReadKey();
                        ConsoleKeyInfo aaaa;
                        if (aa.Key == ConsoleKey.F4)
                        {
                            do
                            {
                                Console.SetCursorPosition(0, pos);
                                aaaa = Console.ReadKey();
                                if (Char.IsLetterOrDigit(aaaa.KeyChar) || aaaa.Key == ConsoleKey.Oem4 || aaaa.Key == ConsoleKey.Oem6 || aaaa.Key == ConsoleKey.Oem5 || aaaa.Key == ConsoleKey.Oem7 || aaaa.Key == ConsoleKey.OemPeriod || aaaa.Key == ConsoleKey.OemComma || aaaa.Key == ConsoleKey.Oem3 || aaaa.Key == ConsoleKey.Oem1)
                                {
                                    switch (pos)
                                    {
                                        case 2:
                                            g = aaaa.KeyChar;
                                            a1.Add(g);
                                            break;
                                        case 3:
                                            g = aaaa.KeyChar;
                                            a2.Add(g);
                                            break;
                                        case 4:
                                            g = aaaa.KeyChar;
                                            a3.Add(g);
                                            break;
                                        case 5:
                                            g = aaaa.KeyChar;
                                            a4.Add(g);
                                            break;

                                    }
                                }
                                else if (aaaa.Key == ConsoleKey.Backspace)
                                {
                                    switch (pos)
                                    {
                                        case 2:
                                            a1 = a1.SkipLast(1).ToList();
                                            break;
                                        case 3:
                                            a2 = a2.SkipLast(1).ToList();
                                            break;
                                        case 4:
                                            a3 = a3.SkipLast(1).ToList();
                                            break;
                                        case 5:
                                            a4 = a4.SkipLast(1).ToList();
                                            break;
                                    }
                                }
                                else if (aaaa.Key == ConsoleKey.DownArrow)
                                {
                                    pos++;
                                    if (pos > 5)
                                    {
                                        pos--;
                                    }
                                }
                                else if (aaaa.Key == ConsoleKey.UpArrow)
                                {
                                    pos--;
                                    if (pos < 2)
                                    {
                                        pos++;
                                    }
                                }
                                Console.Clear();
                                Console.WriteLine($"Для перехода в режим редактирования нажмите F4, для выхода из этого режима - F10," +
                                $"\nСериализовать в .xml файл - F2,Сериализовать в .json файл - F3");
                                gg(a1, a2, a3, a4);
                            } while (aaaa.Key != ConsoleKey.F10);
                        }
                        if (aa.Key == ConsoleKey.F2 || aa.Key == ConsoleKey.F3)
                            break;
                    } while (true);
                    switch (aa.Key)
                    {
                        case ConsoleKey.F2:
                            fig com1 = new fig();
                            com1.f1 = String.Concat(a1);
                            com1.f2 = String.Concat(a2);
                            com1.f3 = String.Concat(a3);
                            com1.f4 = String.Concat(a4);
                            List<fig> figurr = new List<fig> { };
                            figurr.Add(com1);
                            fig figurg;
                            XmlSerializer xml = new XmlSerializer(typeof(fig));
                            using (FileStream fs = new FileStream(sslka, FileMode.Open))
                            {
                                figurg = (fig)xml.Deserialize(fs);
                            }
                            break;
                        case ConsoleKey.F3:
                            com1 = new fig();
                            com1.f1 = String.Concat(a1);
                            com1.f2 = String.Concat(a2);
                            com1.f3 = String.Concat(a3);
                            com1.f4 = String.Concat(a4);
                            figurr = new List<fig> { };
                            figurr.Add(com1);
                            string json = JsonConvert.SerializeObject(figurr);
                            File.WriteAllText("/home/mans/result.txt", json);
                            break;
                    }
                }


            }
            if (sslka.Contains("json"))
            {
                string figi = File.ReadAllText(sslka);
                List<fig> figurki = JsonConvert.DeserializeObject < List <fig>>(figi);
                foreach (fig ruchki in figurki)
                {
                    gg(ruchki.f1.ToCharArray().ToList(), ruchki.f2.ToCharArray().ToList(), ruchki.f3.ToCharArray().ToList(), ruchki.f4.ToCharArray().ToList());
                }
                int pos = 2;
                char g;
                ConsoleKeyInfo aa;
                List<char> a1 = new List<char>();
                List<char> a2 = new List<char>();
                List<char> a3 = new List<char>();
                List<char> a4 = new List<char>();
                foreach (fig ruchki in figurki)
                {
                    a1 = ruchki.f1.ToCharArray().ToList();
                    a2 = ruchki.f2.ToCharArray().ToList();
                    a3 = ruchki.f3.ToCharArray().ToList();
                    a4 = ruchki.f4.ToCharArray().ToList();
                    ruchki.f4.ToCharArray().ToList();

                }
                do
                {
                    Console.Clear();
                    Console.WriteLine($"Для перехода в режим редактирования нажмите F4, для выхода из этого режима - F10," +
                    $"\nСериализовать в .xml файл - F2,Сериализовать в .txt файл - F1");
                    Console.SetCursorPosition(0, pos);
                    gg(a1, a2, a3, a4);
                    Console.SetCursorPosition(0, pos);
                    aa = Console.ReadKey();
                    ConsoleKeyInfo aaaa;
                    if (aa.Key == ConsoleKey.F4)
                    {
                        do
                        {
                            Console.SetCursorPosition(0, pos);
                            aaaa = Console.ReadKey();
                            if (Char.IsLetterOrDigit(aaaa.KeyChar) || aaaa.Key == ConsoleKey.Oem4 || aaaa.Key == ConsoleKey.Oem6 || aaaa.Key == ConsoleKey.Oem5 || aaaa.Key == ConsoleKey.Oem7 || aaaa.Key == ConsoleKey.OemPeriod || aaaa.Key == ConsoleKey.OemComma || aaaa.Key == ConsoleKey.Oem3 || aaaa.Key == ConsoleKey.Oem1)
                            {
                                switch (pos)
                                {
                                    case 2:
                                        g = aaaa.KeyChar;
                                        a1.Add(g);
                                        break;
                                    case 3:
                                        g = aaaa.KeyChar;
                                        a2.Add(g);
                                        break;
                                    case 4:
                                        g = aaaa.KeyChar;
                                        a3.Add(g);
                                        break;
                                    case 5:
                                        g = aaaa.KeyChar;
                                        a4.Add(g);
                                        break;

                                }
                            }
                            else if (aaaa.Key == ConsoleKey.Backspace)
                            {
                                switch (pos)
                                {
                                    case 2:
                                        a1 = a1.SkipLast(1).ToList();
                                        break;
                                    case 3:
                                        a2 = a2.SkipLast(1).ToList();
                                        break;
                                    case 4:
                                        a3 = a3.SkipLast(1).ToList();
                                        break;
                                    case 5:
                                        a4 = a4.SkipLast(1).ToList();
                                        break;
                                }
                            }
                            else if (aaaa.Key == ConsoleKey.DownArrow)
                            {
                                pos++;
                                if (pos > 5)
                                {
                                    pos--;
                                }
                            }
                            else if (aaaa.Key == ConsoleKey.UpArrow)
                            {
                                pos--;
                                if (pos < 2)
                                {
                                    pos++;
                                }
                            }
                            Console.Clear();
                            Console.WriteLine($"Для перехода в режим редактирования нажмите F4, для выхода из этого режима - F10," +
                            $"\nСериализовать в .xml файл - F2,Сериализовать в .txt файл - F1");
                            gg(a1, a2, a3, a4);
                        } while (aaaa.Key != ConsoleKey.F10);
                    }
                    if (aa.Key == ConsoleKey.F1 || aa.Key == ConsoleKey.F2)
                        break;
                } while (true);
                switch (aa.Key)
                {
                    case ConsoleKey.F1:
                        foreach (fig aS in figurki)
                        {
                            string As = "";
                            As += aS.f1 + "\n";
                            As += aS.f2 + "\n";
                            As += aS.f3 + "\n";
                            As += aS.f4;
                            File.WriteAllText("/home/mans/result.txt", As);
                        }
                        break;
                    case ConsoleKey.F2:
                        break;
                }
            }
            if (sslka.Contains("xml"))
            {
                int pos = 2;
                char g;
                ConsoleKeyInfo aa;
                fig figurg;
                XmlSerializer xml = new XmlSerializer(typeof(fig));
                using (FileStream fs = new FileStream(sslka, FileMode.Open))
                {
                    figurg = (fig)xml.Deserialize(fs);
                }
                List<char> a1 = new List<char>();
                List<char> a2 = new List<char>();
                List<char> a3 = new List<char>();
                List<char> a4 = new List<char>();
                a1 = figurg.f1.ToCharArray().ToList();
                a2 = figurg.f2.ToCharArray().ToList();
                a3 = figurg.f3.ToCharArray().ToList();
                a4 = figurg.f4.ToCharArray().ToList();
                do
                {
                    Console.Clear();
                    Console.WriteLine($"Для перехода в режим редактирования нажмите F4, для выхода из этого режима - F10," +
                    $"\nСериализовать в .xml файл - F2,Сериализовать в .txt файл - F1");
                    Console.SetCursorPosition(0, pos);
                    gg(a1, a2, a3, a4);
                    Console.SetCursorPosition(0, pos);
                    aa = Console.ReadKey();
                    ConsoleKeyInfo aaaa;
                    if (aa.Key == ConsoleKey.F4)
                    {
                        do
                        {
                            Console.SetCursorPosition(0, pos);
                            aaaa = Console.ReadKey();
                            if (Char.IsLetterOrDigit(aaaa.KeyChar) || aaaa.Key == ConsoleKey.Oem4 || aaaa.Key == ConsoleKey.Oem6 || aaaa.Key == ConsoleKey.Oem5 || aaaa.Key == ConsoleKey.Oem7 || aaaa.Key == ConsoleKey.OemPeriod || aaaa.Key == ConsoleKey.OemComma || aaaa.Key == ConsoleKey.Oem3 || aaaa.Key == ConsoleKey.Oem1)
                            {
                                switch (pos)
                                {
                                    case 2:
                                        g = aaaa.KeyChar;
                                        a1.Add(g);
                                        break;
                                    case 3:
                                        g = aaaa.KeyChar;
                                        a2.Add(g);
                                        break;
                                    case 4:
                                        g = aaaa.KeyChar;
                                        a3.Add(g);
                                        break;
                                    case 5:
                                        g = aaaa.KeyChar;
                                        a4.Add(g);
                                        break;

                                }
                            }
                            else if (aaaa.Key == ConsoleKey.Backspace)
                            {
                                switch (pos)
                                {
                                    case 2:
                                        a1 = a1.SkipLast(1).ToList();
                                        break;
                                    case 3:
                                        a2 = a2.SkipLast(1).ToList();
                                        break;
                                    case 4:
                                        a3 = a3.SkipLast(1).ToList();
                                        break;
                                    case 5:
                                        a4 = a4.SkipLast(1).ToList();
                                        break;
                                }
                            }
                            else if (aaaa.Key == ConsoleKey.DownArrow)
                            {
                                pos++;
                                if (pos > 5)
                                {
                                    pos--;
                                }
                            }
                            else if (aaaa.Key == ConsoleKey.UpArrow)
                            {
                                pos--;
                                if (pos < 2)
                                {
                                    pos++;
                                }
                            }
                            Console.Clear();
                            Console.WriteLine($"Для перехода в режим редактирования нажмите F4, для выхода из этого режима - F10," +
                            $"\nСериализовать в .xml файл - F2,Сериализовать в .txt файл - F1");
                            gg(a1, a2, a3, a4);
                        } while (aaaa.Key != ConsoleKey.F10);
                    }
                    if (aa.Key == ConsoleKey.F1 || aa.Key == ConsoleKey.F2)
                        break;
                } while (true);
                switch (aa.Key)
                {
                    case ConsoleKey.F1:
                        string As = "";
                        As += figurg.f1 + "\n";
                        As += figurg.f2 + "\n";
                        As += figurg.f3 + "\n";
                        As += figurg.f4;
                        File.WriteAllText("C:\\Users\\veta5\\OneDrive\\Рабочий стол\\Result.txt", As);
                        break;
                    case ConsoleKey.F2:
                        break;
                }
            }

            static void gg(List<char> a, List<char> b, List<char> c, List<char> d)
            {
                Console.SetCursorPosition(0, 2);
                foreach (char name in a)
                {
                    Console.Write(name);
                }
                Console.SetCursorPosition(0, 3);
                foreach (char name in b)
                {
                    Console.Write(name);
                }
                Console.SetCursorPosition(0, 4);
                foreach (char name in c)
                {
                    Console.Write(name);
                }
                Console.SetCursorPosition(0, 5);
                foreach (char name in d)
                {
                    Console.Write(name);
                }

            }
        }
        internal class fig
        {
            public string f1;
            public string f2;
            public string f3;
            public string f4;
        }
    }
    static void Main()
        {
        do
        {
            Console.Clear();
            Console.WriteLine("Введите путь до файла");
            osn.deserializaciya(Console.ReadLine());
        } while (true);
        }

}



