Console.WriteLine("Conversion de Gs a dolares");
Console.WriteLine("--------------------------");
Console.WriteLine("Escriba la cotizacion del dolar: ");
double cotilizaciones = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Monto en guaranies a convertir: ");
double guaranies = Convert.ToDouble(Console.ReadLine());
double dolares;
dolares = guaranies / cotilizaciones;
Console.WriteLine($"Son {dolares} dolares");