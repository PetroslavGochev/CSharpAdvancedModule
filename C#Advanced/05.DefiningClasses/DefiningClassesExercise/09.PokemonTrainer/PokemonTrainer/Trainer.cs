using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    class Trainer
    {
        public Trainer(string trainer,Pokemon pokemon)
        {
            this.Name = trainer;
            this.NumberOfBadges = 0;
            this.Pokemon = new List<Pokemon>();
            this.Pokemon.Add(pokemon);
        }
        public string Name { get; set; }
        public int NumberOfBadges { get; set;}
        public List<Pokemon> Pokemon { get; set; }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append($"{Name} {NumberOfBadges} {Pokemon.Count}");
            return result.ToString();
        }
    }
}
