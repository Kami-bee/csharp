using System;

Console.Write("Escribe una frase: ");
string frase = Console.ReadLine() ?? "";

int vocales = 0;
foreach (char letra in frase.ToLower())
{
	if ("aeiouaeiou".Contains(letra))
		vocales++;
}

Console.WriteLine("Mayusculas: " + frase.ToUpper());
Console.WriteLine("Largo: " + frase.Length);
Console.WriteLine("Vocales: " + vocales);