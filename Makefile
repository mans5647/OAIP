CC=mcs
CFLAGS=-out:

main: calc.cs
	$(CC) $(CFLAGS)calc.exe calc.cs
