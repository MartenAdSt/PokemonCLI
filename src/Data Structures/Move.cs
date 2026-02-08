namespace PokemonCLI.Data_Structures;

public class Move
{
    private String name;
    private String description;
    private Type type;
    private int power;
    private int accuracy;

    public Move(string name, string description, Type type, int power, int accuracy)
    {
        this.name = name;
        this.description = description;
        this.type = type;
        this.power = power;
        this.accuracy = accuracy;
    }
}