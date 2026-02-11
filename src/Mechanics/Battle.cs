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

    public void StartBattle()
    {   
        var rnd = new Random();
        while (Ally.CurrHp > 0 && Enemy.CurrHp > 0)
        {
            Tui.WhiteSpace();
            Tui.BattleUI(Ally, Enemy);
            var allyMove = ManualMove(Ally);
            var enemyMove = AIMove();
            int turn = rnd.Next(0, 2);
            
            //TODO make this speed dependent
            //Ally's move is first
            if (turn == 0)
            {
                MakeMove(Ally, allyMove, Enemy);
                Tui.AttackUI(Ally, allyMove, Enemy);
                

                if (Enemy.CurrHp > 0)
                {
                    Tui.ShowEnemyPokemon(Enemy);
                    MakeMove(Enemy, enemyMove, Ally);
                    Tui.AttackUI(Enemy, enemyMove, Ally);
                } 
            }
            //Enemy's move is first
            else
            {
                MakeMove(Enemy, enemyMove, Ally);
                Tui.AttackUI(Enemy, enemyMove, Ally);
                
                
                if (Ally.CurrHp > 0)
                {
                    Tui.ShowAllyPokemon(Ally);
                    MakeMove(Ally, allyMove, Enemy);
                    Tui.AttackUI(Ally, allyMove, Enemy);
                }
                
            }
        }
        
        //Announce winner
        if (Ally.CurrHp > 0)
        {
            Tui.FaintedMessage(Enemy);
            Tui.WinnerMessage(Ally);
        }
        else
        {
            Tui.FaintedMessage(Ally);
            Tui.WinnerMessage(Enemy);
        }
    }

    private Move ManualMove(Pokemon pokemon)
    {
        var moveIndex = Tui.AskForMove(pokemon);
        Move move = moveIndex switch
        {
            1 => Ally.Move1,
            2 => Ally.Move2,
            _ => throw new Exception("Unknown move: " + moveIndex)
        };
        return move;
    }

    private Move AIMove()
    {
        var rnd = new Random();
        var moveIndex = rnd.Next(1, 3);
        Move move = moveIndex switch
        {
            1 => Enemy.Move1,
            2 => Enemy.Move2,
            _ => throw new Exception("Unknown move: " + moveIndex)
        };
        return move;
    }

    private void MakeMove(Pokemon attacker, Move move, Pokemon defender)
    {
        var damage = CalculateDamage(attacker, move, defender);
        defender.TakeDamage(damage);
        
    }

    private int CalculateDamage(Pokemon attacker, Move move, Pokemon defender)
    {
        var stab = Stab(attacker.Type, move.Type);
        var multiplier = TypeMultiplier(move.Type, defender.Type);
        
        //casting at least one number to double promotes the other type also to double (int32 -> float64 or double64)
        double attackOverDefense = (double)attacker.Attack / defender.Defense;
        
        var rnd = new Random();
        double random = (double)rnd.Next(217, 256) / 255;
        
        double power = ((attackOverDefense * move.Power) / 50) + 2;

        var result = power * stab * multiplier * random;
        
        return (int)result;
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