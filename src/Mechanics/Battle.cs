using PokemonCLI.UI;

namespace PokemonCLI.Mechanics;
using Models;

public class Battle
{
    private Pokemon Ally;
    private Pokemon Enemy;
    private GameTUI Tui;

    public Battle(Pokemon ally, Pokemon enemy, GameTUI tui)
    {
        Ally = ally;
        Enemy = enemy;
        Tui = tui;
    }

    private double CalculateDamage(Pokemon attacker, Move move, Pokemon defender)
    {
        var stab = Stab(attacker.Type, move.Type);
        var multiplier = TypeMultiplier(move.Type, defender.Type);
        
        //casting at least one number to double promotes the other type also to double (int32 -> float64 or double64)
        double attackOverDefense = (double)attacker.Attack / defender.Defense;
        
        var rnd = new Random();
        double random = (double)rnd.Next(217, 256) / 255;
        
        double power = ((attackOverDefense * move.Power) / 50) + 2;
        
        return power * stab * multiplier * random;
    }

    private double Stab(Type attacker, Type move)
    {
        double multiplier = 1;
        if (attacker == move)
        {
            multiplier *= 1.5;
        }
        return multiplier;
    }

    private double TypeMultiplier(Type move, Type defender)
    {
        double multiplier = 1;
        switch (move)
        {
            case Type.Normal:
                switch (defender)
                {
                    case Type.Normal:
                        multiplier *= 1;
                        break;
                    case Type.Fire:
                        multiplier *= 1;
                        break;
                    case Type.Grass:
                        multiplier *= 1;
                        break;
                    case Type.Water:
                        multiplier *= 1;
                        break;
                }
                break;
            
            case Type.Fire:
                switch (defender)
                {
                    case Type.Normal:
                        multiplier *= 1;
                        break;
                    case Type.Fire:
                        multiplier *= 0.5;
                        break;
                    case Type.Grass:
                        multiplier *= 2;
                        break;
                    case Type.Water:
                        multiplier *= 0.5;
                        break;
                }
                break;
            
            case Type.Grass:
                switch (defender)
                {
                    case Type.Normal:
                        multiplier *= 1;
                        break;
                    case Type.Fire:
                        multiplier *= 0.5;
                        break;
                    case Type.Grass:
                        multiplier *= 0.5;
                        break;
                    case Type.Water:
                        multiplier *= 2;
                        break;
                }
                break;
            
            case Type.Water:
                switch (defender)
                {
                    case Type.Normal:
                        multiplier *= 1;
                        break;
                    case Type.Fire:
                        multiplier *= 2;
                        break;
                    case Type.Grass:
                        multiplier *= 0.5;
                        break;
                    case Type.Water:
                        multiplier *= 0.5;
                        break;

                }
                break;
        }
        return multiplier;
    }
    
}