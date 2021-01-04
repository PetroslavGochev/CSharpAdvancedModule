using Raiding.Enumerator;
using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            List<BaseHero> listOFHero = new List<BaseHero>();
            int totalSum = 0;
            for (int i = 1; i <= number; i++)
            {
                string name = Console.ReadLine();
                string typeOfHero = Console.ReadLine();
                try
                {
                    BaseHero hero = CreateNewHero(name, typeOfHero);
                    listOFHero.Add(hero);
                    totalSum += hero.Power;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    i--;
                }
            }
            int powerOfBoss = int.Parse(Console.ReadLine());
            foreach (var hero in listOFHero)
            {
                Console.WriteLine(hero.CastAbility());
            }
            Console.WriteLine(Result(powerOfBoss, totalSum));
            
        }
        private static string Result(int bossPower, int heroesPower) => bossPower <= heroesPower ? "Victory!" : "Defeat...";
        private static BaseHero CreateNewHero(string name, string typeOfHero)
        {
           
            if (CheckHero(typeOfHero) == Hero.Druid)
            {
                return new Druid(name);
            }
            else if(CheckHero(typeOfHero) == Hero.Paladin)
            {
                return new Paladin(name);
            }
            else if (CheckHero(typeOfHero) == Hero.Rogue)
            {
                return new Rogue(name);
            }
            else 
            {
                return new Warrior(name);
            }
            
        }
        private static Hero CheckHero( string typeOfHero)
        {
            Hero hero;
            if(!Enum.TryParse<Hero>(typeOfHero,out hero))
            {
                throw new ArgumentException("Invalid hero!");
            }
            return hero;
        }


    }
}
