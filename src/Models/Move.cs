namespace PokemonCLI.Models;

public class Move(string name, string description, Type type, int power, int accuracy)
{
    private string Name { get; set; } = name;
    private string Description { get; set; } = description;
    private Type Type { get; set; } = type;
    private int Power { get; set; } = power;
    private int Accuracy { get; set; } = accuracy;
}