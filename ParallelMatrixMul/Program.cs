const int N = 1000; //размер матрицы
const int THREADS_NUMBER = 10;

int[,] serialMulRes = new int[N, N]; //результат выполнения умножения матриц в однопотоке
int[,] threadMulRes = new int[N, N]; //результат параллельного умножения матриц

int[,] firstMatrix = MatrixGenerator(N, N);
int[,] secondMatrix = MatrixGenerator(N, N);

SerialMatrixMul(firstMatrix, secondMatrix); //вычисление матрицы на одном потоке последовательно
PrepareParallelMatrixMul(firstMatrix, secondMatrix); //вычисление в многопоточном режиме параллельно
Console.WriteLine(EqualityMatrix(serialMulRes, threadMulRes)); //сравниваем рассчитанные матрицы

//генерация рандомного массива
int[,] MatrixGenerator(int rows, int columns)
{
    Random _rand = new Random();
    int[,] res = new int[rows, columns];
    for (int i = 0; i < res.GetLength(0); i++)
    {
        for (int j = 0; j < res.GetLength(1); j++)
        {
            res[i, j] = _rand.Next(-100, 100);
        }
    }
    return res;
}

//последовательное умножение двух матриц
void SerialMatrixMul(int[,] a, int[,] b)
{
    if (a.GetLength(1) != b.GetLength(0)) throw new Exception("Нельзя умножить такие матрицы");

    for (int i = 0; i < a.GetLength(0); i++)
    {
        for (int j = 0; j < b.GetLength(1); j++)
        {
            for (int k = 0; k < b.GetLength(0); k++)
            {
                serialMulRes[i, j] += a[i, k] * b[k, j];
            }
        }
    }
}

//параллельное умножение матриц
void PrepareParallelMatrixMul(int[,] a, int[,] b)
{
    if (a.GetLength(1) != b.GetLength(0)) throw new Exception("Нельзя умножить такие матрицы"); //завершаем программу, если размеры матриц не равны
    int eachThreadCalc = N / THREADS_NUMBER; //вычисляем объем работы для каждого потока (на последний поток приходится остаток)
    Thread[] arr = new Thread[2];
    var threadsList = new List<Thread>(); //объявляем потоки

    for (int i = 0; i < THREADS_NUMBER; i++)
    {
        int startPos = i * eachThreadCalc; //разбиваем задачи по потокам (распараллеливаем умножение)
        int endPos = (i + 1) * eachThreadCalc;
        //если последний поток
        if (i == THREADS_NUMBER - 1) endPos = N; //на последний поток кидаем остаток задач
        threadsList.Add(new Thread(() => ParallelMatrixMul(a, b, startPos, endPos))); //создаем поток и в качестве аругмента отдаем функцию
        threadsList[i].Start(); //запускаем поток (на запуск потока тоже требуется время)
    }

    //ждем пока все запущенные потоки объединятся с основным потоком (типо задержка)
    for (int i = 0; i < THREADS_NUMBER; i++)
    {
        threadsList[i].Join();
    }
}

//параллельное умножение двух матриц
void ParallelMatrixMul(int[,] a, int[,] b, int startPos, int endPos)
{
    for (int i = startPos; i < endPos; i++)
    {
        for (int j = 0; j < b.GetLength(1); j++)
        {
            for (int k = 0; k < b.GetLength(0); k++)
            {
                threadMulRes[i, j] += a[i, k] * b[k, j];
            }
        }
    }
}

//сравнение двух матриц
bool EqualityMatrix(int[,] fmatrix, int[,] smatrix)
{
    bool res = true;

    for (int i = 0; i < fmatrix.GetLength(0); i++)
    {
        for (int j = 0; j < fmatrix.GetLength(1); j++)
        {
            res = res && (fmatrix[i, j] == smatrix[i, j]);
        }
    }

    return res;
}



