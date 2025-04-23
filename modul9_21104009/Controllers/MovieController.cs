using Microsoft.AspNetCore.Mvc;
namespace modul9_21104009.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovieController: ControllerBase
{
    private static List<Movie> movies = new List<Movie>
    {
        new Movie
        {
            Id = 1,
            Title = "The Shawshank Redemption",
            Director = "Frank Darabont",
            Stars = new List<string> { "Tim Robbins", "Morgan Freeman", "Bob Gunton" },
            Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency."
        },
        new Movie
        {
            Id = 2,
            Title = "The Godfather",
            Director = "Francis Ford Coppola",
            Stars = new List<string> { "Marlon Brando", "Al Pacino", "James Caan" },
            Description = "An organized crime dynasty's aging patriarch transfers control of his clandestine empire to his reluctant son."
        },
        new Movie
        {
            Id = 3,
            Title = "The Dark Knight",
            Director = "Christopher Nolan",
            Stars = new List<string> { "Christian Bale", "Heath Ledger", "Aaron Eckhart" },
            Description = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice."
        },
        new Movie
        {
            Id = 4,
            Title = "12 Angry Men",
            Director = "Sidney Lumet",
            Stars = new List<string> { "Henry Fonda", "Lee J. Cobb", "Martin Balsam" },
            Description = "A jury holdout attempts to prevent a miscarriage of justice by forcing his colleagues to reconsider the evidence."
        },
        new Movie
        {
            Id = 5,
            Title = "Schindler's List",
            Director = "Steven Spielberg",
            Stars = new List<string> { "Liam Neeson", "Ralph Fiennes", "Ben Kingsley" },
            Description = "In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis."
        }
    };
    
    // GET: api/movies
    [HttpGet]
    public ActionResult<IEnumerable<Movie>> GetAll()
    {
        return Ok(movies);
    }

    // Get: api/movie/{id}
    [HttpGet("{id}")]
    public ActionResult<Movie> GetById(int id)
    {
        var movie = movies.FirstOrDefault(m => m.Id == id);
        if (movie == null) return NotFound();
        return Ok(movie);
    }
    
    // POST: api/movies
    [HttpPost]
    public ActionResult<Movie> Create(Movie movie)
    {
        movie.Id = movies.Max(m => m.Id) + 1;
        movies.Add(movie);
        return CreatedAtAction(nameof(GetById), new { id = movie.Id }, movie);
    }
 
    // DELETE: api/movies/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var movie = movies.FirstOrDefault(m => m.Id == id);
        if (movie == null) return NotFound();
        movies.Remove(movie);
        return NoContent();
    }
    
}