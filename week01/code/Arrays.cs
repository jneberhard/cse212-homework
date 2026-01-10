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
        // Create array to store the multiples
        double[] multiples = new double[length];

        // loop from 0 to length - 1
        for (int i = 0; i < length; i++)
        {
            // multiply number by the iteration number + 1 (so it doesn't multiply by zero)
            multiples[i] = number * (i + 1);
        }
        // return the array of multiples
        return multiples;
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
        //How many items are in the list
        int items = data.Count;

        //determine the split point by subtracting the amount from the total number if items. Copy those items to a new list called rotated
        List<int> rotated = data.GetRange(items - amount, amount);

        //remove the last items from the list starting at the split point and going to the end of the list .
        data.RemoveRange(items - amount, amount);

        //make a new list to hold the rotated values by taking the "rotated" list and putting it at the front of the new list at index 0.
        data.InsertRange(0, rotated);

        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
    }
}
