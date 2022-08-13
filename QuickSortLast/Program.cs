/*
1. arr = {1, 0, -6, 2, 5, 3, 2} 
2. pivot = arr[6]  (опорный элемент)
3. Вызвать шаги 1-2 для подмассива слева от pivot и справа от pivot
*/

int[] arr = { 0, -5, 2, 3, 5, 9, -1, 7 };
QuickSort(arr, 0, arr.Length - 1);
Console.WriteLine($"Отсортированный массив {string.Join(", ", arr)}");

//функция для быстрой сортировки
void QuickSort(int[] inputArray, int minIndex, int maxIndex)
{
    if (minIndex >= maxIndex) return;
    int pivot = GetPivotIndex(inputArray, minIndex, maxIndex); //получаем индекс опорного элемента 
    Console.WriteLine($"Массив {string.Join(", ", arr)}");
    QuickSort(inputArray, minIndex, pivot - 1); //сортируем левую часть массива
    QuickSort(inputArray, pivot + 1, maxIndex); //сортируем правую часть массива
    return;
}

//получаем индекс опорного элемента
static int GetPivotIndex(int[] inputArray, int minIndex, int maxIndex)
{
    int pivotIndex = minIndex - 1; //присваиваем pivot = -1
    for (int i = minIndex; i <= maxIndex; i++) //ищем все элементы меньше опорного и ставим их слева от него
    {
        if (inputArray[i] < inputArray[maxIndex])
        {
            pivotIndex++;
            Swap(inputArray, i, pivotIndex);
        }
    }
    pivotIndex++;
    Swap(inputArray, pivotIndex, maxIndex);
    return pivotIndex;
}

//меняет местами элементы
static void Swap(int[] inputArray, int leftValue, int rightValue)
{
    int temp = inputArray[leftValue];
    inputArray[leftValue] = inputArray[rightValue];
    inputArray[rightValue] = temp;
}