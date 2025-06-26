using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {



        public IConfiguration Configuration { get; set; }

        public SuperHeroController(IConfiguration configuration)
        {
            Configuration = configuration;
        }    

        private static readonly List<SuperHero> hero = new List<SuperHero>
            {          
             new SuperHero
                {
                 Name = "Captain America",
                 FirstName = "Stave",
                 LastName = "Rogers",
                 Origin = "Brooklyn"
                 },
             new SuperHero
                {
                 Name = "Iron Man",
                 FirstName = "Tony",
                 LastName = "Stark",
                 Origin = "US"
                }
            };

        [HttpGet] 
        public async Task<ActionResult<SuperHero>> Get()
        {
            return Ok(hero);
        }

        [HttpGet("ConnectionString")]
        public IActionResult GetConnectionString()
        {
            var connectionString = Configuration.GetConnectionString("ConnectionService");
            return Ok(connectionString);
        }
        
    }
}
