using System;
using System.Text.Json;
class HeapSortTasks
{
    private static void Heapify(int[] arr, int heapSize, int rootIdx)
    {
        int largest = rootIdx;
        int leftChild = 2 * rootIdx + 1;
        int rightChild = 2 * rootIdx + 2;

        if (leftChild < heapSize && arr[leftChild] > arr[largest]) largest = leftChild;
        if (rightChild < heapSize && arr[rightChild] > arr[largest]) largest = rightChild;

        if (largest != rootIdx)
        {
            (arr[rootIdx], arr[largest]) = (arr[largest], arr[rootIdx]);

            Heapify(arr, heapSize, largest);
        }
    }
    public static void SortTasksByPriority(int[] tasks)
    {
        for (int i = tasks.Length / 2 - 1; i >= 0; i--)
        {
            Heapify(tasks, tasks.Length, i);
        }
        for (int i = tasks.Length - 1; i >= 0; i--)
        {
            Heapify(tasks, i, 0);
        }
    }
    public static void Main()
    {
        // Task 1
        // int[] tasks = [3, 1, 4, 2, 5];
        // SortTasksByPriority(tasks);
        // Console.WriteLine(JsonSerializer.Serialize(tasks));

        // Task 2
        long[] phoneNumbers = [9876543210L, 1234567890L, 5555555555L, 1000000000L];
        SortPhoneNumbers(phoneNumbers);
        Console.WriteLine(JsonSerializer.Serialize(phoneNumbers));
    }

    private static void CountingSort(long[] arr, int exp)
    {        
        long[] output = new long[arr.Length];
        int[] count = new int[10]; // 10 - количество разрядов в номере телефона
        for (int i = 0; i < arr.Length; i++)
        {
            int tmp = (int)(arr[i] / exp) % 10;
            count[tmp]++;
        }

        for (int i = 1; i < 10; i++)
        {
            count[i] += count[i - 1];
        }

        for(int i = arr.Length -1; i >= 0; i--)
        {
            int tmp = (int)(arr[i] / exp) % 10;
            output[count[tmp] - 1] = arr[i];
            count[tmp]--;
        }

        for( int i = 0; i < arr.Length; i++)
        {
            arr[i] = output[i];
        }
    }
    public static void SortPhoneNumbers(long[] arr)
    {
        long max = arr.Max();

        for(int exp = 1; max / exp > 0; exp *= 10)
        {
            CountingSort(arr, exp);
        }
    }
}