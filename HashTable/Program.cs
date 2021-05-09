using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to HashTable");
            MyMapNode<string, string> hash = new MyMapNode<string, string>(5);
            hash.Add("0", "To be or not to be");
            hash.frequencyOfWords("0");

            //Passing paragraph and finding frequency
            hash.Add("1", "Paranoids are not Paranoids because they are Paranoids but because they keep putting themselves deliberatly into paranoids avoidable situations");
            hash.frequencyOfWords("1");

            Console.ReadLine();
        }
    }
}
