namespace HangManRM
{
    internal class Program
    {
        static void Main()
        {
            // makes a list of words for our hangman game //
            List<string> words = new()
            {
                "poland",
                "mother",
                "left",
                "right",
                "down",
                "encyclopedia",
                "cunnilingus",
                "arthritis",
                "december",
                "international space station",
                "ShowMeTheMoney",
                "pneumonoultramicroscopicsilicovolcanoconiosis" // longest english word in the dictionary (( possibly disputed )

            };

            // makes a random to pick a word from the list
            Random wordPicker = new();
            // our input
            string guess;
            // main game functionality 
            string gameLoop;
            // do while gameloop equals y
            do
            {

                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                // list of our guess of single char strings
                List<string> guessedLetters = new();
                Console.WriteLine("\nWelcome to Hangman");
                Console.WriteLine("A game where you have to guess letters in a word");
                // creates a variable that stores our indexposition chosen by our random, taking words total count as maxvalue
                // picks the word randomly
                var pickIndex = wordPicker.Next(words.Count);
                // creates a string called currenthangmanword
                string currentHangManWord = words[pickIndex];
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
                // do while chances more then 0
                do
                {
                    // tells you how many chances you got left
                    Console.WriteLine($"Your current chances left: {chances}");
                    // prints out what we guessed, or what is left to guess
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
                            Console.Write("_ ");
                        }

                    }

                    // if we run out of characters, that means we have won the game, tells you and breaks the current do while iteration
                    if (charactersLeft == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("\n CONGRATULATIONS !!! You have WON the game.");
                        // removes the word that you just figured out from the random pool
                        words.RemoveAt(pickIndex);
                        break;

                    }

                    // otherwise resets our charactersleft counter so we can try again
                    else
                    {
                        charactersLeft = currentHangManWord.Length;
                    }

                    // do while for input validation logic
                    do
                    {
                        Console.WriteLine("\nType your guess");
                        guess = Console.ReadLine();

                        if (guessedLetters.Contains(guess))
                        {
                            Console.WriteLine("Dont be a fool... you already tried that!");
                        }

                        // if our list of letters of our random word contains our guess, evaluate next step
                        if (letterOfOurChosenWord.Contains(guess))
                        {
                            // if our guessedletters list does NOT contain our guess, type
                            if (!guessedLetters.Contains(guess))
                            {
                                Console.WriteLine("Your guess was in our word! \n keep going!");
                            }

                        }

                        // if our guessedletters does not contains our guess, check underruling ifs
                        if (!guessedLetters.Contains(guess))
                        {
                            // if our guess is 1 char long
                            if (guess.Length == 1)
                            {
                                // add it to the list of guesses
                                guessedLetters.Add(guess);
                                // if our letters from our word does NOT contain our guess,
                                // and neither does your earlier tries
                                // you lost a chance
                                if (!letterOfOurChosenWord.Contains(guess))
                                {
                                    //  takes away a chance if you had a valid but incorrect guess
                                    chances--;
                                }

                            }

                        }

                        // if your guess is NOT matched to any string in our list of the letter words.
                        if (!letterOfOurChosenWord.Contains(guess))
                        {
                            Console.WriteLine("Your guess was not in the word we looking for.");
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

                        // while empty guess OR length is more then 1, OR guessed letters does NOT contain our guess
                    } while ((guess == string.Empty) || (guess.Length > 1) || (!guessedLetters.Contains(guess)));

                    // and if you run out... all your base...
                    if (chances == 0)
                    {
                        Console.WriteLine("whau u do dis, u are ze loser,\n all your base are belong to us");
                    }

                } while (chances > 0);

                // main gameloop controller, if you enter y, go again, otherwise, bye bye
                Console.WriteLine("If you would like to play again, please enter y");
                gameLoop = Console.ReadLine();
            }
            while (gameLoop == "y");

        }
    }
}
