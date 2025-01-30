using System.IO;
using System;
using System.Collections;
using System.IO.Pipelines;
using System.Text;
class Smith_Hangman{
    static void Main(){
        string[] words = File.ReadAllLines("C:\\Users\\ashle\\.dotnet\\ConsoleApp1\\Hangman.txt");
        Random rand = new Random();
        int num = rand.Next(1, words.Length+1);
        string word = words[num];
        string[] wordArr = new string[word.Length];
        int index = 0;
        foreach(char c in word){
            wordArr[index] = c.ToString();
            index++;
        }
        StringBuilder display = new StringBuilder();
        for(int i = 0; i < word.Length; i++){
            display.Append("_");
        }
        ArrayList guesses = new ArrayList();
        StringBuilder guessesString = new StringBuilder();
        int lives = 10;
        bool guessing = true;
        bool playing = true;
        string guess = "";
        Console.WriteLine("Please guess a letter!");
        while(playing){
            Console.WriteLine(display.ToString());
            Console.WriteLine("Lives Left: " + lives);
            Console.WriteLine("Current Incorrect Guesses: " + guessesString.ToString());
            guessing = true;
            while(guessing){
                guess = Console.ReadLine();
                if(!guesses.Contains(guess) && !guess.Equals("") && Char.IsLetter(guess, 0)){
                    guesses.Add(guess);
                    guessing = false;
                }
                else{
                    Console.WriteLine("Invalid Input! Please try again!");
                }
            }
            bool correct = false;
            for(int i = 0; i < wordArr.Length; i++){
                if(guess.ToUpper().Equals(wordArr[i].ToUpper())){
                    display.Insert(i, wordArr[i]);
                    display.Remove(i+1, 1);
                    correct = true;
                }
            }
            if(correct && display.Equals(word)){
                playing = false;
                Console.WriteLine("Congratualations, you guessed the word correctly and won!");
            }
            else if(correct){
                Console.WriteLine("You guessed a letter! Keep guessing!");
            }
            else if(!correct){
                lives--;
                if(lives == 0){
                    playing = false;
                    Console.WriteLine("You lost! The word was: " + word);
                }
                else{
                    Console.WriteLine("You guessed wrong, keep guessing!");
                    guessesString.Append(guess);
                    guessesString.Append(" ");
                }
            }
        }
    }
}