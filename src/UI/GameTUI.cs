namespace PokemonCLI;

// ReSharper disable once InconsistentNaming
public class GameTUI
{
    public string ChooseStarter()
    {
        Console.WriteLine("What pokemon would you like to use?");
        Console.WriteLine("Patrat - Tepig - Snivy - Oshawott");

        while (true)
        {
            string? input = Console.ReadLine();

            string? pokemonName = input switch
            {
                "Patrat" => "patrat",
                "Tepig" => "tepig",
                "Snivy" => "snivy",
                "Oshawott" => "oshawott",
                _ => null
            };

            if (pokemonName != null)
            {
                Console.WriteLine($"You chose {input}!");
                return pokemonName;
            }
            Console.WriteLine("Please enter a valid pokemon name.");
            Console.WriteLine("Patrat - Tepig - Snivy - Oshawott");
        
        }
    }
}