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
            Console.WriteLine("============Welcome To Hash Table Program=================");
            MyMapNode<string, string> hash = new MyMapNode<string, string>(5);
            hash.Add("0", "To be or not to be");
            hash.frequencyOfWords("0");

            //Passing paragraph and finding frequency
            hash.Add("1", "Paranoids are not Paranoids because they are Paranoids but because they keep putting themselves deliberatly into paranoids avoidable situations");
            hash.frequencyOfWords("1");

            //Delete word from paragraph.
            string para = "Paranoids are not paranoid because they are paranoid but because they keep putting themselves deliberately into paranoid avoidable situations";
            string[] storePara = para.Split();
            MyMapNode<int, string> hash1 = new MyMapNode<int, string>(storePara.Length);
            int temp = 0;
            foreach (string word in storePara)
            {
                hash1.Add(temp, word);
                temp++;
            }

            hash.Remove(hash1, "avoidable");

            Console.ReadLine();
        }
    }
}
