using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Studio2CountingCharacters
{
    class Program
    {
        static void Main(string[] args)
        {

            string sampleText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc accumsan sem ut ligula scelerisque sollicitudin." +
                " Ut at sagittis augue. Praesent quis rhoncus justo. Aliquam erat volutpat. Donec sit amet suscipit metus, non lobortis massa. " +
                "Vestibulum augue ex, dapibus ac suscipit vel, volutpat eget massa. Donec nec velit non ligula efficitur luctus.";


            Console.WriteLine("Counting Character Studio\n");


            // Bonus Mission - Inpit from user
            Console.WriteLine("Do you want to add your sample text? (y/n)");
            string input = Console.ReadLine();

            if (input.ToLower() == "y")
            {
                Console.WriteLine("Please enter yout text and press Enter:\n");
                sampleText = Console.ReadLine();
            }


            // Create a new dictionary of integer, with char keys.
            //
            Dictionary<char, int> charCount = new Dictionary<char, int>();

            /*
             * // Case Sensitive
            string sampletext = sampleText;
            */

            // Bonus Mission - Case insensitive 
            string sampletext = sampleText.ToLower();

            // Bonus Mission - Exclude non-alphabetic characters
            Regex rgx = new Regex("[^a-zA-Z]");
            sampletext = rgx.Replace(sampletext, "");


            for (int i = 0; i < sampletext.Length; i++)
            {
                if (!charCount.ContainsKey(sampletext[i]))
                {
                    charCount.Add(sampletext[i], 1);
                }
                else
                {
                    charCount.TryGetValue(sampletext[i], out int value);                    
                    charCount[sampletext[i]] = ++value;
                }
            }


            






            // Print the output to console
            foreach (KeyValuePair<char, int> kvp in charCount)
            {
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }
            
            Console.ReadLine();
        }
    }
}
