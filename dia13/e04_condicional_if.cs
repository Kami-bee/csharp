using System;

Console.WriteLine("Edad: ");
int edad = int.Parse(Console.ReadLine()!);

if (edad <= 18)
{
	Console.WriteLine("Eres mayor de edad.");
}

Console.WriteLine("Fin del programa.");