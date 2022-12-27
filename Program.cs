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
            Random wordPicker = new();
            // creates a variable that stores our indexposition chosen by our random, taking words total count as maxvalue
            // picks the word randomly
            var pickIndex = wordPicker.Next(Words.Count);
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
            // sets the var charactersleft to the length of the randomly selected word
            var charactersLeft = currentHangManWord.Length;
            // sets up a separate integer to evaluate our chances condition
            int chances = charactersLeft + 5;
            // our input
            string guess;
            // list of our guess of single char strings
            List<string> guessedLetters = new();
            // main game functionality 
            string gameLoop;
            do
            {
                Console.WriteLine("\nWelcome to Hangman");
                Console.WriteLine("A game where you have to guess letters in a word");
                do
                {
                    // checks if you have won and if you did, breaks out of loop before chances is evaluated
                    if (charactersLeft == 0)
                    {
                        Console.WriteLine("You have won ze game!1111oneone");
                        break;
                    }

                    if (charactersLeft > 0)
                    {
                        // resets our counter for characters, dependent on the amount of iterations done on the print
                        charactersLeft = currentHangManWord.Length;
                    }

                    // tells you how many chances you got left
                    Console.WriteLine($"Your current chances left: {chances}");
                    do
                    {
                        foreach (string item in letterOfOurChosenWord)
                        {

                            // if our guessedletters is equal to our current element in iteration, print it , reads from a list of guessedletters
                            if (guessedLetters.Contains(item))
                            {
                                Console.Write(item);
                                charactersLeft--;
                            }

                            // else, dont print it
                            else
                            {
                                Console.Write("_");
                            }

                            if (charactersLeft == 0)
                            {
                                Console.WriteLine("You have won the game.");
                            }


                        }


                        Console.WriteLine("\nType your guess");
                        guess = Console.ReadLine();

                        if (guessedLetters.Contains(guess))
                        {
                            Console.WriteLine("Dont be a fool... you already tried that!");
                        }

                        // disallows empty guesses, 
                        if (guess == string.Empty)
                        {
                            Console.WriteLine("Your input was empty");
                        }

                        // or guesses that exceeds one character
                        if (guess.Length > 1)
                        {
                            Console.WriteLine("Single characters... pretty please with sugar on top");
                        }

                        if (chances == 0)
                        {
                            Console.WriteLine("whau u do dis, u are ze loser,\n all your base are belong to us");
                        }



                    }// while guess is empty or input longer then 1
                    while ((guess == string.Empty) || (guess.Length > 1) || guessedLetters.Contains(guess));

                    guessedLetters.Add(guess);



                    //  takes away a chance if you had a valid guess
                    chances--;

                    if (charactersLeft == 0)
                    {
                        Console.WriteLine("You have won ze game!1111oneone");
                        break;
                    }

                    if (charactersLeft > 0)
                    {
                        // resets our counter for characters, dependent on the amount of iterations done on the print
                        charactersLeft = currentHangManWord.Length;
                    }

                } while (chances > 0);

                Console.WriteLine("If you would like to play again, please enter y");
                gameLoop = Console.ReadLine();
            }
            while (gameLoop == "y");

        }
    }
}
