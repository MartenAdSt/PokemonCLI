using PokemonCLI;
using PokemonCLI.Models;
using PokemonCLI.Services;
using Type = PokemonCLI.Models.Type;
using PokemonCLI.UI;

Console.WriteLine("Starting Pokemon CLI...");

string pokemonsFilePath = "/Users/marten/RiderProjects/PokemonCLI/data/pokemons.json";

// PokemonManager pokemonManager = new(pokemonsFilePath);
//
// Move tackle = new ("Tackle", "A basic normal movement", Type.Normal, 40, 100);
// Move ember = new ("Ember", "A basic fire movement", Type.Fire, 40, 100);
// Move waterGun = new ("Water gun", "A basic water movement", Type.Water, 40, 100);
// Move vineWhip = new ("Vine whip", "A basic grass movement", Type.Grass, 40, 100);
// Move tailWhip = new ("Tail whip", "Lowers the opponents defense stat", Type.Normal, 0, 100);
//
//
// Pokemon tepig = new ("Tepig", Type.Fire, 0, 10, 10 ,10,10, tackle, ember);
// Pokemon patrat = new ("Patrat", Type.Normal, 0, 10, 10, 10, 10, tackle, tailWhip);
// Pokemon snivy = new ("Snivy", Type.Grass, 0, 10, 10, 10, 10, tackle, vineWhip);
// Pokemon oshawott = new ("Oshawott", Type.Water, 0, 10, 10, 10, 10, tackle, waterGun);
//
// pokemonManager.Add(patrat);
// pokemonManager.Add(tepig);
// pokemonManager.Add(snivy);
// pokemonManager.Add(oshawott);

GameTUI tui = new (pokemonsFilePath);

var starter = tui.ChooseStarter();
var enemy = tui.ChooseOpponent(starter.Name);

tui.BattleUI(starter, enemy);


