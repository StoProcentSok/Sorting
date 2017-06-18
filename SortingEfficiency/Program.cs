using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SortingEfficiency
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****Welcome in my app for analyzing sorting methods efficiency*****\n"+
                             "What would You like to do?\n"+
                             "1) Create new table of shuffled data of 100 elements from 1 to 100.\n"+
                             "2) Use booble sort method\n");
            string chosenSwitchString = Console.ReadLine();
            int chosenSwitch;
            Int32.TryParse(chosenSwitchString, out chosenSwitch);   //Try parse wont throw an exception like in case of 
            if (chosenSwitch > 0 && chosenSwitch < 3)               //convert.toInt with some kind of weird ndata like "23e" input (its user error sensitive) 
            {
                switch (chosenSwitch)
                {
                    case 1:
                        var messing = new Messing();
                        messing.CreatingMess(100, 1, 20);
                        break;
                    case 2:
                        var sorters = new Sorters();
                        sorters.BubbleSort();
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

        /*
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
        */
       
    }
}
