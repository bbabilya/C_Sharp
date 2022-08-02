namespace Human_space;

class Human
{
    // Properties for Human
    public string Name;
    public int Strength;
    public int Intelligence;
    public int Dexterity;
    public int Health;

    public Human(string name)
    {
        Name = name;
        Strength = 3;
        Intelligence = 3;
        Dexterity = 3;
        Health = 100;
    }

    public Human(string name, int strength, int intelligence, int dexterity, int health)
    {
        Name = name;
        Strength = strength;
        Intelligence = intelligence;
        Dexterity = dexterity;
        Health = health;
    }
    // Add a constructor that takes a value to set Name, and set the remaining fields to default values
    // Add a constructor to assign custom values to all fields
    // Build Attack method
    public int Attack(Human target)
    {
        target.Health -= (this.Strength * 5);
        Console.WriteLine(this.Name + " did " + this.Strength * 5 + " damage to " + target.Name + "!");
        Console.WriteLine("Feels bad, man.");
        return target.Health;
    }

    public void Heal()
    {
        this.Health += 20;
        Console.WriteLine(this.Name + " drank a health potion!");
        Console.WriteLine(this.Name + " now has " + this.Health + " hp remaining!");
    }
}

