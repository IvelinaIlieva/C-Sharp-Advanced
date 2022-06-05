using System.Collections.Generic;

namespace Pokemon
{
    public class Trainer
    {
        private string name;
        private int badges;
        private List<Pokemon> pokemons;
        public string Name { get { return name; } set { name = value; } }
        public int Badges { get { return badges; } set { badges = value; } }
        public List<Pokemon> Pokemons { get { return pokemons; } set { pokemons = value; } }

        public Trainer(string name)
        {
            this.Name = name;
            this.Badges = 0;
            this.Pokemons = new List<Pokemon>();
        }
    }
}
