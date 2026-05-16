using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization.Formatters;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // I noticed that when we run a multiplication table there is a pattern that emerges
        // for example: 3 * 1 = 3, 3 * 2 = 6, 3 * 3 = 9 which led me to understand that it is basically the same as
        // 3 *(0 + 1) = 3, 3 *(1 + 1) = 6, 3 *(2 + 1) = 9,  3 *(3 + 1) = 12, the left side number in the parenthesis is increasing by 1 and we add to one
        // the computer formula is: startingNumber *  (index + 1)
        // index of the loop 
        // 1. run a loop over the number of multiples that we need which is the length: 
        // Create an empty list that will contain all the multiples
        // iterate over the length while calculating the multiple using the formula multiple = startingNumber * (index + 1)
        // add it to the list
        // and return the list after the loop finishes running

        var multiples = new List<double>();
        for (int i = 0; i < length; i++)
        {
            double multiple = number * (i + 1);
            multiples.Add(multiple); 

        }


        return multiples.ToArray();
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.


        // when I look at it clearly
        // a rotated array is just an array split by the length of the array - shiftAmount
        // Meaning the if we have 9 elements and the shift amount is 5 then the split point is: 9 - 5 = 4
        // so the elements starting at the split point to the last index of the array will be in front of the new rotated array
        // and the ones on the left side of the split point will be on the back of the rotated array.
        // so elements from 0 to split point - 1: 0 - 3(back of the rotated array)
        // elements from split point to length - 1: 4 - 8 (front of the rotated array)

        // handling edge cases
        if (data == null || data.Count <= 1 || amount == data.Count)
        {
            return;
        }

        var rotatedList = new List<int>();
        int splitPoint = data.Count - amount;

        // fill the front of the rotated List
        for (int i = splitPoint; i < data.Count; i++)
        {
            int element = data[i];
            rotatedList.Add(element);
        }

        // fill the back of the rotatedList
        for (int i = 0; i < splitPoint; i++)
        {
            int element = data[i];
            rotatedList.Add(element); 
        }


        // copy the elements to the original numbers
        for (int i = 0; i < rotatedList.Count; i++)
        {
            data[i] = rotatedList[i]; 
        }
    }
}
