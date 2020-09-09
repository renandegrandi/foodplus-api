using System;

namespace FoodPlus.Api.Domain
{
    public class Recipe
    {
        #region Properties

        public Guid? Id { get; private set; }
        public string Title { get; private set; }
        public string Description  { get; private set; }
        public string PreparationInstructions { get; private set; }

        #endregion

        public Recipe(Guid id, string title, string description, string instructions) : this(title, description, instructions) 
        {
            Id = id;
        }

        public Recipe(string title, string description, string instructions)
        {
            if (Id == null)
                Id = Guid.NewGuid();

            Title = title;
            Description = description;
            PreparationInstructions = instructions;
        }

        public void Valid() 
        {
            if (!string.IsNullOrWhiteSpace(Title))
                throw new Exception("O titulo é obrigatório");
        }

        public Recipe AlterarDescricao(string descricao) 
        {
            Description = descricao;

            return this;
        }

        public Recipe AlterarTitle(string title)
        {
            Title = title;

            return this;
        }
    }
}
