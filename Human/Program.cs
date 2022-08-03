using Human_space;

Human alex = new Human("Alex Miller");
Human martha = new Human("Martha Smith", 5,5,5,10);
Samurai dateMasamune = new Samurai("Date Masamune", 5,5,5);
Wizard merlin = new Wizard("Merlin", 5,5);
Ninja kotaro = new Ninja("Kotaro Fuuma", 5,5,100);


Console.WriteLine("---- 尋常に勝負!!  (￣^￣ﾒ) ----");
dateMasamune.SamuraiAttack(martha);
Console.WriteLine("---- 尋常に勝負!! (￣^￣ﾒ) ----");
kotaro.NinjaAttack(merlin);
Console.WriteLine("---- 尋常に勝負!! (￣^￣ﾒ) ----");
merlin.WizardAttack(dateMasamune);
Console.WriteLine("---- 尋常に勝負!! (￣^￣ﾒ) ----");
alex.Attack(martha);

