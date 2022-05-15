Genetic genetic = new Genetic(new Cipher());

Console.WriteLine("Press any key to initialize the genetic search.");
Console.ReadLine();

genetic.Find(400, 3);

Console.WriteLine("Population: 400 , Mutation Percentage: 3%");
Console.ReadLine();

genetic.Find(300, 3);

Console.WriteLine("Population: 300 , Mutation Percentage: 3%");
Console.ReadLine();

genetic.Find(200, 3);

Console.WriteLine("Population: 200 , Mutation Percentage: 3%");
Console.ReadLine();