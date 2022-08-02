using Human_space;

Human alex = new Human("Alex Miller");
Human martha = new Human("Martha Smith", 5, 5, 5, 150);

Console.WriteLine(martha.Attack(alex));
alex.Heal();
