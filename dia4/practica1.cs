Dictionary<string, double> precios = new Dictionary<string, double>
{
    { "Medialuna", 2500 },
    { "Chipa", 3000 },
    { "Pan por Kilo", 12000 },
    { "Gaseosa", 8000 },
    { "Leche", 9500 }
};
Dictionary<string, int> tasasIva = new Dictionary<string, int>
{
	{ "Medialuna", 10 },
	{ "Chipa", 10 },
	{ "Pan por Kilo", 5 },
	{ "Gaseosa", 10 },
	{ "Leche", 5 }
};
Console.WriteLine("=== Catálogo ===");
foreach (string producto in precios.Keys)
{
    Console.WriteLine(producto + ": " + FormatoGs(precios[producto]) + " (IVA " + tasasIva[producto] + " %)");
}
