int[] numArray = new int[10];
Random rand = new Random();

Console.WriteLine("---- Random Array ----");

for(int i = 0; i < numArray.Length; i++) 
{
    numArray[i] = rand.Next(5, 25);
}

foreach(int num in numArray) {
    Console.Write("{0} ", num);
}
Console.WriteLine("");

static int MinMaxArray(int[] numArray)
{
    int min = numArray[0];
    int max = numArray[0];
    for(int i = 0; i < numArray.Length; i++) 
    {
        if(numArray[i] > max)
        {
            max = numArray[i];
        }
        if(numArray[i] < min){
            min = numArray[i];
        }
    }
    Console.WriteLine("Our max is: " + max + "." + " || " + "Our min is: " + min + ".");
    return max;
}

MinMaxArray(numArray);


Console.WriteLine("");
Console.WriteLine("---- Sum of Array ----");


static int SumNumArray(int[] numArray)
{
    int sum = 0;
    for(int i = 0; i < numArray.Length; i++) 
    {
        sum = numArray[i] + sum;
    }
    return sum;
};

Console.WriteLine(SumNumArray(numArray));

///////////////////////////////////// coinflip

static string CoinFlip() {
    Random coinToss = new Random();
    Console.WriteLine("Tossing a coin!");
    int CoinResult = coinToss.Next(1,3);

    if(CoinResult == 1)
    {
        return("Heads!");
    }
    else
    {
        return("Tails!");
    }
}

Console.WriteLine(CoinFlip());

///////////////////////////////////// names

List<string> names = new List<string>()
{
"Todd",
"Tiffany",
"Charlie",
"Geneva",
"Sydney"
};


static List<string> FindNames(List<string> names){
List<string> LongerNames = new List<string>();
for(int i = 0; i < names.Count; i++)
{
    if(names[i].Length > 5)
    {
        LongerNames.Add(names[i]);
    }
}
    return LongerNames;
}

List<string> FoundNames = FindNames(names);
foreach(string name in FoundNames) {
    Console.Write(name + ", ");
}

