using FoodPlus.Api.Domain;
using FoodPlus.Api.Models.V1;
using FoodPlus.Api.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FoodPlus.Api.Controllers.V1
{
    [ApiController]
    [Route("api/v1/recipe")]
    public class RecipeController: Controller
    {
        #region Dependências

        private readonly IRecipeRepository _recipeRepository;

        #endregion

        #region Constructor

        public RecipeController(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        #endregion

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute(Name = "id")]Guid id) 
        {
            var item = await _recipeRepository.GetByIdAsync(id);

            return Ok(item);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var items = await _recipeRepository.GetAsync();

            return Ok(items);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]RecipeCreateDto dto)
        {
            var recipe = new Recipe(dto.Title, dto.Description, dto.Instructions);
            
            var id = await _recipeRepository.CreateAsync(recipe);

            return Created($"v1/recipe/{id}", null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute(Name = "id")]Guid id, [FromBody]RecipeUpdateDto dto)
        {
            var recipe = await _recipeRepository.GetByIdAsync(id);

            if (recipe == null)
                return BadRequest("Não conseguimos encontrar a receita");
            
            if (!string.IsNullOrEmpty(dto.Description))
                recipe.AlterarDescricao(dto.Description);

            if (!string.IsNullOrWhiteSpace(dto.Title))
                recipe.AlterarTitle(dto.Title);

            await _recipeRepository.UpdateAsync(recipe);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync([FromRoute(Name = "id")] Guid id)
        {
            await _recipeRepository.RemoveAsync(id);

            return NoContent();
        }
    }
}
