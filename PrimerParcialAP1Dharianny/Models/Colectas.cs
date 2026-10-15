using Microsoft.Extensions.Logging.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace PrimerParcialAP1Dharianny.Models;

public class Colectas
{
    [Key]
    public int AporteId { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    public DateTime? Fecha { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    public string Nombres { get; set; } = null!;

    [Range(1, double.MaxValue, ErrorMessage = "El monto debe ser mayor que cero.")]
    public double? Monto { get; set; }
}
