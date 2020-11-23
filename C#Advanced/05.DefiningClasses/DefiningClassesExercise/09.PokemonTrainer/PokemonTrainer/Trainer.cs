using System;
using System.Collections.Generic;
using System.Text;

public class Trainer
{
    public string Name { get; set; }
    public int Badges { get; set; }
    public List<Pokemon> Pokemons { get; set; }

    public Trainer(string name)
    {
        this.Name = name;
        this.Pokemons = new List<Pokemon>();
    }
}