using Microsoft.AspNetCore.Mvc;
using Catalogolista.Models;

namespace Catalogolista.Controllers;

public class ArticuloController : Controller
{
	public IActionResult Index()
	{
		List<Articulo> articulos = new List<Articulo>
		{
			new Articulo { Codigo = "K001", Nombre = "Jabones", Categoria = "Limpieza", PrecioVenta = 5000, Stock = 5 },
			new Articulo { Codigo = "K002", Nombre = "Jabon liquido 900 ml", Categoria = "Limpieza", PrecioVenta = 9000, Stock = 3 },
			new Articulo { Codigo = "K003", Nombre = "Esponjas de platos", Categoria = "Limpieza", PrecioVenta = 3000, Stock = 10 },
			new Articulo { Codigo = "K004", Nombre = "Peine", Categoria = "Tocador", PrecioVenta = 10000, Stock = 6 },
			new Articulo { Codigo = "K005", Nombre = "Toalla", Categoria = "Articulo de mano", PrecioVenta = 45000, Stock = 2 },
			new Articulo { Codigo = "K006", Nombre = "Cepillo dental", Categoria = "Limpieza", PrecioVenta = 15000, Stock = 8 },
			new Articulo { Codigo = "K007", Nombre = "Focos", Categoria = "Hogar", PrecioVenta = 10000, Stock = 15 },
			new Articulo { Codigo = "K008", Nombre = "Escoba", Categoria = "Casa", PrecioVenta = 13000, Stock = 10 },
			new Articulo { Codigo = "K009", Nombre = "Espejo", Categoria = "Tocador", PrecioVenta = 30000, Stock = 15 },
			new Articulo { Codigo = "K0010", Nombre = "Cuchillo", Categoria = "Cocina", PrecioVenta = 45000, Stock = 7 }
		};

		return View(articulos);
	}
}