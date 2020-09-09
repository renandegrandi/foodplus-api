using FoodPlus.Api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodPlus.Api.Repository
{
    /// <summary>
    /// Um repositório pode se comunicar com qualquer fonte de dados.
    /// API, Excel, Banco de dados relacional ou não relacional, tanto faz.
    /// </summary>
    public class RecipeRepository : IRecipeRepository
    {
        private readonly static List<Recipe> _recipes = new List<Recipe>();

        public Task<Guid> CreateAsync(Recipe recipe)
        {
            _recipes.Add(recipe);

            return Task.FromResult(recipe.Id.Value);
        }

        public Task<IEnumerable<Recipe>> GetAsync()
        {
            return Task.FromResult(_recipes.AsEnumerable());
        }

        public Task<Recipe> GetByIdAsync(Guid id)
        {
            var result = _recipes.FirstOrDefault((r) => r.Id == id);

            return Task.FromResult(result);
        }

        public Task RemoveAsync(Guid id)
        {
            var item = _recipes.FirstOrDefault((r) => r.Id == id);

            if (item != null)
                _recipes.Remove(item);

            return Task.CompletedTask;
        }

        public Task UpdateAsync(Recipe recipe)
        {
            var item = _recipes.FirstOrDefault((r) => r.Id == recipe.Id);

            if (item != null)
                _recipes.Remove(item);

            _recipes.Add(recipe);

            return Task.CompletedTask;
        }
    }
}
