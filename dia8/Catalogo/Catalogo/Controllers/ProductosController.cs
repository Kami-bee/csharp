using Microsoft.AspNetCore.Mvc;
using Catalogo.Models;

namespace Catalogo.Crontrollers;

public class ProductosController : Controller
{
	public IActionResult Index()
	{
		List<Producto> productos = new List<Producto>
		{
			new Producto { Codigo = "K001", Nombre = "Gaseosa 500ml", Categoria = "Bebida", PrecioVenta = 6000, Stock = 19 },
			new Producto { Codigo = "K002", Nombre = "Agua mineral 1 l", Categoria = "Bebida", PrecioVenta = 4500, Stock = 4 },
			new Producto { Codigo = "K003", Nombre = "Alfojar", Categoria = "Golosina", PrecioVenta = 3500, Stock = 40 },
			new Producto { Codigo = "K004", Nombre = "Chocolate", Categoria = "Golosina", PrecioVenta = 7000, Stock = 3 },
			new Producto { Codigo = "K005", Nombre = "Yogur", Categoria = "Lacteo", PrecioVenta = 4000, Stock = 10 }
		};
		return View(productos);
	}
}
