using CrudDotNet8.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudDotNet8.Datos;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    //Cada modelo corresponde a una tabla de la base de datos
    public DbSet<Contacto> Contacto { get; set; }
}