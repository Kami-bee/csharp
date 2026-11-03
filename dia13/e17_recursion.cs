using System;

Console.WriteLine("Numero: ");
int n = int.Parse(Console.ReadLine()!);

Console.WriteLine(n + "! = " + Factorial(n));

long Factorial(int numero)
{
	if (numero <= 1)
		return 1;

		return numero * Factorial(numero - 1);
}