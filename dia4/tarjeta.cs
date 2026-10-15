
class Tarjeta 
{
	private int _saldo;
	public string Titular { get; };
	public int Saldo {
		get { return _saldo; }
	}

	public Tarjeta(string titular)
	{
		Titular = titular;
		_saldo = 0;
	}
	public void Recargas(int monto)
	{
		if (monto <= 0)
		{
			Console.WriteLine("La recatga debe ser mayor a cero.");
			return;
		}
		_saldo += monto;
	}
	public bool Pagar(int monto)
	{ 
	    if (monto > _saldo)
		{ 
