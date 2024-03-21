Console.Clear();
//Criar um vetor
int[] vetor = new int[100];

//Criar o objeto que vai gerar o número randomico
Random aleatorio = new Random();

//Preencher vetor com valores aleatórios
for (int i = 0; i < vetor.Length; i++)
{
    vetor[i] = aleatorio.Next(100);
}

//Imprimir vetor
for (int i = 0; i < vetor.Length; i++)
{
    Console.Write(vetor[i] + " ");
}

//Ordenar vetor
bool troca = false;
do
{
    troca = false;
    for (int i = 0; i < vetor.Length - 1; i++)
    {
        if (vetor[i] > vetor[i + 1])
        {
            int aux = vetor[i];
            vetor[i] = vetor[i + 1];
            vetor[i + 1] = aux;
            troca = true;
        }
    }
} while (troca);

Console.WriteLine("\n");

//Imprimir vetor
for (int i = 0; i < vetor.Length; i++)
{
    Console.Write(vetor[i] + " ");
}