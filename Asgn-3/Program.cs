using System;
using System.Collections.Generic;

namespace COMP10066_Lab3
{
    /**
     * Library of statistical functions using Generics for different statistical
     * calculations.
     * 
     * see http://www.calculator.net/standard-deviation-calculator.html
     * for sample standard deviation calculations
     *
     * @author Armita Aghayarsis
     */

    /*
     *      C# Style Guide
     * douse camelCasing for local variables and method arguments.
     * avoidusing Abbreviations. Exceptions: abbreviations commonly used as names, such as Id, Xml, Ftp, Uri
     * douse predefined type names instead of system type names like Int16, Single, UInt64, etc
     * douse noun or noun phrases to name a class.
     * doname source files according to their main classes. Exception: file names with partial classes
          reflect their source or purpose, e.g. designer, generated, etc.
     */


    public class Lab3
    {
        /// <summary>
        /// this is a method to calculate sum of numbers inside the array
        /// 
        /// this method is very simple, what it does is: if the count of numbers insode the list is less than 0
        /// then i will throw an exception in order to the program not crash.
        /// then it will set a double value of 0.0 in a variable called sum and it will loop through the list
        /// so for each double value in the list of numbers if the boolean flag is true and the double value is
        /// 0 or more than 0 then the sum will be incremented with value. when the loop is over then the method
        /// will return the sum.
        /// </summary>
        /// <param name="number">each number inside the array, double parameter</param>
        /// <param name="incneg">it's a boolean paramieter used in if statement</param>
        /// <returns>returns double sum</returns>
        public static double Sum(List<double> number, bool incneg)
        {
            if (number.Count < 0)
            {
                throw new ArgumentException("number field cannot be empty");
            }

            double sum = 0.0;
            foreach (double value in number)
            {
                if (incneg || value >= 0)
                {
                    sum += value;
                }
            }
            return sum;
        }
        /// <summary>
        /// this is a method that will calculate the average of the numbers inside the array.
        /// 
        /// this method is using the sum method and stored it in double sum variable. set the count to 0
        /// and start to looping through the list. if the boolean value is true and the number at position i
        /// is 0 or more, then the count will increase and go through the loop again. meanwhile, if the count is
        /// 0 which means theres no number inside the list, then it will throw an exception to prevent the program
        /// to crash. at the end, the method will return the value of sum devided by the count of numbers inside the 
        /// list.
        /// </summary>
        /// <param name="number">the numbes inside the array, double parameter</param>
        /// <param name="numbersNotNegative"></param>
        /// <returns>return the double value of average of the numbers inside the list</returns>
        public static double Average(List<double> number, bool numbersNotNegative)
        {
            double sum = Sum(number, numbersNotNegative);
            int count = 0;
            for (int i = 0; i < number.Count; i++)
            {
                if (numbersNotNegative || number[i] >= 0)
                {
                    count++;
                }
            }
            if (count == 0)
            {
                throw new ArgumentException("no values are > 0");
            }
            return sum / count;
        }
        /// <summary>
        /// this method will calculate the median of the array.
        /// this method checks if the count of numbers inside the list is more than 0, then if there
        /// is no number in the list it will throw an exception. after that, it will sort the numbers inside the list
        /// after that, there is a variable called median that will store the value of the position of the number that is
        /// in the middle of the new sorted list, then it will check if the count of numbers is even, then if so, it will 
        /// count the median in a diferent way, which is it will add the 2 numbers that are in the middle of the list, then
        /// will divide the addition in to 2.
        /// at the end of the method, it will return the value of the calculated median.
        /// </summary>
        /// <param name="number">numbers from array</param>
        /// <returns>returns the double value of the median of the array</returns>
        public static double Median(List<double> number)
        {
            if (number.Count == 0)
            {
                throw new ArgumentException("Size of array must be greater than 0");
            }

            number.Sort();

            double median = number[number.Count / 2];
            if (number.Count % 2 == 0)
                median = (number[number.Count / 2] + number[number.Count / 2 - 1]) / 2;

            return median;
        }
        /// <summary>
        /// this is a method to calculate the standar deviation of the list of numbers.
        /// in this methos, if the count of nubers is 1 or less, it will throw an exception. then it will store the
        /// value of count of numbers in numberOfValues, sets the sigma to 0, and uses the Average method to calculate 
        /// the average and store the result in average the variable. then it will run a for loop to go through the list,
        /// it will store the number at position i inside the value the variable and then increaments the sigma every time
        /// with the submission of value and average and divide by 2. after the list is finished, it will use a math methid to
        /// return the square root of the sigma divided by count of numbers minus 1. at the nend of this method, it will 
        /// return the double value of the standard deviation of the list.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static double StandardDeviation(List<double> number)
        {
            if (number.Count <= 1)
            {
                throw new ArgumentException("Size of array must be greater than 1");
            }

            int numberOfValues = number.Count;
            double sigma = 0;
            double average = Average(number, true);

            for (int i = 0; i < numberOfValues; i++)
            {
                double value = number[i];
                sigma += Math.Pow(value - average, 2);
            }
            double standardDeviation = Math.Sqrt(sigma / (numberOfValues - 1));
            return standardDeviation;
        }


        /// <summary>
        /// this is the main method that will compile and show the result base on the above methods.
        /// </summary>
        /// <param name="args">there is no arguments inserted into this method</param>
        static void Main(string[] args)
        {
            // Simple set of tests that confirm that functions operate correctly
            List<double> testList = new List<double> { 2.2, 3.3, 66.2, 17.5, 30.2, 31.1 };

            //this console write line will show the resault of all of the above methods
            Console.WriteLine($"The sum of the array = { Sum(testList, true)}\n" +
                              $"The average of the array = {Average(testList, true)}\n" +
                              $"The median value of the Double number set = { Median(testList)}\n" +
                              $"The sample standard deviation of the Double test set = {StandardDeviation(testList)}\n" +
                              $"number of values: {testList.Count}");
        }
    }
}
