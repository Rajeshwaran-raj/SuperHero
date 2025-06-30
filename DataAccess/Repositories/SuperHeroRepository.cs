using BusinessLogic.Interfaces.Repositories;
using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class SuperHeroRepository : ISuperHeroRepository
    {
        private readonly DataContext _context;

        public SuperHeroRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<SuperHero>> GetAllAsync()
        {
            return await _context.SuperHero
                .Select(e => new SuperHero
                {
                    Id = e.Id,
                    Name = e.Name,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Origin = e.Origin
                })
                .ToListAsync();
        }

        public async Task<SuperHero?> GetByIdAsync(Guid id)
        {
            var entity = await _context.SuperHero.FindAsync(id);
            if (entity == null)
                return null;

            return new SuperHero
            {
                Id = entity.Id,
                Name = entity.Name,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Origin = entity.Origin
            };
        }

        public async Task AddAsync(SuperHero superHero)
        {
            var entity = new SuperHeroEntity
            {
                Id = superHero.Id != Guid.Empty ? superHero.Id : Guid.NewGuid(),
                Name = superHero.Name,
                FirstName = superHero.FirstName,
                LastName = superHero.LastName,
                Origin = superHero.Origin
            };

            await _context.SuperHero.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SuperHero superHero)
        {
            var entity = await _context.SuperHero.FindAsync(superHero.Id);
            if (entity == null)
                throw new Exception("Superhero not found");

            entity.Name = superHero.Name;
            entity.FirstName = superHero.FirstName;
            entity.LastName = superHero.LastName;
            entity.Origin = superHero.Origin;

            _context.SuperHero.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.SuperHero.FindAsync(id);
            if (entity == null)
                throw new Exception("Superhero not found");

            _context.SuperHero.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
