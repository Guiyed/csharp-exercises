using System;

namespace Search
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "Alice was beginning to get very tired of sitting by her sister on the bank, " +
                "and of having nothing to do: once or twice she had peeped into the book her sister was " +
                "reading, but it had no pictures or conversations in it, 'and what is the use of a book,' " +
                "thought Alice 'without pictures or conversation?'";

            string term;

            Console.WriteLine("Alice in Wonderland\n");
            Console.WriteLine(text);
            Console.WriteLine("\nPlease enter the term you want to search in the text:");
            term = Console.ReadLine();

            if (text.ToLower().Contains(term.ToLower())){
                Console.WriteLine("YES!!! We found the term in the text !!!");
            }
            else{
                Console.WriteLine("Sorry, we could not found your search term");
            }



            Console.ReadLine();
                                 
        }
    }
}
