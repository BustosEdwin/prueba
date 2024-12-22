using Microsoft.EntityFrameworkCore;
using prueb.sql.Model;

namespace SQLitePCL.Model;

public class ContextoDb : DbContext
{
    private string DbPath { get; set; }

    public ContextoDb()
    {
        string ruta = Environment.CurrentDirectory;
        string folderDatabase = $"/DataBase";

        if (!Directory.Exists($"{ruta}{folderDatabase}"))
        {
            Directory.CreateDirectory($"{ruta}{folderDatabase}");
        }

        DbPath = $"{ruta}{folderDatabase}";
    }

    public DbSet<Pelicula> Peliculas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlite($"Data Source={DbPath}/Peliculas.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pelicula>().HasKey(x => x.Id);
        modelBuilder.Entity<Pelicula>().Property(x => x.Id);
        modelBuilder.Entity<Pelicula>().Property(x => x.Titulo).IsRequired();
        modelBuilder.Entity<Pelicula>().Property(x => x.Genero).IsRequired();
        modelBuilder.Entity<Pelicula>().Property(x => x.Director).IsRequired();
        modelBuilder.Entity<Pelicula>().Property(x => x.Actores).IsRequired();
        modelBuilder.Entity<Pelicula>().Property(x => x.Sinopsis).IsRequired();
        modelBuilder.Entity<Pelicula>().Property(x => x.Imagen).IsRequired();

    }

}