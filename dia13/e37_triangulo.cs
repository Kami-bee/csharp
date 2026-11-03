using System;

Console.Write("Altura: ");
int altura = int.Parse(Console.ReadLine()!);

Console.WriteLine("Triangulo:");
for (int fila = 1; fila <= altura; fila++)
{
	Console.WriteLine(new string('*', fila));
}

Console.WriteLine("Piramide:");
for (int fila = 1; fila <= altura; fila++)

{
	Console.WriteLine(new string(' ', altura - fila) + new string('*', 2 * fila - 1));
}