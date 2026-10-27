using Microsoft.AspNetCore.Mvc;
using Trivia.Data;
using Trivia.Models;

namespace Trivia.Controllers;

public class PreguntasController : Controller
{
    private readonly SupabaseCliente _supabase;

    public PreguntasController(SupabaseCliente supabase)
    {
        _supabase = supabase;
    }

    public async Task<IActionResult> Index()
    {
        List<Pregunta> preguntas = await _supabase.Listar<Pregunta>("Preguntas?select=*&order=id.asc");
        return View(preguntas);
    }
}
