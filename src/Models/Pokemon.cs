namespace PokemonCLI.Models;

public class Pokemon(string name, Type type, int exp, int hp, int attack, int defense, Move move1, Move move2)
{
    public string Name {get; set; } = name;
    public Type Type {get; set; } = type;
    public int Exp {get; set; } = exp;
    public int Hp {get; set; } = hp;
    public int Attack  {get; set; } = attack;
    public int Defense {get; set; } = defense;
    public Move Move1 {get; set; } = move1;
    public Move Move2 {get; set; } = move2;
}

