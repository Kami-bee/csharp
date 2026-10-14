double CalcularSubTotal(double precio, int cantidad) {
	return precio * cantidad;
}

double AplicarDescuento(double monto, int porcentaje) {
	return monto - monto * porcentaje / 100;
}

double subTotal = CalcularSubTotal(1000000, 2);
double descuento;
descuento = AplicarDescuento(subTotal, 5);
Console.WriteLine($"Subtotal = {subTotal}");
Console.WriteLine($"Con descuento del 5% = {descuento}");