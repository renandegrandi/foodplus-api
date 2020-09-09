using FoodPlus.Api.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodPlus.Api.Repository
{
    public interface IRecipeRepository
    {
        Task<Recipe> GetByIdAsync(Guid id);
        Task<IEnumerable<Recipe>> GetAsync();
        Task<Guid> CreateAsync(Recipe recipe);
        Task UpdateAsync(Recipe recipe);
        Task RemoveAsync(Guid id);
    }
}
