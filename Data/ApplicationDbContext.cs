using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace APP2GAME.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<APP2GAME.Models.Cliente> DataCliente { get; set; }

    public DbSet<APP2GAME.Models.Contacto> DataContacto { get; set; }

    public DbSet<APP2GAME.Models.Categoria> DataCategoria { get; set; }

    public DbSet<APP2GAME.Models.Producto> DataProducto { get; set; }


    
}
