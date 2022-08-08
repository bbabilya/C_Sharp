List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46,"Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};

// Example Query - Prints all Stratovolcano eruptions
// IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
// PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
// Execute Assignment Tasks here!
Console.WriteLine("------------------------------");
Eruption ChileEruption1 = eruptions.Where(c => c.Location == "Chile").First();
Console.WriteLine("First Eruption in Chile");
Console.WriteLine(ChileEruption1);
Console.WriteLine("------------------------------");
try
{
    Eruption HawaiianIsland = eruptions.Where(c => c.Location == "Hawaiian Is").First();
    Console.WriteLine(HawaiianIsland);
}
catch
{
    Console.WriteLine("None found.");
}
Console.WriteLine("------------------------------");
try
{
    Eruption NewZealand1900 = eruptions.Where(c => c.Location == "New Zealand" && c.Year > 1900).First();
    Console.WriteLine(NewZealand1900);
}
catch
{
    Console.WriteLine("None found.");
}
Console.WriteLine("------------------------------");
try
{
    IEnumerable<Eruption> VolcanoElev2000 = eruptions.Where(c => c.ElevationInMeters > 2000);
    PrintEach(VolcanoElev2000, "Stratovolcano eruptions over 2000m.");
}
catch
{
    Console.WriteLine("None found.");
}
Console.WriteLine("------------------------------");

IEnumerable<Eruption> VolcanoZ = eruptions.Where(c => c.Volcano.StartsWith("Z"));
int count = VolcanoZ.Count();
PrintEach(VolcanoZ, $"There is a total of {count} starting with Z.");
Console.WriteLine("------------------------------");

int MaxElev = eruptions.Max(c => c.ElevationInMeters);
Console.WriteLine(MaxElev + " is the highest elevation.");
Console.WriteLine("------------------------------");

Eruption MaxElevName = eruptions.Where(c => c.ElevationInMeters == MaxElev).First();
Console.WriteLine(MaxElevName.Volcano + " is the name of the Volcano with an elevation of " + MaxElev + ".");
Console.WriteLine("------------------------------");

IEnumerable<Eruption> AllVolcanoes = eruptions.OrderBy(c => c.Volcano);
PrintEach(AllVolcanoes);
Console.WriteLine("------------------------------");

IEnumerable<Eruption> AlphabetizeVolcano = eruptions.Where(c => c.Year < 1000).OrderBy(c => c.Volcano);
PrintEach(AlphabetizeVolcano);
Console.WriteLine("------------------------------");


// Helper method to print each item in a List or IEnumerable.This should remain at the bottom of your class!
static void PrintEach(IEnumerable<dynamic> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (var item in items)
    {
        Console.WriteLine(item.ToString());
    }
}
