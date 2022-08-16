//сортировка подсчетом (заводим второй массив и считаем сколько раз встречается в массиве каждая цифра)

int[] array = {-10, -5, -9, 0, 2, 5, 1, 3, 1, 0, 1}; //исходный массив
int[] sortedArray = CountingSortExtended(array); //сортировка расширенного массива

//CountingSort(array); //сортировка только массива цифр

Console.WriteLine(string.Join(", ", sortedArray)); //вывод массива

//классический метод сортировки подсчетом (только цифры)
void CountingSort(int[] inputArray)
{
    int[] counters = new int[10]; //массив повторений

    //записываем в кол-во повторений цифр соответствующих индексу массива повторений
    for (int i = 0; i < inputArray.Length; i++)
        counters[inputArray[i]]++;

    //создаем новый массив (отсортированный)
    int index = 0;
    for (int i = 0; i < counters.Length; i++) //проходим по всем элементам массива повторений
    {
        for (int j = 0; j < counters[i]; j++) //добавляем в отсортированный массив столько элементов сколько указано в ячейке 
        {
            inputArray[index] = i;
            index++;
        }
    }
}

//если элементов больше 9, т.е. массив чисел
int[] CountingSortExtended(int[] inputArray)
{
    int max = inputArray.Max();
    int min = inputArray.Min();

    int offset = -min; //вводим сдвиг массива (при наличии отрицательных чисел или при необходимости уменьшить массив повторов в случае если минимальный элемент больше 0)
    int[] sortedArray = new int[inputArray.Length]; //инициализируем отсортированный массив
    int[] counters = new int[max + offset + 1]; //инициализируем массив повторений с учетом сдвига


    //заполняем массив повторений
    for (int i = 0; i < inputArray.Length; i++)
    {
        counters[inputArray[i] + offset]++;
    }

    //создаем отсортированный массив
    int index = 0;
    for (int i = 0; i < counters.Length; i++)
    {
        for (int j = 0; j < counters[i]; j++)
        {
            sortedArray[index] = i - offset;
            index++;
        }
    }

    return sortedArray;
}