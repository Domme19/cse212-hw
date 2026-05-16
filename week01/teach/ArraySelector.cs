using System.Linq.Expressions;
using System.Runtime.CompilerServices;

public static class ArraySelector
{
    public static void Run()
    {
        var l1 = new[] { 1, 2, 3, 4, 5 };
        var l2 = new[] { 2, 4, 6, 8, 10 };
        var select = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1 };
        var intResult = ListSelector(l1, l2, select);
        Console.WriteLine("<int[]>{" + string.Join(", ", intResult) + "}"); // <int[]>{1, 2, 3, 2, 4, 4, 6, 8, 10, 5}
    }

    private static int[] ListSelector(int[] list1, int[] list2, int[] select)
    {
        // do both arrays always have the same size, I would not assume that is the case
        // So I would consider two indexes that will track both arrays
        int indexOne = 0;
        int indexTwo = 0;
        const int markerOne = 1;
        const int markerTwo = 2;

        // traverse the select list
        // if the number = 1
        //  increments index of the first list considering its size
        //  index can only increment if the if it is less than the size (index < size then increases)
        //  then add the current element at the index that the program will be\
        //  then increment

        // TODO: iterate over the loop
        var results = new List<int>();
        for (int i = 0; i < select.Length; i++)
        {
            int currentMarker = select[i];
            if (currentMarker == markerOne)
            {
                if (indexOne < list1.Length)
                {
                    results.Add(list1[indexOne]);
                    indexOne++;
                }

            }
            else if (currentMarker == markerTwo)
            {
                if (indexTwo < list2.Length)
                {
                    results.Add(list2[indexTwo]);
                    indexTwo++;
                }

            }
        }


        return results.ToArray();
    }
}