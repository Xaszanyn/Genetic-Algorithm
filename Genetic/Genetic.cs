using System.Diagnostics;

class Genetic
{
    static string letters = "abcdefghijklmnopqrstuvwxyz ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    Random random;

    Cipher cipher;
    int length;

    public Genetic(Cipher cipher)
    {
        this.cipher = cipher;
        random = new Random();
        length = cipher.Length();
    }

    public string Find(int population, float mutationPercentage, int generationLimit = int.MaxValue)
    {
        if (population % 2 == 1)
        {
            Console.WriteLine("Population must be an even number.");
            return "-";
        }

        Stopwatch timer = new Stopwatch();
        timer.Start();

        Generation generation = CreateFirstGeneration();
        String best = "";
        int bestValue = length;

        while (true)
        {
            generationLimit--; if (generationLimit <= 0) break;

            //generation.Display();

            Generation newGeneration = new Generation(population);

            for (int i = 0; i < population; i += 2)
            {
                String first = generation.Roulette();
                String second = generation.Roulette();

                String firstChromosome = first.Substring(0, length / 2);
                String secondChromosome = second.Substring(0, length / 2);

                firstChromosome += second.Substring(length / 2, length / 2);
                secondChromosome += first.Substring(length / 2, length / 2);

                for (int j = 0; j < length; j++)
                {
                    if (random.Next(0, 100) < mutationPercentage) firstChromosome = firstChromosome.Substring(0, j) + RandomLetter() + firstChromosome.Substring(j + 1);
                    if (random.Next(0, 100) < mutationPercentage) secondChromosome = secondChromosome.Substring(0, j) + RandomLetter() + secondChromosome.Substring(j + 1);
                }

                int firstValue = cipher.Difference(firstChromosome);
                int secondValue = cipher.Difference(secondChromosome);

                newGeneration.Add(firstChromosome, firstValue);
                newGeneration.Add(secondChromosome, secondValue);

                if (firstValue < bestValue)
                {
                    bestValue = firstValue;
                    best = firstChromosome;
                }
                if (secondValue < bestValue)
                {
                    bestValue = secondValue;
                    best = secondChromosome;
                }
            }

            generation = newGeneration;

            Console.WriteLine(best + " | " + bestValue);

            if (bestValue == 0) break;
        }

        timer.Stop();

        Console.WriteLine("\nElapsed Time (ms): " + timer.ElapsedMilliseconds);

        return "";

        Generation CreateFirstGeneration()
        {
            Generation generation = new Generation(population);

            for (int i = 0; i < population; i++)
            {
                String chromosome = "";

                for (int j = 0; j < length; j++)
                {
                    chromosome += RandomLetter();
                }

                generation.Add(chromosome, cipher.Difference(chromosome));
            }

            return generation;
        }

        char RandomLetter()
        {
            return letters[random.Next(0, letters.Length)];
        }
    }
}