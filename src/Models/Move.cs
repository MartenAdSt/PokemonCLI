namespace PokemonCLI.Models;

public class Move(string name, string description, Type type, int power, int accuracy)
{
    public string Name { get; set; } = name;
    public string Description { get; set; } = description;
    public Type Type { get; set; } = type;
    public int Power { get; set; } = power;
    public int Accuracy { get; set; } = accuracy;
}