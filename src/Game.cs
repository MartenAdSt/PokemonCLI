using PokemonCLI.Data_Structures;
using Type = PokemonCLI.Data_Structures.Type;

Console.WriteLine("Starting Pokemon CLI...");

var tackle = new Move("Tackle", "A basic normal movement", Type.Normal, 40, 100);
var ember = new Move("Ember", "A basic fire movement", Type.Fire, 40, 100);
var waterGun = new Move("Water gun", "A basic water movement", Type.Water, 40, 100);
var vineWhip = new Move("Vine whip", "A basic grass movement", Type.Grass, 40, 100);
var tailWhip = new Move("Tail whip", "Lowers the opponents defense stat", Type.Normal, 0, 100);


Pokemon tepig = new Pokemon("Tepig", Type.Fire, 0, 10, 10, 10, tackle, ember);
Pokemon patrat = new Pokemon("Patrat", Type.Normal, 0, 10, 10, 10, tackle, tailWhip);
Pokemon snivy = new Pokemon("Snivy", Type.Grass, 0, 10, 10, 10, tackle, vineWhip);
Pokemon oshawott = new Pokemon("Oshawott", Type.Water, 0, 10, 10, 10, tackle, waterGun);

Console.WriteLine("What pokemon would you like to use?");
Console.WriteLine("Patrat - Tepig - Snivy - Oshawott");

TextReader input = new StreamReader(Console.OpenStandardInput());
string line;
while ((line = input.ReadLine()) != null)
{
    switch (line)
    {
        case "Patrat":
            Console.WriteLine("You chose Patrat!");
            break;
        case "Tepig":
            Console.WriteLine("You chose Tepig!");
            break;
        case "Snivy":
            Console.WriteLine("You chose Snivy!");
            break;
        case "Oshawott":
            Console.WriteLine("You chose Oshawott!");
            break;
        default:
            Console.WriteLine("Please enter a valid pokemon name.");
            Console.WriteLine("Patrat - Tepig - Snivy - Oshawott");
            break;
    }
    
}
