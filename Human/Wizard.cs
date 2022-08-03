namespace Human_space;

public class Wizard : Human
{
    public Wizard (string name, int strength, int dexterity, int health = 50, int intelligence = 25) : base (name, strength, dexterity, health, intelligence)
    {
        Name = name;
        Health = health;
        Strength = strength;
        Intelligence = intelligence;
        Dexterity = dexterity;
    }

    public int WizardAttack(Human target)
    {
        target.Health -= (Intelligence * 5);
        Health = (Health += (Intelligence * 5));
        Console.WriteLine(Name + " did " + Intelligence * 5 + " damage to " + target.Name + "!");
        Console.WriteLine("Feels bad, man.");
        return target.Health;
    }

    public void Heal(Human target)
    {
        target.Health += (Intelligence * 10);
        Console.WriteLine(Name + " healed " + target.Name + " for " + Intelligence * 10 + "hp!");
    }
}