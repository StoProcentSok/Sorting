using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SortingEfficiency
{
    class Program
    {//changes for git
        static void Main(string[] args)
        {
            Console.WriteLine("*****Welcome to my app for analyzing sorting methods efficiency*****\n"+
                "What would You like to do?\n"+
                "1) Create new table of shuffled data of 20 elements from 1 to 20.\n"+
                "2) Create new table of shuffled data of user chosen parameters.\n"+
                "3) Use booble sort method\n");

            
            string chosenSwitchString = Console.ReadLine();
            int chosenSwitch;
            Int32.TryParse(chosenSwitchString, out chosenSwitch);   //Try parse wont throw an exception like in case of 
            if (chosenSwitch > 0 && chosenSwitch < 4)               //convert.toInt with some kind of weird ndata like "23e" input (its user error sensitive) 
            {
                switch (chosenSwitch)
                {
                    case 1:
                        CreatingMess(20,1,20);
                        break;
                    case 2:
                        CreatingMess();
                        break;
                    case 3:
                        BubbleSort();
                        break;
                    default:
                        Console.WriteLine("The chosen imput is unknown");
                        break;
                }
            }
            else
                Console.WriteLine("Your imput is invalid.");
            
            Console.ReadLine();
        }

        static void CreatingMess(int howMany, int minValue, int maxValue)
        {
            Random randNumber = new Random();
            int[] mess = new int[howMany];
            for (int i = 0; i < howMany; i++)
            {
                mess[i] = randNumber.Next(minValue, maxValue + 1);
            }
            string path = @"D:\Csharp\Projects\Sorting efficiency\SortingEfficiency\SortingEfficiency\bin\Debug\Array.txt";
            File.Delete(path); //deleting lately generated file

            for (int i = 0; i < howMany; i++)
            {
                File.AppendAllText(path, mess[i].ToString() + " ", Encoding.UTF8);
            }
            
            Console.WriteLine("All done.");

        }
        static void CreatingMess()
        {
            Console.WriteLine("How many elements would You like to mess for further sorting?");
            string howManyString = Console.ReadLine();
            int howMany;
            Int32.TryParse(howManyString, out howMany);
            int[] mess = new int[howMany];
           
            Random randNumber = new Random();
            Console.WriteLine("Specify the smallest, non negative value of mixed set");
            string minValueString =  Console.ReadLine();
            int minValue; 
            Int32.TryParse(minValueString, out minValue);

            Console.WriteLine("Specify the largest, non negative value of mixed set");
            string maxValueString =  Console.ReadLine();
            int maxValue;
            Int32.TryParse(maxValueString, out maxValue);////defining size of array of mixed elements

            for (int i = 0; i < mess.Length; i++)
            {
                mess[i] = randNumber.Next(minValue, maxValue+1);
            }
            bool toTxt = false;
            string toTxtChosen = "To be defined by user";
            while (toTxtChosen != "y" && toTxtChosen != "n")
            {
                Console.WriteLine("Do you like to put your messed array into a txt file?\n" +
                                "y for yes \n" +
                                "n for no");
                toTxtChosen = Console.ReadLine();
                if (toTxtChosen == "y")
                {
                    toTxt = true;
                }
                else if (toTxtChosen == "n")
                {
                    toTxt = false;
                }
                else
                {
                    Console.WriteLine("Provided input is none y or n.. ");
                }
            }
            if (toTxt == true) 
            {
                string path = @"D:\Csharp\Projects\Sorting efficiency\SortingEfficiency\SortingEfficiency\bin\Debug\Array.txt";
                File.Delete(path); //deleting lately generated file
                foreach  (int element in mess)
                {
                    try
                    {
                        //File.AppendAllText(path, mess[element].ToString() + Environment.NewLine, Encoding.UTF8);
                        File.AppendAllText(path, mess[element].ToString() + " ", Encoding.UTF8);
                    }
                    catch (IOException e)
                    {
                        Console.WriteLine("Oups, we had some problem: {0}", e);
                    }
                    finally
                    {
                        //block performed if any exception was cought OR NOT
                    }
                }
                Console.WriteLine("All done.");
            }
        }
        static void BubbleSort()
        {
            string path = @"D:\Csharp\Projects\Sorting efficiency\SortingEfficiency\SortingEfficiency\bin\Debug\Array.txt";
            if (File.Exists(path))
            {
                //Reading from file, removing blank spaces between intigers and putting values into table
                string fileContent = File.ReadAllText(path);
                string[] integerStrings = fileContent.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int[] messedArray = new int[integerStrings.Length];
                for (int n = 0; n < integerStrings.Length; n++)
                    messedArray[n] = int.Parse(integerStrings[n]);
                //Writing messed table
                foreach (int element in messedArray)
                {
                    Console.Write(element + " ");
                }
                var watch = System.Diagnostics.Stopwatch.StartNew();
                //Sorting
                int buffor = 0;
                for (int i = messedArray.Length - 1; i > 0; i--)
                {
                    for (int j = messedArray.Length - 1; j > 0; j--)
                    {
                        if (messedArray[j] < messedArray[j - 1])
                        {
                            buffor = messedArray[j];
                            messedArray[j] = messedArray[j - 1];
                            messedArray[j - 1] = buffor;
                        }
                    }
                  //  i--; //<-- check if correct: after first run of j loop, oldest element have to be on its proper position, so we can run 1 less of i loops.
                }
                watch.Stop();
                var sortingTimeTicks = watch.ElapsedTicks;
                var sortingTimeMs = watch.ElapsedMilliseconds;
                //watch.ElapsedTicks
                //Writing sorted array
                Console.WriteLine("\nSorted array:\n");
                foreach (int element in messedArray)
                {
                    Console.Write(element + " ");
                }

                Console.WriteLine("\nTime elapsed: " + sortingTimeTicks +" ticks");
                Console.WriteLine("\nTime elapsed: " + sortingTimeMs + " milliseconds");
            }
            else
            {
                Console.WriteLine(@"There is no file to sort from in D:\Csharp\Projects\Sorting efficiency\SortingEfficiency\SortingEfficiency\bin\Debug\Array.txt :(");
            }
            
            Console.ReadLine();
        }
    }
}
