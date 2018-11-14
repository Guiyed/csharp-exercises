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


            // Bonus Mission - Input from user
            Console.WriteLine("Do you want to add your sample text? (y/n)");
            string input = Console.ReadLine();

            if (input.ToLower() == "y")
            {
                Console.WriteLine("Please enter yout text and press Enter:\n");
                sampleText = Console.ReadLine();
            }

            //
            else
            {
                Console.WriteLine("Do you want to use the test.txt file instead? (y/n)");
                input = Console.ReadLine();

                if (input.ToLower() == "y")
                {
                    // Read the file as one string.
                    sampleText = System.IO.File.ReadAllText(@"D:\Launch Code\LC101\csharp-exercises\Studio2CountingCharacters\test.txt");
                }

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


                /* Other Way
             * foreach (char letter in sampleText){
             *  if (dictionary.ConstainsKey(letter){
             *      dictionary[letter] = dictionary[letter] +1;
             *  }
             *  else{
             *      dictionary[letter] = 1;
             *  }
             * }
             */


            






            // Print the output to console
            foreach (KeyValuePair<char, int> kvp in charCount)
            {
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }
            
            Console.ReadLine();
        }
    }
}
