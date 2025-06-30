using BusinessLogic.Interfaces.Repositories;
using BusinessLogic.Interfaces.Services;
using SuperHeroAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class SuperHeroService : ISuperHero
    {
        private readonly ISuperHeroRepository _repository;
        public SuperHeroService(ISuperHeroRepository superHeroRepository) 
        {
            this._repository = superHeroRepository;
        }   

        public async Task<List<SuperHero>> GetAllUsersAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<SuperHero?> GetUserByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddUserAsync(SuperHero superHero)
        {
            if (superHero == null)
                throw new ArgumentNullException(nameof(superHero));
            await _repository.AddAsync(superHero);
        }

        public async Task UpdateUserAsync(SuperHero superHero)
        {
            if (superHero == null)
                throw new ArgumentNullException(nameof(superHero));
            await _repository.UpdateAsync(superHero);
        }

        public async Task DeleteUserAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Invalid ID", nameof(id));
            await _repository.DeleteAsync(id);
        }
    }
}
