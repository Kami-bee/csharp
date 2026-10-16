using System;

Cliente cliente = new Cliente("Selena Gimenez", "4.123.456");
Prestamo prestamo = new Prestamo(cliente, 6000000, 12, 2);
prestamo.Mostrar();
prestamo.PagarCuota();
prestamo.PagarCuota();
Console.WriteLine();
prestamo.Mostrar();
class Cliente
{
	public string Nombre { get; }
	public string Cedula { get; }
	public Cliente(string nombre, string cedula)
	{
		Nombre = nombre;
		Cedula = cedula;
	}
}
class Prestamo
{
	public Cliente Titular { get; }
	public double Monto { get; }
	public int Cuotas { get; }
	public double TasaMensual { get; }
	public int CuotasPagadas { get; private set; }
	public Prestamo(Cliente titular, double monto, int cuotas, double tasaMensual)
	{
		Titular = titular;
		Monto = monto;
		Cuotas = cuotas;
		TasaMensual = tasaMensual;
		CuotasPagadas = 0;
	}
	public double CalcularCuota()
	{
		double interesTotal = Monto * TasaMensual / 100 * Cuotas;
		return Math.Round((Monto + interesTotal) / Cuotas);
	}
	public void PagarCuota()
	{
		if (CuotasPagadas < Cuotas)
			CuotasPagadas++;
	}
	public double SaldoPendiente()
	{
		return CalcularCuota() * (Cuotas - CuotasPagadas);
	}
	public void Mostrar()
	{
		Console.WriteLine(Titular.Nombre + " (CI" + Titular.Cedula + ")");
		Console.WriteLine("Cuota: " + CalcularCuota().ToString("NO") + "Gs. Pagados " + CuotasPagadas + " de " + Cuotas);
		Console.WriteLine("Saldo pendiente: " + SaldoPendiente().ToString("NO") + " Gs");
	}
}