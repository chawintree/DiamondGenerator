using DiamondKata;

var generator = new DiamondGenerator();

Console.WriteLine("Please enter a letter of the alphabet to generate your diamond:");

var key = Console.ReadKey();

if (!DiamondGenerator.Characters.Contains(Char.ToUpper(key.KeyChar)))
{
    Console.WriteLine($"{key.KeyChar} is not a valid character");
    Console.ReadKey();
    return;
}

var result = generator.Generate(key.KeyChar);

Console.WriteLine();
Console.WriteLine(result);

Console.ReadKey();