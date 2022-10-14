using System;

class SS
{
static void usage()
{
	string menu = "Choosing from octaves: \n"+
				  "Tab - 1 octave\n"+
				  "F2  - 2 octave\n"+
				  "F3  - 3 octave\n"+
				  "Esc - to exit. Available in octaves as well\n";
	Console.WriteLine(menu);
}
static void RegSound(int c)
{
	Console.Beep(c, 235);
}
static void qwerty(int [] patt)
{
	
	ConsoleKeyInfo symbol;
	Console.Write("Welcome to: `Octave 1' ! Hit to play >>> ");
	do
	{
		symbol = Console.ReadKey();
		if (symbol.Key == ConsoleKey.Q)
		{
			int vice = patt[0];
			RegSound(vice);
		}
		else if (symbol.Key == ConsoleKey.W)
		{
			int vice = patt[1];
			RegSound(vice);
		}
		else if (symbol.Key == ConsoleKey.E)
		{
			int vice = patt[2];
			RegSound(vice);
		}
		else if (symbol.Key == ConsoleKey.R)
		{
			int vice = patt[3];
			RegSound(vice);
		}
		else if (symbol.Key == ConsoleKey.T)
		{
			int vice = patt[4];
			RegSound(vice); 
		}
		else if (symbol.Key == ConsoleKey.Y)
		{
			int vice = patt[5];
			RegSound(vice);
		}
		else if (symbol.Key == ConsoleKey.U)
		{
			int vice = patt[6];
			RegSound(vice);
		}
		else if (symbol.Key == ConsoleKey.I)
		{
			int vice = patt[7];
			RegSound(vice);
		}
		else if (symbol.Key == ConsoleKey.O)
		{
			int vice = patt[8];
			RegSound(vice);
		}
		else if (symbol.Key == ConsoleKey.P)
		{
			int vice = patt[9];
			RegSound(vice);
		}
	} while (symbol.Key != ConsoleKey.Escape);
	Console.WriteLine("\n\nQuitting from Octave 1 !\n");
}
static void lower_Q(int [] patt2)
{
	ConsoleKeyInfo sym;
	Console.Write("Welcome to: `Octave 2' ! Hit to play >>> ");
	do
	{
		sym = Console.ReadKey();
		if (sym.Key == ConsoleKey.A)
		{
			int vice = patt2[0];
			RegSound(vice);
		}
		else if (sym.Key == ConsoleKey.S)
		{
			int vice = patt2[1];
			RegSound(vice);
		}
		else if (sym.Key == ConsoleKey.D)
		{
			int vice = patt2[2];
			RegSound(vice);
		}
		else if (sym.Key == ConsoleKey.F)
		{
			int vice = patt2[3];
			RegSound(vice);
		}
		else if (sym.Key == ConsoleKey.G)
		{
			int vice = patt2[4];
			RegSound(vice); 
		}
		else if (sym.Key == ConsoleKey.H)
		{
			int vice = patt2[5];
			RegSound(vice);
		}
		else if (sym.Key == ConsoleKey.J)
		{
			int vice = patt2[6];
			RegSound(vice);
		}
		else if (sym.Key == ConsoleKey.K)
		{
			int vice = patt2[7];
			RegSound(vice);
		}  
		else if (sym.Key == ConsoleKey.L)
		{
			int vice = patt2[8];
			RegSound(vice);
		} 
	} while (sym.Key != ConsoleKey.Escape);
	Console.WriteLine("\n\nQuitting from octave 2 !\n");
}
static void zxc(int [] patt3)
{
	ConsoleKeyInfo sym;
	Console.Write("Welcome to: `Octave 3' ! Hit to play >>> ");
	do
	{
		sym = Console.ReadKey();
		if (sym.Key == ConsoleKey.Z)
		{
			int vice = patt3[0];
			RegSound(vice);
		}
		else if (sym.Key == ConsoleKey.X)
		{
			int vice = patt3[1];
			RegSound(vice);
		}
		else if (sym.Key == ConsoleKey.C)
		{
			int vice = patt3[2];
			RegSound(vice);
		}
		else if (sym.Key == ConsoleKey.V)
		{
			int vice = patt3[3];
			RegSound(vice);
		}
		else if (sym.Key == ConsoleKey.B)
		{
			int vice = patt3[4];
			RegSound(vice); 
		}
		else if (sym.Key == ConsoleKey.N)
		{
			int vice = patt3[5];
			RegSound(vice);
		}
		else if (sym.Key == ConsoleKey.M)
		{
			int vice = patt3[6];
			RegSound(vice);
		}
	} while (sym.Key != ConsoleKey.Escape);
	Console.WriteLine("\n\nQuitting from octave 3 !\n");
}
static void Main() 
{
	
	int [] oct1 = new int[] {2100, 2345, 2500, 2653, 2167, 2798, 2959, 2793, 2489, 3661}; 	
	int [] oct2 = new int[] {523, 493, 587, 698, 624, 519, 472, 801, 942};
	int [] oct3 = new int[] {200, 230, 260, 340 ,369, 440, 520, 350};
	ConsoleKeyInfo main_key;

	
	do
	{
		usage();
			main_key = Console.ReadKey();
			if (main_key.Key == ConsoleKey.Tab)
			{
				Console.WriteLine("Oct: 1 | Avail. keys : q , w , e , r , t , y , u , i");
				qwerty(oct1);
			}
			else if(main_key.Key == ConsoleKey.F2)
			{
				Console.WriteLine("Oct: 2 | Avail. keys : a , s , d , f , g , h , j , k");
				lower_Q(oct2);
			}
			else if (main_key.Key == ConsoleKey.F3)
			{
				Console.WriteLine("Oct: 3 | Avail. keys : z , x , c , v , b , n , m");
				zxc(oct3);
			}
	} while (main_key.Key != ConsoleKey.Escape);
	Console.Write("Quitting!\n");
}
}
