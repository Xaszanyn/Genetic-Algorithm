class Generation
{
    String[] chromosomes;
    int[] probabilities;
    int total;
    int pointer;
    
    public Generation(int population)
    {
        chromosomes = new string[population];
        probabilities = new int[population];
        total = 0;
        pointer = 0;
    }

    public void Add(String chromosome, int difference)
    {
        chromosomes[pointer] = chromosome;

        int probability = (int)Math.Pow((chromosome.Length - difference + 1), 2);
        probabilities[pointer] = probability;

        total += probability;

        pointer++;
    }

    public String Roulette()
    {
        Random random = new Random();
        int roulette = random.Next(0, total);

        for (int i = 0; i < probabilities.Length; i++)
        {
            roulette -= probabilities[i];

            if (roulette < 0) return chromosomes[i];
        }

        return chromosomes[chromosomes.Length - 1];
    }

    public void Display()
    {
        for (int i = 0; i < chromosomes.Length; i++)
        {
            Console.WriteLine(chromosomes[i] + " - " + probabilities[i]);
        }

        Console.WriteLine();
    }
}