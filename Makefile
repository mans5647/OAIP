COM=mcs
FLAGS=-out:

main: calc.cs
	$(COM) $(FLAGS)calc.exe calc.cs
