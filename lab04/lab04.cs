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

int binarySearch(int[] items, int target)
{
    int lo = 0;
    int hi = items.Length - 1;
    while (lo <= hi)
    {
        int mid = (lo + hi) / 2;
        comparisons++;
        if (items[mid] == target)
            return mid;
        if (items[mid] < target)
            lo = mid + 1;
        else
            hi = mid - 1;
    }
    return -1;
}

void report(string name, int[] items, int target)
{
    comparisons = 0;
    int index = name == "linear" ? linearSearch(items, target) : binarySearch(items, target);
    Console.WriteLine($"{name}: target={target}, index={index}, comparisons={comparisons}");
}

var cases = new (string title, int[] items, int target)[]
{
    ("1. First", sortedData, 3),
    ("2. Last", sortedData, 71),
    ("3. Middle", sortedData, 31),
    ("4. Missing, smaller than all", sortedData, 1),
    ("5. Missing, larger than all", sortedData, 99),
    ("6. Missing, between neighbours", sortedData, 50),
    ("7. Single element", new[] { 42 }, 42),
    ("8. Empty array", new int[0], 42)
};

foreach (var c in cases)
{
    Console.WriteLine(c.title);
    report("linear", c.items, c.target);
    report("binary", c.items, c.target);
    Console.WriteLine();
}

Console.WriteLine("Experiment: unsorted data");
foreach (int target in data)
{
    report("linear", data, target);
    report("binary", data, target);
}