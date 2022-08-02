int[] numarray;
//generating empty int array
numarray = new int[] {1,2,3,4,5,6,7,8,9};
//generating values for new int array

foreach(var num in numarray)
//loop through the array with a for each
{
    Console.WriteLine(num);
}

string[] namearray;
namearray = new string[] {"Tim", "Martin", "Nikki", "Sara"};

foreach(var name in namearray)
//loop through the array with a for each
{
Console.WriteLine(name);
}

Boolean[] BoolArray = new Boolean[10];
//define an array of booleans only with a length of 10
int i = 0;
while( i < BoolArray.Length)
//declare while loop to loop through the length
{
    if(i % 2 == 0)
    //is this even? do this:
    {
        Console.WriteLine("true");
        i = i + 1;
    }
    else
    //is this !even? do this:
    {
        Console.WriteLine("false");
        i = i+1;
    }
}

List<string> icecream = new List<string>();
//generate empty list of strings called icecream.

icecream.Add("Mint Chocolate Chip");
icecream.Add("Rocky Road");
icecream.Add("Butter Pecan");
icecream.Add("Triple Chocolate");
icecream.Add("Pistachio");
icecream.Add("Strawberry");
icecream.Add("Cookies n' Creme");
icecream.Add("Cheesecake");
icecream.Add("Cookie Dough");
icecream.Add("Coffee");
//adding to our empty list


Console.WriteLine(icecream.Count);
//counting all entries
Console.WriteLine(icecream[2]);
//at index 2, 3rd Flavoror
icecream.RemoveAt(2);
//removing at index position
Console.WriteLine(icecream.Count);
//confirming remove

Random rand = new Random();
int Flavor = icecream.Count;


Dictionary<string, string> profile = new Dictionary<string, string>();
//declaring an empty dictionary full of strings called profile. 

profile.Add(namearray[0], icecream[rand.Next(0, Flavor)]);
profile.Add(namearray[1], icecream[rand.Next(0, Flavor)]);
profile.Add(namearray[2], icecream[rand.Next(0, Flavor)]);
profile.Add(namearray[3], icecream[rand.Next(0, Flavor)]);


foreach(KeyValuePair<string,string> entry in profile)
{
    Console.WriteLine(entry.Key + " - " + entry.Value);
}




