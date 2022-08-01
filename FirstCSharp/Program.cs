//FOR Print 100
for (int i = 1; i <= 255; i++)
{
    Console.WriteLine(i);
}


//FOR Divisibles
for (int i = 1; i <= 100; i++)
{
    if(i % 3 == 0 || i % 5 == 0)
    {
        Console.WriteLine(i);
    }
}

//FOR FizzBuzz
for (int i = 1; i <= 100; i++)
{
    if(i % 3 == 0 && i % 5 == 0)
    {
        Console.WriteLine("FizzBuzz");
    }
    else if(i % 3 == 0)
    {
        Console.WriteLine("Fizz");
    }
    else if(i % 5 == 0)
    {
        Console.WriteLine("Buzz");
    }
}


//WHILE FizzBuzz
int i = 0;
while(i <= 100)
{
    i = i + 1;

    if(i % 3 == 0 && i % 5 == 0)
    {
        Console.WriteLine("FizzBuzz");
    }
    else if(i % 3 == 0)
    {
        Console.WriteLine("Fizz");
    }
    else if(i % 5 == 0)
    {
        Console.WriteLine("Buzz");
    }
}