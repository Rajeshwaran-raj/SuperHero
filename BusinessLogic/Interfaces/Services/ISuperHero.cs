using SuperHeroAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces.Services
{
    public interface ISuperHero
    {
        public Task<List<SuperHero>> GetAllUsersAsync();
        public Task<SuperHero?> GetUserByIdAsync(Guid id);
        public Task AddUserAsync(SuperHero superHero);
        public Task UpdateUserAsync(SuperHero superHero);
        public Task DeleteUserAsync(Guid id);
    }
}
