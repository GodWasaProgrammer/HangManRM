namespace HangManRM
{
    internal class Program
    {
        static void Main()
        {

            // makes a list of words for our hangman game //

            List<string> Words = new()
            {
                "poland",
                "mother",
                "left",
                "right",
                "down"
            };

            // makes a random to pick a word from the list
            Random wordPickerIndex = new Random();
            // creates a variable that stores our indexposition chosen by our random, taking words total count as maxvalue
            var pickIndex = wordPickerIndex.Next(Words.Count);
            // picks the word randomly

            string currentHangManWord = Words[pickIndex];

            Console.WriteLine(currentHangManWord);

            Console.ReadKey();
        }

    }
}