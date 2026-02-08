namespace PokemonCLI.Services;

using System.Text.Json;
using PokemonCLI.Models;

public class PokemonManager
{
    private readonly string _filePath;
    private List<Pokemon> _pokemons;
    
    public PokemonManager(string filePath)
    {
        _filePath = filePath;
        Load();
    }

    public void Add(Pokemon pokemon)
    {
        _pokemons.Add(pokemon);
        Save();
    }
    
    public void Save()
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(_pokemons, options);
        File.WriteAllText(_filePath, json);
    }

    
    public List<Pokemon> Get()
    {
        return _pokemons;
    }


    public void Load()
    {
        if (!File.Exists(_filePath))
        {
            Console.WriteLine("File not found.");
            return;
        }

        var json = File.ReadAllText(_filePath);
        _pokemons = JsonSerializer.Deserialize<List<Pokemon>>(json) ?? new();
    }

    public Pokemon getPokemon(string name)
    {
        return _pokemons.FirstOrDefault(p => p.Name == name);
    }
}