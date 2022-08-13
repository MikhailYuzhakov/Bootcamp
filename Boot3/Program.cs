int n = Convert.ToInt32(Console.ReadLine());
int [, ] matrix = new int[n,n];

for (int i = 0; i < n; i++) 
{
    for (int j = i; j < n; j++)
    {
            matrix[i,j] = (i + 1) * (j + 1);
            matrix[j,i] = (j + 1) * (i + 1);
    }
}

for (int i = 0; i < n; i++) 
{
    for (int j = 0; j < n; j++)
    {
        Console.Write(matrix[i,j]);
        Console.Write("\t");
    }
    Console.WriteLine();
}

// было со стандартным перемножением скорость алгоритма O(n^2)
// стало с модифицированным алгоритмом скорость O(n^2 / 2)



