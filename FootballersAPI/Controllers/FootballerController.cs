using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballerController : ControllerBase
    {
        //private static List<Footballer> footballers = new()
        //{
        //    new Footballer(2, "Cristiano", "Ronaldo", "Portugese", "Manchester United")
        //};

        private readonly DataContext _context;

        public FootballerController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Footballer>>> Get()
        {
            return Ok(await _context.Footballers.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Footballer>> Get(int id)
        {
            var footballer = await _context.Footballers.FindAsync(id);
            if(footballer is null) return BadRequest("Footballer not found");

            return Ok(footballer);
        }

        [HttpPost]
        public async Task<ActionResult<List<Footballer>>> AddFootballer(Footballer footballer)
        {
            _context.Footballers.Add(footballer);
            await _context.SaveChangesAsync();  //saving changes after altering database
            return Ok(await _context.Footballers.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Footballer>>> UpdateFootballer(Footballer request)
        {
            var dbFootballer = await _context.Footballers.FindAsync(request.Id);
            if (dbFootballer is null)
                return BadRequest("Footballer with given id not found");

            dbFootballer.FirstName = request.FirstName;
            dbFootballer.LastName= request.LastName;
            dbFootballer.Nationality= request.Nationality;
            dbFootballer.PlayersClub = request.PlayersClub;

            await _context.SaveChangesAsync();

            return Ok(await _context.Footballers.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Footballer>>> DeleteFootballer(int id)
        {
            var dbFootballer = await _context.Footballers.FindAsync(id);
            if (dbFootballer is null)
                return BadRequest("Footballer with given id not found");

            _context.Footballers.Remove(dbFootballer);
            await _context.SaveChangesAsync();

            return Ok(await _context.Footballers.ToListAsync());
            
        }
    }
}
