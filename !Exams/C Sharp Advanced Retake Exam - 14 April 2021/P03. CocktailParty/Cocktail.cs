using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        private List<Ingredient> ingredients;
        private string name;
        private int capacity;
        private int maxAlcoholLevel;

        public List<Ingredient> Ingredients { get => ingredients; set => ingredients = value; }

        public string Name { get => name; set => name = value; }

        public int Capacity { get => capacity; set => capacity = value; }

        public int MaxAlcoholLevel { get => maxAlcoholLevel; set => maxAlcoholLevel = value; }

        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            this.Ingredients = new List<Ingredient>();
            this.Name = name;
            this.Capacity = capacity;
            this.MaxAlcoholLevel = maxAlcoholLevel;
        }

        public void Add(Ingredient ingredient)
        {
            if (Ingredients.All(i => i.Name != ingredient.Name) && Capacity > 0 && MaxAlcoholLevel >= ingredient.Alcohol)
            {
                Ingredients.Add(ingredient);
            }
        }

        public bool Remove(string name)
        {
            if (Ingredients.Any(i => i.Name == name))
            {
                Ingredient ingredient = Ingredients.First(i => i.Name == name);
                return Ingredients.Remove(ingredient);
            }
            return false;
        }

        public Ingredient FindIngredient(string name) => Ingredients.FirstOrDefault(i => i.Name == name);
        public Ingredient GetMostAlcoholicIngredient() => Ingredients.OrderByDescending(i => i.Alcohol).First();
        public int CurrentAlcoholLevel => Ingredients.Sum(i => i.Alcohol);

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");

            foreach (var ingr in Ingredients)
            {
                sb.AppendLine(ingr.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
