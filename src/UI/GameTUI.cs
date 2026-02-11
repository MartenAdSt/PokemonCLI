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

    public void AttackUI(Pokemon attacker, Move move, Pokemon defender)
    {
        Console.WriteLine($"""
                           ----------------------------------------------------------------------------------------------                
                           {attacker.Name} ({attacker.Type}) used {move} ({move.Type}) 
                           """);
        WaitDots(3);
        
        EffectivenessMessage(move, defender);
    }

    private void WaitDots(int ticks)
    {
        var tick = 0;
        while (tick < ticks)
        {
            Console.Write(".");
            Thread.Sleep(10);
            tick++;
        }
        Thread.Sleep(100);
    }

    private void EffectivenessMessage(Move move, Pokemon defender)
    {
        var effectiveness = Effectiveness(move.Type, defender.Type);
        switch (effectiveness)
        {
            case 0:
                Console.WriteLine($"""
                                   It didn't affect {defender.Name}...
                                   """);
                break;
            case 1:
                Console.WriteLine($"""
                                   It's not very effective...
                                   """);
                break;
            case 2: 
                break;
            case 3:
                Console.WriteLine($"""
                                   It's super effective!
                                   """);
                break;
        }
    }

    public void FaintedMessage(Pokemon pokemon)
    {
        Console.WriteLine($"""
                           ----------------------------------------------------------------------------------------------                
                           {pokemon.Name} has fainted.)
                           """);
    }

    public void WinnerMessage(Pokemon pokemon)
    {
        Console.WriteLine($"""
                           {pokemon.Name} won the battle!)
                           """);
    }
    
    private int Effectiveness(Type move, Type defender)
    {
        int effectiveness = 1;
        switch (move)
        {
            case Type.Normal:
                switch (defender)
                {
                    case Type.Normal:
                        effectiveness = 2;
                        break;
                    case Type.Fire:
                        effectiveness = 2;
                        break;
                    case Type.Grass:
                        effectiveness = 2;
                        break;
                    case Type.Water:
                        effectiveness = 2;
                        break;
                }
                break;
            
            case Type.Fire:
                switch (defender)
                {
                    case Type.Normal:
                        effectiveness = 2;
                        break;
                    case Type.Fire:
                        effectiveness = 1;
                        break;
                    case Type.Grass:
                        effectiveness = 3;
                        break;
                    case Type.Water:
                        effectiveness = 1;
                        break;
                }
                break;
            
            case Type.Grass:
                switch (defender)
                {
                    case Type.Normal:
                        effectiveness = 2;
                        break;
                    case Type.Fire:
                        effectiveness = 1;
                        break;
                    case Type.Grass:
                        effectiveness = 1;
                        break;
                    case Type.Water:
                        effectiveness = 3;
                        break;
                }
                break;
            
            case Type.Water:
                switch (defender)
                {
                    case Type.Normal:
                        effectiveness = 2;
                        break;
                    case Type.Fire:
                        effectiveness = 3;
                        break;
                    case Type.Grass:
                        effectiveness = 1;
                        break;
                    case Type.Water:
                        effectiveness = 1;
                        break;

                }
                break;
        }
        return effectiveness;
    }
    
    
}