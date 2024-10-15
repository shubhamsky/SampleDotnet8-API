using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI_DotNet8.Data;
using SuperHeroAPI_DotNet8.Entities;

namespace SuperHeroAPI_DotNet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public SuperHeroController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        /// <summary>
        /// GetAllHeroes.
        /// </summary>
        /// <returns> List of Heroes. </returns>
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            var heroes = await _dataContext.SuperHeroes.ToListAsync();

            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetHero(int id)
        {
            var hero = await _dataContext.SuperHeroes.FindAsync(id);
            if (hero is null)
                return NotFound("Hero not found");

            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<SuperHero>> AddHero(SuperHero hero)
        {
            _dataContext.SuperHeroes.Add(hero);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.SuperHeroes.ToListAsync());
        }

        /// <summary>
        /// UpdateHero
        /// </summary>
        /// <param name="updatedHero"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<SuperHero>> UpdateHero(SuperHero updatedHero)
        {
            var dbHero = await _dataContext.SuperHeroes.FindAsync(updatedHero.Id);
            if (dbHero is null)
                return NotFound("Hero not found.");

            dbHero.Name = updatedHero.Name;
            dbHero.FirstName = updatedHero.FirstName;
            dbHero.LastName = updatedHero.LastName;
            dbHero.Place = updatedHero.Place;

            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.SuperHeroes.FindAsync(dbHero.Id));
        }

        /// <summary>
        /// DeleteHero
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Updated Hero List</returns>
        [HttpDelete]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var dbHero = await _dataContext.SuperHeroes.FindAsync(id);
            if (dbHero is null)
                return NotFound("Hero not found.");

            _dataContext.SuperHeroes.Remove(dbHero);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.SuperHeroes.ToListAsync());
        }
    }
}
