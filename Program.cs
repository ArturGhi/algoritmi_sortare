using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace algoritmi_sortare
{
    class Program
    {
        static void Main(string[] args)
        {

         // string path = (@"C:\Users\artur\Desktop\algo.txt");
            Console.WriteLine("Insert path:");
            string path = Console.ReadLine();
            int[] arr = File.ReadLines(path).Select(l => Convert.ToInt32(l)).ToArray();
            Console.WriteLine(String.Join(",", arr));
            bool continu = true;

            while (continu)
{
                Console.WriteLine("\nNumber sort ascending *1");
                Console.WriteLine("Number sort descending *2");
                Console.WriteLine("String sort ascending *3");
                Console.WriteLine("String sort descending *4");
                Console.WriteLine("Hybrid sort *5");
                Console.WriteLine("Exit 6");
               
                string menu = Console.ReadLine();

                switch (menu)
                {
                    case "1" :
                        crescator(path);
                        break;

                    case "2":
                        descrescator(path);
                        break;

                    case "3":
                        tip_string(path); 
                        break;
                    case "4":
                        tip_stringdes(path);
                        break;
                    case "5":
                        hybrid(path);
                        break;
                    case "6":
                    default:
                        continu = false;
                        break;
                }
            }
        }


        public  static void crescator(string cale)
        {

            int[] arr = File.ReadLines(cale).Select(l => Convert.ToInt32(l)).ToArray();
            Array.Sort<int>(arr, delegate (int m, int n)
                { return m - n; });
            Console.WriteLine(String.Join(" ", arr));
        }

        public static void descrescator(string cale)
        {
            int[] arr = File.ReadLines(cale).Select(l => Convert.ToInt32(l)).ToArray();
            Array.Sort<int>(arr, delegate (int m, int n)
            { return n - m; });
            Console.WriteLine(String.Join(" ", arr));
        }


        public static void tip_string(string cale)
        {
            int[] intarray = File.ReadLines(cale).Select(l => Convert.ToInt32(l)).ToArray();
            string[] str = intarray.Select(x => x.ToString()).ToArray();
            var arr = str.OrderBy(x => x).ToArray();
            Console.WriteLine(String.Join(" ", arr));
        }


        public static void tip_stringdes(string cale)
        {
            int[] intarray = File.ReadLines(cale).Select(l => Convert.ToInt32(l)).ToArray();
            string[] str = intarray.Select(x => x.ToString()).ToArray();
            var arr = str.OrderBy(x => x).ToArray();
            var revers = arr.Reverse();
            Console.WriteLine(String.Join(" ", revers));
        }


        public static void hybrid(string cale)
        {
            int[] arr = File.ReadLines(cale).Select(l => Convert.ToInt32(l)).ToArray();
            int n = arr.Length;
            int l = 0, r = n - 1;
            int k = 0;
            while (l < r)
            {
                while (arr[l] % 2 == 0)
                {
                    l++;
                    k++;
                }
                while (arr[r] % 2 != 0 && l < r)
                    r--;
                if (l < r)
                {
                    int temp = arr[l];
                    arr[l] = arr[r];
                    arr[r] = temp;
                }
            }
            Array.Sort(arr, k, n - k);

            Array.Sort(arr, 0, k);
            Array.Reverse(arr, 0, k);
            Console.WriteLine(String.Join(" ", arr));
        }
    }
}
