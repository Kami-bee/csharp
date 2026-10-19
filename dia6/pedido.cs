using System;
using System.Collections.Generic;

//crear un cliente
Cliente cliente1 = new Cliente("Kamila", "Loaiza", "123", "0981123456", "San Lorenzo");
//crear dos productos
Producto p1 = new Producto(1, "Licuadora", 2600, 100);
//crear pedido a detalle
PedidoDetalle pd1 = new PedidoDetalle(p1, 3, p1.Precio);

//crear un pedido
Pedido pedidoHoy = new Pedido(1, cliente1);
pedidoHoy.Detalles(pd1);

Console.WriteLine("pedidos del dia de hoy");
Console.WriteLine(pedidoHoy.Detalles());

public class Persona {
	public string Nombre { get; set; }
	public string Apellido { get; set; }
	public string Documento { get; set; }
}
//cliente hereda de persona
public class Cliente : Persona {
	public string Telefono { get; set; }
	public string Direccion { get; set; }


	//constructor
	public Cliente(string nombre, string apellido, string documento, string telefono, string direccion) : base(nombre, apellido, documento) {
		Telefono = telefono;
		Direccion = direccion;
	}
}
public class Producto {
	public int Id { get; set; }
	public string Nombre { get; set; }
	public decimal Precio { get; set; }
	public int Stock { get; set; }

	//constructor
	public Producto(int id, string nombre, decimal precio, int stock) {
		Id = id;
		Nombre = nombre;
		Precio = precio;
		Stock = stock;
	}
}
public class PedidoDetalle
{
		public Producto Producto { get; set; }
		public int Cantidad { get; set; }
		public decimal PrecioUnitario { get; set; }
	
	//constructor
	public PedidoDetalle(Producto producto, int cantidad, decimal precioUnitario) {
        Producto = producto;
		Cantidad = cantidad;
		PrecioUnitario = precioUnitario;
	} 
}
public class Pedido {
	public int Id { get; set; }
	public Cliente Cliente { get; set; }
	public List<PedidoDetalle> Detalles { get; set; }
		= new List<PedidoDetalle>();

	//constructor
	public Pedido(int id, Cliente cliente) {
		Id = id;
		Cliente = cliente;
	}
}