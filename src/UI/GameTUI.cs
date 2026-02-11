namespace PokemonCLI.UI;

using Models;
using Services;

// ReSharper disable once InconsistentNaming
public class GameTUI(string pokemonsFilePath)
{
    private readonly PokemonManager _pokemonManager = new (pokemonsFilePath);
    
    public Pokemon ChooseStarter()
    {
        Console.WriteLine("------------------------------------------");
        Console.WriteLine("What pokemon would you like to use?");
        Console.WriteLine("Patrat | Tepig | Snivy | Oshawott");

        while (true)
        {
            string? input = Console.ReadLine();
            
            string[] validStarters = ["Patrat", "Tepig", "Snivy", "Oshawott"];
            string? pokemonName = validStarters.Contains(input) ? input : null;

            if (pokemonName != null)
            {
                Console.WriteLine("------------------------------------------");
                Console.WriteLine($"You chose {input}!");
                return _pokemonManager.getPokemon(pokemonName);
            }
            
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Please enter a valid pokemon name.");
            Console.WriteLine("Patrat | Tepig | Snivy | Oshawott");
        }
    }

    public Pokemon ChooseOpponent(string starter)
    {
        Console.WriteLine("------------------------------------------");
        Console.WriteLine("What pokemon would you like to battle?");
        Console.WriteLine("Patrat | Tepig | Snivy | Oshawott");
        while (true)
        {
            string? input = Console.ReadLine();
            
            string[] validPokemons = ["Patrat", "Tepig", "Snivy", "Oshawott"];
            string? pokemonName = validPokemons.Contains(input) ? input : null;

            if (pokemonName != null && pokemonName != starter)
            {
                Console.WriteLine("------------------------------------------");
                Console.WriteLine($"You chose {input}!");
                return _pokemonManager.getPokemon(pokemonName);
            }

            if (pokemonName == starter)
            {
                Console.WriteLine("You cannot battle yourself");
            }
            
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Please enter a valid pokemon name.");
            Console.WriteLine("Patrat | Tepig | Snivy | Oshawott");
        }
    }

    public void ShowAllyPokemon(Pokemon pokemon)
    {
        Console.WriteLine($"""
                          ----------------------------------------------------------------------------------------------                
                          Your {pokemon.Name} ({pokemon.Type}) has {pokemon.CurrHp}/{pokemon.MaxHp} HP 
                          
                          | {pokemon.Move1.Name} ({pokemon.Move1.Type})     
                          | {pokemon.Move1.Power} Power {pokemon.Move1.Accuracy} Acc  
                          
                          | {pokemon.Move2.Name} ({pokemon.Move2.Type}) 
                          | {pokemon.Move2.Power} Power {pokemon.Move2.Accuracy} Acc 
                          ----------------------------------------------------------------------------------------------                
                          """);
    }

    public void ShowEnemyPokemon(Pokemon pokemon)
    {
        Console.WriteLine($"""
                           ----------------------------------------------------------------------------------------------                
                           Opponent {pokemon.Name} ({pokemon.Type}) has {pokemon.CurrHp}/{pokemon.MaxHp} HP 
                           """);
    }

    public int AskForMove()
    {
        Console.WriteLine("Type '1' or '2' to use that move.");
        while (true)
        {
            string? input = Console.ReadLine();
            if (input == null || input.Length > 1 || !Char.IsDigit(input[0]))
            {
                Console.WriteLine("Type '1' or '2' to use that move.");
            }
            else
            {
                return int.Parse(input);
            }
        }
    }

    public void BattleUI(Pokemon ally, Pokemon enemy)
    {
        ShowEnemyPokemon(enemy);
        ShowAllyPokemon(ally);
    }
}