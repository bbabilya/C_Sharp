namespace Human_space;

public class Samurai : Human
{
    public Samurai (string name, int strength, int intelligence, int dexterity, int health = 200) : base (name, strength, intelligence, dexterity, health)
    {
        Health = health;
        Strength = strength;
        Intelligence = intelligence;
        Dexterity = dexterity;
    }

    public void SamuraiAttack(Human target)
    {
        int remainingHealth = Attack(target);
        if(remainingHealth <= 50)
        {
            target.Health = 0;
            Console.WriteLine("Ya' dead.");
        }
    }

    public void Meditate()
    {
        Health = 200;
        Console.WriteLine("Nerf please.");
    }
}