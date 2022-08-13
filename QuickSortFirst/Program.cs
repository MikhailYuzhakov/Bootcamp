/*
отсортровать по возрастанию
1. arr = { 0, -5, 2, 3, 5, 9, -1, 7 }
2. pivot = arr[0]  (опорный элемент)
3. Вызвать шаги 1-2 для подмассива слева от pivot и справа от pivot
*/

int[] arr = {0, -5, 2, -4, 5, 9, -1, 7};
Console.Clear();
QuickSort(arr, 0, arr.Length - 1);
Console.WriteLine($"Отсортированный массив {string.Join(", ", arr)}");

//функция для быстрой сортировки
void QuickSort(int[] inputArray, int minIndex, int maxIndex)
{
    if (minIndex >= maxIndex) return;
    int pivot = GetPivotIndex(inputArray, minIndex, maxIndex); //получаем индекс опорного элемента 
    Console.WriteLine($"Pivot {pivot}");
    Console.WriteLine($"Массив {string.Join(", ", arr)}");
    QuickSort(inputArray, minIndex, pivot - 1); //сортируем левую часть массива
    QuickSort(inputArray, pivot + 1, maxIndex); //сортируем правую часть массива
    return;
}

//получаем индекс опорного элемента
static int GetPivotIndex(int[] inputArray, int minIndex, int maxIndex)
{
    int pivotIndex = maxIndex + 1; //присваиваем pivot = -1
    for (int i = maxIndex; i >= minIndex; i--) //ищем все элементы меньше опорного и ставим их слева от него
    {
        if (inputArray[i] < inputArray[minIndex]) //отвечает за порядок сортировки (по возрастанию, по убыванию)
        {
            pivotIndex--;
            Swap(inputArray, i, pivotIndex);
        }
    }
    pivotIndex--;
    Swap(inputArray, pivotIndex, minIndex);
    return pivotIndex;
}

//меняет местами элементы
static void Swap(int[] inputArray, int leftValue, int rightValue)
{
    int temp = inputArray[leftValue];
    inputArray[leftValue] = inputArray[rightValue];
    inputArray[rightValue] = temp;
}