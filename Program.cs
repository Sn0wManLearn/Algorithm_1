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
        int[] tasks = [3, 1, 4, 2, 5];
        SortTasksByPriority(tasks);
        Console.WriteLine(JsonSerializer.Serialize(tasks));
    }
}