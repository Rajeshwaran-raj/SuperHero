using SuperHeroAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces.Repositories
{
    public interface ISuperHeroRepository
    {
        Task<List<SuperHero>> GetAllAsync();
        Task<SuperHero?> GetByIdAsync(Guid id);
        Task AddAsync(SuperHero superHero);
        Task UpdateAsync(SuperHero superHero);
        Task DeleteAsync(Guid id);
    }
}
