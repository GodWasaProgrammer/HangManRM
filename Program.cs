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

            // sets the var characters left to the length of the randomly selected word
            var charactersLeft = currentHangManWord.Length + 5;
            // our input
            string guess;
            List<string> guessedLetters = new();
            // main game functionality 
            string gameLoop;
            do
            {
                Console.WriteLine("\nWelcome to Hangman");
                Console.WriteLine("A game where you have to guess letters in a word");

                do
                {


                    do
                    {
                        foreach (string item in letterOfOurChosenWord)
                        {
                            // if our guess is equal to our current element in iteration, print it
                            if (guessedLetters.Contains(item))
                            {
                                Console.Write(item);
                            }

                            // else, dont print it
                            else
                            {
                                Console.Write("_");
                            }

                        }
                        Console.WriteLine("\nType your guess");
                        guess = Console.ReadLine();

                        if (guessedLetters.Contains(guess))
                        {
                            Console.WriteLine("Dont be a fool... you already tried that!");

                        }
                        // disallows empty guesses, 
                        if ((guess == string.Empty) || (guess == ""))
                        {
                            Console.WriteLine("Your input was not acceptable. ONE letter please.");

                        }
                        // or guesses that exceeds one character
                        if (guess.Length > 1)
                        {
                            Console.WriteLine("Single characters... pretty please with sugar on top");
                        }




                    }// while guess is empty or input longer then 1
                    while ((guess == string.Empty) || (guess == "") || (guess.Length > 1));
                    // tells you how many chances you got left
                    Console.WriteLine($"Your current chances left: {charactersLeft}");
                    //  shortens the game by 1 if you had a valid guess
                    charactersLeft--;

                    // will store our guessed letters
                    guessedLetters.Add(guess);



                } while (charactersLeft > 0);
                Console.WriteLine("If you would like to play again, please enter y");
                gameLoop = Console.ReadLine();
            }

            while (gameLoop == "y");

        }
    }
}
