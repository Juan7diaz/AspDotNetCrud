using System.ComponentModel.DataAnnotations;

namespace CrudDotNet8.Models;

public class Contacto
{
    [Key]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "El nombre es requerido")]
    public string Nombre { get; set; }
    
    [Required(ErrorMessage = "El telefono es requerido")]
    public string Telefono { get; set; }
    
    [Required(ErrorMessage = "El celular es requerido")]
    public string Celular { get; set; }
    
    [Required(ErrorMessage = "El email es requerido")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "El fecha es requerido")]
    public DateTime FechaCreacion { get; set; }
}