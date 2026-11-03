using System;

Console.Write("Nota (0 a 100: ");
int nota  = int.Parse(Console.ReadLine()!);

if (nota < 0 || nota > 100)
	Console.WriteLine("Nota invalida.");
else if (nota >= 90)
	Console.WriteLine("Excelente");
else if (nota >= 75)
	Console.WriteLine("Bueno");
else if (nota >= 60)
	Console.WriteLine("Aprobado");
else
	Console.WriteLine("Reprobado");
