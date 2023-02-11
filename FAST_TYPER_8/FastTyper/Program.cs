using System;
using FastTyper;
namespace MyNameSpace
{
    class MyProgram
    {
        static int Main()
        {
            Player MyPlayer = new Player();
            Console.Write("Введите ваше имя чтобы начать: ");
            string RealName = Console.ReadLine();
            MyPlayer.Name = RealName;
            MyPlayer.SymsPerSecs = 0;
            MyPlayer.SymsPerMins = 0;
            Enter.TextChallenge(MyPlayer.Name, MyPlayer.SymsPerMins, MyPlayer.SymsPerSecs);
            return 0;
        }
    }
}