namespace PokemonCLI.Models;

public class Pokemon(string name, Type type, int exp, int hp, int attack, int defense, Move move1, Move move2)
{
    public string Name {get; set; } = name;
    public Type Type {get; set; } = type;
    private int Exp {get; set; } = exp;
    private int Hp {get; set; } = hp;
    private int Attack  {get; set; } = attack;
    private int Defense {get; set; } = defense;
    private Move Move1 {get; set; } = move1;
    private Move Move2 {get; set; } = move2;
}

