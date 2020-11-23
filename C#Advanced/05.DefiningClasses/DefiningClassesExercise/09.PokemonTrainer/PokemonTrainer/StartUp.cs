using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        var trainers = new List<Trainer>();
        string command = string.Empty;

        while ((command = Console.ReadLine()) != "Tournament")
        {
            var info = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string trainerName = info[0];
            string pokemonName = info[1];
            string element = info[2];
            int health = int.Parse(info[3]);

            if (!trainers.Any(t => t.Name == trainerName))
            {
                var trainer = new Trainer(trainerName);
                trainers.Add(trainer);
            }

            var currentTrainer = trainers.FirstOrDefault(t => t.Name == trainerName);

            if (!currentTrainer.Pokemons.Any(p => p.Name == pokemonName))
            {
                var pokemon = new Pokemon(pokemonName, element, health);
                currentTrainer.Pokemons.Add(pokemon);
            }
            else
            {
                currentTrainer.Pokemons.FirstOrDefault(p => p.Name == pokemonName).Element = element;
                currentTrainer.Pokemons.FirstOrDefault(p => p.Name == pokemonName).Health += health;
            }
        }

        string elementInput = string.Empty;
        while ((elementInput = Console.ReadLine()) != "End")
        {
            for (int i = 0; i < trainers.Count; i++)
            {
                var currentTrainer = trainers[i];

                if (currentTrainer.Pokemons.Any(p => p.Element.Equals(elementInput)))
                {
                    currentTrainer.Badges++;
                }
                else
                {
                    currentTrainer.Pokemons.ForEach(p => p.Health -= 10);
                    for (int j = 0; j < currentTrainer.Pokemons.Count; j++)
                    {
                        if (currentTrainer.Pokemons[j].Health <= 0)
                        {
                            currentTrainer.Pokemons.RemoveAt(j);
                            j--;
                        }
                    }
                }
            }
        }

        trainers = trainers.OrderByDescending(t => t.Badges).ToList();

        foreach (var trainer in trainers)
        {
            Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
        }
    }
}