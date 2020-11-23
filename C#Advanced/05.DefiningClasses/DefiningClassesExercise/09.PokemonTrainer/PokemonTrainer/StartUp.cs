using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            List<Trainer> trainers = new List<Trainer>();
            while ((input = Console.ReadLine()) != "Tournament")
            {
                var data = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                var name = data[0];
                var pokemonName = data[1];
                var element = data[2];
                var health = int.Parse(data[3]);
                Pokemon pokemon = new Pokemon(pokemonName, element, health);
                if (trainers.Any(x => x.Name.Contains(name)))
                {
                    int index = trainers.FindIndex(x => x.Name == name);
                    Trainer trainer = trainers.Where(x => x.Name == name).FirstOrDefault();
                    trainers.RemoveAt(index);
                    trainer.Pokemon.Add(pokemon);
                    trainers.Insert(index, trainer);
                }
                else
                {
                    Trainer trainer = new Trainer(name, pokemon);
                    trainers.Add(trainer);
                }

            }
            while ((input = Console.ReadLine()) != "End")
            {

                foreach (Trainer trainer in trainers)
                {
                    bool flag = true;
                    foreach (Pokemon pokemon in trainer.Pokemon)
                    {
                        if (pokemon.Element == input)
                        {
                            trainer.NumberOfBadges++;
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                    {
                        for (int i = 0; i < trainer.Pokemon.Count; i++)
                        {
                            trainer.Pokemon[i].Health -= 10;
                            if (trainer.Pokemon[i].Health <= 0)
                            {
                                trainer.Pokemon.RemoveAt(i);
                            }
                        }
                    }
                }
            }
            trainers
                .OrderByDescending(x=>x.NumberOfBadges)
                .ToList()
                .ForEach(x => Console.WriteLine(x));
        }
    }
}
