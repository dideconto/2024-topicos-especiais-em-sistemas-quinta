namespace Exe06B;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        int[] vetor = new int[100];
        Random aleatorio = new Random();
        for (int i = 0; i < vetor.Length; i++)
        {
            vetor[i] = aleatorio.Next(100);
        }
        for (int i = 0; i < vetor.Length; i++)
        {
            Console.Write(vetor[i] + " ");
        }
        //Ordenação com alguma funcionalidade da linguagem
        Array.Sort(vetor);

        Console.WriteLine("\n");
        for (int i = 0; i < vetor.Length; i++)
        {
            Console.Write(vetor[i] + " ");
        }
    }
    
}
