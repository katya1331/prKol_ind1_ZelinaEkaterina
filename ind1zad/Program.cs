using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.IO.File;


namespace ind1zad
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            string [] sr = ReadAllLines("n.txt");
            int[] numb = new int[sr.Length];
            for (int i=0;i<sr.Length;i++)
            {
                numb[i] = Convert.ToInt32(sr[i]);
            }
            numb.Reverse();
            Stack<int> numbers = new Stack<int>(numb);
            foreach(int num in numbers)
            {
               AppendAllText("n2.txt", Convert.ToString(num+"\n"));
            }
            ReadKey();
        }
    }
}
