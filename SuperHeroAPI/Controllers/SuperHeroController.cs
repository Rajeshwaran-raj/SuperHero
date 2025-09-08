using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly IMongoCollection<SuperHero> _superHeroes;
        private readonly ILogger<SuperHeroController> _logger;

        public SuperHeroController(IMongoClient mongoClient, ILogger<SuperHeroController> logger)
        {
            var database = mongoClient.GetDatabase("superherodb"); // 👈 use your DB name
            _superHeroes = database.GetCollection<SuperHero>("SuperHeroes");
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            var heroes = await _superHeroes.Find(_ => true).ToListAsync();
            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(string id)
        {
            var hero = await _superHeroes.Find(h => h.Id == id).FirstOrDefaultAsync();
            if (hero == null)
                return NotFound("Hero not found.");
            return Ok(hero);
        }

        [HttpPost("CreateSuperHero")]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            try
            {
                await _superHeroes.InsertOneAsync(hero);
                var heroes = await _superHeroes.Find(_ => true).ToListAsync();
                return Ok(heroes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding a hero");
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request)
        {
            var result = await _superHeroes.ReplaceOneAsync(h => h.Id == request.Id, request);

            if (result.MatchedCount == 0)
                return NotFound("Hero not found.");

            var heroes = await _superHeroes.Find(_ => true).ToListAsync();
            return Ok(heroes);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> Delete(string id)
        {
            var result = await _superHeroes.DeleteOneAsync(h => h.Id == id);

            if (result.DeletedCount == 0)
                return NotFound("Hero not found.");

            var heroes = await _superHeroes.Find(_ => true).ToListAsync();
            return Ok(heroes);
        }
    }
}
