namespace Human_space;

public class Ninja : Human
{
    public Ninja (string name, int strength, int intelligence, int health, int dexterity = 175) : base (name, strength, intelligence, health, dexterity)
    {
        Name = name;
        Health = health;
        Strength = strength;
        Intelligence = intelligence;
        Dexterity = dexterity;
    }

    public int NinjaAttack(Human target)
    {
        Random rand = new Random();
        int chance = rand.Next(0,6);
        if(chance == 1)
        {
            target.Health -= (Dexterity * 5);
            target.Health -= 10;
            Console.WriteLine(Name + " landed a critical hit!");
            return target.Health;
        }
        else 
        {
        target.Health -= (Dexterity * 5);
        Console.WriteLine(Name + " did " + Dexterity * 5 + " damage to " + target.Name + "!");
        Console.WriteLine("Feels bad, man.");
        return target.Health;
        }
    }

    public void Steal(Human target)
    {
        target.Health -= 5;
        Health += 5;
        Console.WriteLine(Name + " stole 5 hp from " + target.Name);
    }
}