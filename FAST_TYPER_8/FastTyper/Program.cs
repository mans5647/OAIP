using System;
using FastTyper;
namespace MyNameSpace
{
    class MyProgram
    {
        static int Main()
        {
            Player MyPlayer = new Player();
            Console.Write("Enter your name for records table: ");
            string RealName = Console.ReadLine();
            MyPlayer.Name = RealName;
            MyPlayer.SymsPerMins = 0;
            MyPlayer.SymsPerSecs = 0;
            Enter.TextChallenge(MyPlayer.Name, MyPlayer.SymsPerMins, MyPlayer.SymsPerSecs);
            return 0;
        }
    }
}