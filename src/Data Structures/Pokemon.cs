namespace PokemonCLI.Data_Structures;

public class Pokemon
{
    private String name;
    private Type type;
    private int exp;
    private int hp;
    private int attack;
    private int defense;
    private Move move1;
    private Move move2;

    public Pokemon(String name, Type type, int exp, int hp, int attack, int defense, Move move1, Move move2)
    {
        this.name = name;
        this.type = type;
        this.exp = exp;
        this.hp = hp;
        this.attack = attack;
        this.defense = defense;
        this.move1 = move1;
        this.move2 = move2;
    }
}