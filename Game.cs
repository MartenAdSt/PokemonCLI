using PokemonCLI;
using PokemonCLI.Models;
using PokemonCLI.Services;
using Type = PokemonCLI.Models.Type;

Console.WriteLine("Starting Pokemon CLI...");

PokemonManager pokemonManager = new ("/Users/marten/RiderProjects/PokemonCLI/data/pokemons.json");

Move tackle = new ("Tackle", "A basic normal movement", Type.Normal, 40, 100);
Move ember = new ("Ember", "A basic fire movement", Type.Fire, 40, 100);
Move waterGun = new ("Water gun", "A basic water movement", Type.Water, 40, 100);
Move vineWhip = new ("Vine whip", "A basic grass movement", Type.Grass, 40, 100);
Move tailWhip = new ("Tail whip", "Lowers the opponents defense stat", Type.Normal, 0, 100);


Pokemon tepig = new ("Tepig", Type.Fire, 0, 10, 10, 10, tackle, ember);
Pokemon patrat = new ("Patrat", Type.Normal, 0, 10, 10, 10, tackle, tailWhip);
Pokemon snivy = new ("Snivy", Type.Grass, 0, 10, 10, 10, tackle, vineWhip);
Pokemon oshawott = new ("Oshawott", Type.Water, 0, 10, 10, 10, tackle, waterGun);

pokemonManager.Add(patrat);
pokemonManager.Add(tepig);
pokemonManager.Add(snivy);
pokemonManager.Add(oshawott);

// GameTUI tui = new ();
//
// var starter = tui.ChooseStarter();



