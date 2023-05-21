using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    public class Program
    {
        static string[] ReadWordListFromFile(string wordlist)
        {
            string[] wordList = null;

            try
            {
                // Read the content of the file
                string content = File.ReadAllText(wordlist);

                // Split the content by comma to get individual words
                wordList = content.Split(',');

                // Trim each word to remove leading/trailing spaces
                for (int i = 0; i < wordList.Length; i++)
                {
                    wordList[i] = wordList[i].Trim();
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File '{0}' not found.", wordlist);
                Environment.Exit(1);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while reading the file: {0}", ex.Message);
                Environment.Exit(1);
            }

            return wordList;
        }

        static bool BinarySearch(string[] wordList, string searchWord)
        {
            int left = 0;
            int right = wordList.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                int result = string.Compare(wordList[mid], searchWord, StringComparison.OrdinalIgnoreCase);

                if (result == 0)
                {
                    return true; // Word found
                }
                else if (result < 0)
                {
                    left = mid + 1; // Search in the right half
                }
                else
                {
                    right = mid - 1; // Search in the left half
                }
            }

            return false; // Word not found
        }

        static void Main(string[] args)
        {
            // Read the list of words from a file
            string[] wordList = ReadWordListFromFile("wordlist.txt");

            // Sort the word list
            Array.Sort(wordList);

            // Prompt the user to enter a word to search
            Console.Write("Enter a word to search: ");
            string searchWord = Console.ReadLine();

            // Perform binary search on the sorted word list
            bool isFound = BinarySearch(wordList, searchWord);

            // Print the result
            if (isFound)
            {
                Console.WriteLine("The word '{0}' is found in the list.", searchWord);
            }
            else
            {
                Console.WriteLine("The word '{0}' is not found in the list.", searchWord);
            }
        }
    }
}
