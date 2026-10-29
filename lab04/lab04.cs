using System;

int[] data = { 42, 8, 60, 19, 3, 55, 12, 31, 68, 24, 49, 37, 71, 5, 27 };
int[] sortedData = (int[])data.Clone();
Array.Sort(sortedData);

int comparisons = 0;

int linearSearch(int[] items, int target)
{
    for (int i = 0; i < items.Length; i++)
    {
        comparisons++;
        if (items[i] == target)
            return i;
    }
    return -1;
}