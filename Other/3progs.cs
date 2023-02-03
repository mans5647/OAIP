using System;

namespace Programms3

{
	class Gmt 
	{
		public void gmt_as_fool()
		{
			Console.Write("\n");
			Console.Write("Multiplication table:\n\n");

			int[,] ms1 = new int[10,10];
			for (int i = 1; i<ms1.Length; i++)
				{
					Console.Write(i + "\t");
					for (int j = 1; i<ms1.Length; i++)
					{
						if (i>0) Console.Write(i*j+"\t");
						else Console.Write( j +"\t");
					}
				}
			Console.Write("\n");
			Console.Write("\n");
		}
	}
	class Prog3
	{

		static void Main()
		{
			Gmt n = new Gmt();
			string info = "\tThere is program that provides a three little sub-programs:\n" +
					"Choose from list:\n"+
					"\t1 - 'Guess a number'\n"+
					"\t2 - 'Multiplication table'\n"+
					"\t3 - 'Output of number dividers'\n"+
					"\t4 -  clear the screen\n"+
					"\t5 -  get short reference\n"+
					"\t6 -  quit program\n";
			Console.WriteLine("\n"+info);
			int commence;
			int ch;
			while ((ch = Convert.ToInt32(Console.ReadLine())) != null)
			{
				Console.Write(" ---> ");
			try {
			commence = Convert.ToInt32(Console.ReadLine());
			    }
			catch (System.FormatException)
			    {
					continue;
			    }
			 
			if (commence == 1)
				{
					int r_usr; // user's number
					Random r_num = new Random();
					int res = r_num.Next(0,101);// main generator;
						while (true)
						{
							try 
							{
								Console.Write("Enter number to guess it ::::> ");
								r_usr = Convert.ToInt32(Console.ReadLine());
								if (r_usr > res)
								{
									Console.Write("Wrong! Try less!\n");
									continue;
								} else if (r_usr < res)
								{
									Console.Write("Wrong! Try more!\n");
									continue;
								} else
									Console.WriteLine("Congratulations! You figured out the number!\n");
									break;
							} catch (System.FormatException)
							{
								continue;
							}
						}
				}
				else if (commence == 2)
				{
					n.gmt_as_fool();
				}
				else if (commence == 3) 
				{
					string in_num;
				while (true)
				{
				try
				{
					Console.WriteLine("This mini-prog shows to you divisors of the number. Type 'q' to exit\n");
					Console.Write("Enter number or 'q': ");
					in_num = Console.ReadLine();
						if (in_num == "q")
					{
						Console.WriteLine("Exiting...\n");
						break;
					}
						else if (Convert.ToInt32(in_num) < 0)
					{
						Console.WriteLine("Value should be positive! Returning...\n");
						continue;
					} 	else if (Convert.ToInt32(in_num) == 0)
					{
						Console.WriteLine("Value should NOT BE EQUAL TO 'NULL' Returning...\n");
						continue;
					}	else

							while(true)
							{
								int main_N = Convert.ToInt32(in_num);
								for (int stage = 1; stage <= main_N; stage++)
								{
									if ((main_N%stage) == 0)
									Console.Write(" - {0} - ",stage);
								}
							Console.Write("\n");
							break;
							}
				} 
				catch (System.FormatException)
				{
					continue;
				}
				}
				}
				else if (commence == 4) 
				{
					Console.Clear();
				} else if (commence == 5)
				{	
					Console.Write(info);
					Console.Write("\n");
				}
				else if (commence == 6) {
					Console.WriteLine("Exiting...");
					break;
				} else
					Console.WriteLine("Incorrect number of action. Try again?");
					continue;
			
			}
		}
	}
}


