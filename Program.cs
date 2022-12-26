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
            Random wordPickerIndex = new();
            // creates a variable that stores our indexposition chosen by our random, taking words total count as maxvalue
            // picks the word randomly
            var pickIndex = wordPickerIndex.Next(Words.Count);


            // creates a string called currenthangmanword
            string currentHangManWord = Words[pickIndex];
            // prints the selected word
            Console.WriteLine(currentHangManWord);

            // creates a list to fill with our characters from our randomly picked word
            List<string> letterOfOurChosenWord = new();

            // for every letter in the currentword, iteraate and add the character read to its own element position, thus creating a list of characters
            foreach (char u in currentHangManWord)
            {
                // fills our empty character list with our characters from our current hang man word
                // adds a new position and calls to string on the read char to add it to our list of string characters
                letterOfOurChosenWord.Add(u.ToString());
            }
            // our input
            var charactersLeft = currentHangManWord.Length;
            string guess;

            List<string> guessedLetters = new();

            // main game functionality 

            do
            {
                do
                {
                    Console.WriteLine("Type your guess");
                    guess = Console.ReadLine();
                    if ((guess == string.Empty) || guess == "")
                    {
                        Console.WriteLine("Your input was not acceptable. a letter please.");
                    }



                }
                while ((guess == string.Empty) && (guess == ""));

                // will store our guessed letters


                foreach (string item in letterOfOurChosenWord)
                {
                    if (guessedLetters)
                        // registers our guessed letters
                        if (letterOfOurChosenWord.Contains(item))
                        {
                            Console.Write(item);
                        }

                    // checks our registered letters and the ones we already have, we print

                    // if our guess is equal to our current element in iteration, print it
                    if (guess == item)
                    {

                        Console.Write(item);

                    }
                    // else, dont print it
                    else { Console.Write("*"); }
                }


            } while (charactersLeft > guessedLetters.Count);

        }



    }

}
