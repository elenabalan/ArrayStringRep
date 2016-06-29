using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Strings
{
    class Program
    {
        public static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write("{0}  ", arr[i]);
            Console.WriteLine();
        }
        #region STRING
        public static int CountCharacters(string s, char c)
        {
            return (s.Split(c)).Length - 1;
        }
        public static void CountCharacters(string s)
        {
            char[] chars = s.ToCharArray();

            chars.Select(x => x == 'T');

            int count = 0;
            for (int i = 0; i < chars.Length; i++)
            {
                char elem = chars[i];
                for (int j = i + 1; j < chars.Length; j++)
                    if ((chars[j] == elem) && (chars[j] != '\0'))
                    {
                        Array.Clear(chars, j, 1);
                        count++;
                    }
            }
            char[] temp = new char[s.Length - count];
            int it = 0;
            for (int i = 0; i < chars.Length; i++)
                if (chars[i] != '\0')
                {
                    temp[it] = chars[i];
                    it++;
                }

            int countElem = 0;
            char element;
            chars = s.ToCharArray();
            for (int i = 0; i < temp.Length; i++)
            {
                element = temp[i];
                countElem = 0;
                for (int j = 0; j < chars.Length; j++)
                {
                    if (chars[j] == element)
                        countElem++;

                }
                Console.WriteLine("The letter {0} is occurred {1} times", element, countElem);
            }
        }
        #endregion

        #region Words containing not more than n characters
        public static void DisplayWordsNChar(string s, int n)
        {
            string[] delim = { " ", ",", ".", "!", "?", "-",". " };
            string[] temp = s.Split(delim,StringSplitOptions .RemoveEmptyEntries);
            //for (int i = 0; i < temp.Length; i++)
            //    Console.Write(temp[i] + "\t");
            //Console.WriteLine("WordCount = {0}", temp.Length);
            for (int i = 0; i < temp.Length; i++)
                if (temp[i].Length <=n)
                    Console.Write(temp[i] + "\t");

        }
        #endregion
        #region Reverse String
        public static string ReverseString(string s)
        {
            StringBuilder rez = new StringBuilder();
            for (int i=s.Length-1;i>=0 ;i--)
            {
                rez.Append(s[i]);
            }
            return rez.ToString();
        }
        #endregion
        #region Perfect numbers
        public static int SumElements(int[] arr)
        {
            int rez = 0;
            for (int i = 0; i < arr.Length; i++)
                rez += arr[i];
            return rez;
        }
        public static bool IsPerfect(int n, out int[] factors)
        {
            int countFactors=1;
            for (int i = 2; i <= n / 2; i++)
                if (n % i == 0)
                    countFactors++;
            factors = new int[countFactors];
            factors[0] = 1;
            int index = 1;
            for (int i = 2; i <= n / 2; i++)
                if (n % i == 0)
                {
                    factors[index] = i;
                    index++;
                }
            if (SumElements(factors) == n)
                return true;
            else
                return false;
        }
        #endregion
        static void Main(string[] args)
        {
            string s = "There is any text here. They are more different words with different letters.";
            
            Console.WriteLine(s);

            string repl = s.Replace("er", "ER");
            Console.WriteLine("After replacing er with ER: \n"+repl);
            
            CountCharacters(s);

            Console.WriteLine();
            Console.WriteLine("Display only words containing not more than n characters");
            DisplayWordsNChar(s, 4);
            Console.WriteLine();

            //Console.WriteLine();
            //Console.WriteLine("Uses a stack object to print the line reversed");
            //Console.WriteLine("Input string:");
            //string input = Console.ReadLine();
            //Console.WriteLine(ReverseString(input));

            Console.WriteLine();
            int[] factors;
            Console.WriteLine("PERFECT NUMBERS");
            for (int i = 2; i <= 100; i++)
                if (IsPerfect(i, out factors))
                {
                    Console.WriteLine("The number {0} is perfect. Its factors are:", i);
                    PrintArray(factors);
                }
            Console.ReadKey();
        }
    }
}
