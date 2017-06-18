using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingEfficiency
{/// <summary>
/// Class containing sorting methods.
/// </summary>
    class Sorters
    {

        public void BubbleSort()
        {
            string path = @"D:\Csharp\Projects\Sorting efficiency\SortingEfficiency\SortingEfficiency\bin\Debug\Array.txt";
            if (File.Exists(path))
            {
                //Reading from file   
                string fileContent = File.ReadAllText(path);
                //removing blank spaces between intigers
                string[] integerStrings = fileContent.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                //putting values into table
                int[] messedArray = new int[integerStrings.Length];
                for (int n = 0; n < integerStrings.Length; n++)
                    messedArray[n] = int.Parse(integerStrings[n]);
                //Writing messed table out
                foreach (int element in messedArray)
                {
                    Console.Write(element + " ");
                }
                //Starting time measurement of execution of sorting algorithm
                var watch = System.Diagnostics.Stopwatch.StartNew();
                //Sorting
                int exchangeBuffor = 0;
                for (int i = messedArray.Length - 1; i > 0; i--)
                {
                    for (int j = messedArray.Length - 1; j > 0; j--)
                    {
                        if (messedArray[j] < messedArray[j - 1])
                        {
                            exchangeBuffor = messedArray[j];
                            messedArray[j] = messedArray[j - 1];
                            messedArray[j - 1] = exchangeBuffor;
                        }
                    }
                    i--; //After each i run at least one element is on its proper place (moved one), so in next i run there is one j run less necessary to perform.
                }
                //Stopping execution time measurement nad displaying time elapsed
                watch.Stop();
                var sortingTimeTicks = watch.ElapsedTicks;
                var sortingTimeMs = watch.ElapsedMilliseconds;
                
                //Writing sorted array
                Console.WriteLine("\nSorted array:\n");
                foreach (int element in messedArray)
                {
                    Console.Write(element + " ");
                }

                Console.WriteLine("\nTime elapsed: " + sortingTimeTicks + " ticks");
                Console.WriteLine("\nTime elapsed: " + sortingTimeMs + " milliseconds");
            }
            //else statement for occurance when there is no file with messed data
            else
            {
                Console.WriteLine(@"There is no file to sort from in D:\Csharp\Projects\Sorting efficiency\SortingEfficiency\SortingEfficiency\bin\Debug\Array.txt :(");
            }

            Console.ReadLine();
        }
    }
}
