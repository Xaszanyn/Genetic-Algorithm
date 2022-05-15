class Cipher
{
    string cipher = "Deep Learning 2022";

    public Cipher() {}

    public int Difference(string chromosome)
    {
        int difference = 0;

        for (int i = 0; i < 18; i++)
        {
            if (chromosome[i] != cipher[i]) difference++;
        }

        return difference;
    }

    public int Length() { return cipher.Length; }
}