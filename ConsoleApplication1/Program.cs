using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string x,y;
            while (true)
            {
            Console.Write("enternumber:");
            x =Console.ReadLine();
            Regex filter = new Regex("^([a-zA-Z0-9._%-]{3,15}+@[a-zA-Z0-9.-]{3,10}/+.[a-zA-Z]{2,4})*$");
            bool acces = filter.IsMatch(x);
            Console.WriteLine(acces.ToString());
            }
            
        }
    }
}
