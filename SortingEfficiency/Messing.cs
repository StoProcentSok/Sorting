using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingEfficiency
{/// <summary>
/// Creating defined array of random numbers and deciding whether to put it into text file.
/// </summary>
    public class Messing
    {
        #region Public properties
        /// <summary>
        /// Ammount of integer variables to mix
        /// </summary>
        public int ValuesAmount { get; set; }
        
        /// <summary>
        ///Lowest value of messed variables
        /// </summary>
        public int MinimalValue { get; set; }
       
        /// <summary>
        /// Highest value of messed variables 
        /// </summary>
        public int MaximumValue { get; set; }
        #endregion
        #region .ctor
        /// <summary>
        /// Default constructor
        /// </summary>
        public Messing()
        {
            this.ValuesAmount = 100;
            this.MinimalValue = 1;
            this.MaximumValue = 100;    
        }
        #endregion
        #region Public methods
        /// <summary>
        /// Method creating array of size ValuesAmount of integers between MinmalValue and MaximumValue and writes it into text file.
        /// </summary>
        /// <param name="ValuesAmount"></param>
        /// <param name="MinimalValue"></param>
        /// <param name="MaximumValue"></param>
        public void CreatingMess(int ValuesAmount, int MinimalValue, int MaximumValue)
        {
            Random randNumber = new Random();
            int[] mess = new int[ValuesAmount];
            for (int i = 0; i < ValuesAmount; i++)
            {
                mess[i] = randNumber.Next(MinimalValue, MaximumValue + 1);
            }
            string path = @"D:\Csharp\Projects\Sorting efficiency\SortingEfficiency\SortingEfficiency\bin\Debug\Array.txt";
            File.Delete(path); //deleting lately generated file

            for (int i = 0; i < ValuesAmount; i++)
            {
                File.AppendAllText(path, mess[i].ToString() + " ", Encoding.UTF8);
            }
            Console.WriteLine("All done.");
        }
        #endregion
    }
}
