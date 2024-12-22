using Microsoft.AspNetCore.Mvc;
using prueb.sql.Model;
using SQLitePCL.Model;

namespace prueb.sql.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PeliculaController : ControllerBase
{

    [HttpGet]
    [Route("[action]")]
    public IActionResult GetPeliculas()
    {
        using var db = new ContextoDb();
        var peliculas = db.Peliculas.ToList();
        return Ok(peliculas);
    }


    [HttpPost]
    [Route("[action]")]
    //Crear Peliculas 
    public IActionResult CrearPelicula([FromBody] Pelicula pelicula)
    {
        using var db = new ContextoDb();
        db.Peliculas.Add(pelicula);
        db.SaveChanges();
        return Ok();
    }

    [HttpDelete]
    [Route("[action]/{id}")]
    public IActionResult EliminarPelicula(int id)
    {
        using var db = new ContextoDb();
        var pelicula = db.Peliculas.Find(id);
        db.Peliculas.Remove(pelicula);
        db.SaveChanges();
        return Ok();
    }


    [HttpPut]
    [Route("[action]")]
    public IActionResult ActualizarPelicula([FromBody] Pelicula pelicula)
    {
        using var db = new ContextoDb();
        db.Peliculas.Update(pelicula);
        db.SaveChanges();
        string hola = "Hola mundo";
        return Ok();
    }

}
