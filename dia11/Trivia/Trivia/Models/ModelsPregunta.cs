using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Trivia.Models;

public class Pregunta
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Escribe la pregunta.")]
    public string Texto { get; set; } = "";

    [JsonPropertyName("opcion_a")]
    [Display(Name = "Opcion A")]
    [Required(ErrorMessage = "Escribe la opcion A.")]
    public string OpcionA { get; set; } = "";

    [JsonPropertyName("opcion_b")]
    [Display(Name = "Opcion B")]
    [Required(ErrorMessage = "Escribe la opcion B.")]
    public string OpcionB { get; set; } = "";

    [JsonPropertyName("opcion_C")]
    [Display(Name = "Opcion C")]
    [Required(ErrorMessage = "Escribe la opcion C.")]
    public string OpcionC { get; set; } = "";

	[JsonPropertyName("opcion_d")]
	[Display(Name = "Opcion D")]
	[Required(ErrorMessage = "Escribe la opcion D.")]
	public string OpcionD { get; set; } = "";

    [Display(Name = "Respuesta correcta")]
    [RegularExpression("^[ABCD]$", ErrorMessage = "La respueta correcta debe ser A, B, C o D.")]
	public string Correcta { get; set; } = "A";
}