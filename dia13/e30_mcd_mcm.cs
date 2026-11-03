using System;

Console.Write("Primer numero: ");
int a = int.Parse(Console.ReadLine()!);
Console.Write("Segundo numero: ");
int b = int.Parse(Console.ReadLine()!);

int x = a;
int y = b;

while (y != 0)
{
	int resto = x % y;
	x = y;
	y = resto;
}

int mcd = x;
int mcm = a / mcd * b;

Console.WriteLine("MCD: " + mcd);
Console.WriteLine("MCM: " + mcm);