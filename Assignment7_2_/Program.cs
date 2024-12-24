using System;
using System.Linq;

namespace Assignment7_2_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Assignment 7.2.1: Shell Sort
            Console.WriteLine("Assignment 7.2.1");
            Console.WriteLine("================");
            int[] arr = GetArrayFromUser();
            ShellSort(arr);
            Console.WriteLine("Sorted array: " + string.Join(", ", arr));

            // Assignment 7.2.2: Reverse Vowels
            Console.WriteLine("\nAssignment 7.2.2");
            Console.WriteLine("================");
            Console.Write("Enter a string: ");
            string input = Console.ReadLine();
            string reversed = ReverseVowels(input);
            Console.WriteLine($"String with reversed vowels: {reversed}");

            // Assignment 7.2.3: Anagram Check
            Console.WriteLine("\nAssignment 7.2.3");
            Console.WriteLine("================");
            Console.Write("Enter first string: ");
            string s = Console.ReadLine();
            Console.Write("Enter second string: ");
            string t = Console.ReadLine();
            bool isAnagram = IsAnagram(s, t);
            Console.WriteLine($"Are the strings anagrams? {isAnagram}");
        }

        static int[] GetArrayFromUser()
        {
            Console.Write("Enter numbers separated by spaces: ");
            return Console.ReadLine().Split().Select(int.Parse).ToArray();
        }

        static void ShellSort(int[] arr)
        {
            int n = arr.Length;
            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < n; i++)
                {
                    int temp = arr[i];
                    int j;
                    for (j = i; j >= gap && arr[j - gap] > temp; j -= gap)
                    {
                        arr[j] = arr[j - gap];
                    }
                    arr[j] = temp;
                }
            }
        }

        static string ReverseVowels(string s)
        {
            char[] chars = s.ToCharArray();
            int left = 0, right = s.Length - 1;
            string vowels = "aeiouAEIOU";

            while (left < right)
            {
                while (left < right && !vowels.Contains(chars[left]))
                    left++;

                while (left < right && !vowels.Contains(chars[right]))
                    right--;

                if (left < right)
                {
                    char temp = chars[left];
                    chars[left] = chars[right];
                    chars[right] = temp;
                    left++;
                    right--;
                }
            }

            return new string(chars);
        }

        static bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
                return false;

            int[] charCount = new int[26];

            for (int i = 0; i < s.Length; i++)
            {
                charCount[s[i] - 'a']++;
                charCount[t[i] - 'a']--;
            }

            return charCount.All(count => count == 0);
        }
    }
}