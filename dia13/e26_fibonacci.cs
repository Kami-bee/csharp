using System;

Console.Write("¿Cuantos terminos? ");
int cantidad = int.Parse(Console.ReadLine()!);

long anterior = 0;
long actual = 1;

for (int i = 0; i < cantidad; i++)
{
	Console.WriteLine(anterior + " ");

	long siguiente = anterior + actual;
	anterior = actual;
	actual = siguiente;
}

Console.WriteLine();