using System;
using System.Collections.Generic;

List<string> compras = new List<string> { "pan", "leche", "huevos" };

compras.Add("yerba");
compras.Insert(0, "arroz");
compras.Remove("leche");
compras.Sort();

Console.WriteLine("Cantidad: " + compras.Count);
foreach (string producto in compras)
{
	Console.WriteLine("- " + producto);
}
Console.WriteLine("¿Hay huevos? " + compras.Contains("huevos"));