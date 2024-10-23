﻿// See https://aka.ms/new-console-template for more information
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;
bool repeat = true;
while(repeat)
{
    repeat = false;
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.White;
    Stopwatch stopwatch = new Stopwatch();
    Random rand = new Random();
    int originX = Console.CursorLeft;
    int originY = Console.CursorTop;
    Console.WriteLine("Hello! This program will allow you to practice your typing ability by timing your typing speed and accuracy");
    Console.WriteLine("Press any key when you are ready to start");
    Console.ReadKey();
    stopwatch.Start();
    Console.Clear();
    int randParagraph = rand.Next(1,6);
    string paragraph = "";
    //create a string that will include the words that the user types
    string typedParagraph = "";
    //switch statement which uses the randParagraph integer to randomly select a training paragraph
    switch(randParagraph)
    {
        case 1:
            paragraph = File.ReadAllText(@"Paragraph1.txt");
            break;
        case 2:
            paragraph = File.ReadAllText(@"Paragraph2.txt");
            break;
        case 4:
            paragraph = File.ReadAllText(@"Paragraph4.txt");
            break;
        case 5:
            paragraph = File.ReadAllText(@"Paragraph5.txt");
            break;
        default:
            paragraph = File.ReadAllText(@"Paragraph3.txt");
            break;
    }
    Console.WriteLine(paragraph);
    Console.SetCursorPosition(originX, originY);
    int numCorrect = 0;
    int numIncorrect = 0;
    double elapsedSeconds = 0;
    for(int i = 0; i < paragraph.Length - 1; i++)
    {
        char typedChar = Console.ReadKey(true).KeyChar;
        elapsedSeconds = stopwatch.ElapsedMilliseconds /  1000;
        if(typedChar == paragraph[i])
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(paragraph[i]);
            numCorrect++;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(paragraph[i]);
            numIncorrect++;
        }
        typedParagraph += paragraph[i];
        // force the loop to break once 60 seconds have elapsed
        if(elapsedSeconds == 60)
        {
            i = paragraph.Length;
        } 
    }
    stopwatch.Stop();
    Console.Clear();
    //split the number of characters typed into words to know how many words were typed roughly
    string[] wordsTyped = typedParagraph.Split();
    //accuracy is only tested against the number of characters that they actually managed to type
    double accuracy = (double) numCorrect/typedParagraph.Length;
    double wpm = wordsTyped.Count() / (elapsedSeconds/60);
    Console.WriteLine($"You had {accuracy*100:##.#}% accuracy!");
    Console.WriteLine($"And you typed {wpm} WPM");
    bool invalidAnswer = true;
    while(invalidAnswer)
    {
        Console.WriteLine("Would you like to try again? 1: Yes 2: No");
        string playAgain = Console.ReadLine().ToLower();
        if(playAgain.Equals("1") || playAgain.Equals("yes"))
        {
            repeat = true;
            invalidAnswer = false;
        }
        else if(playAgain.Equals("2") || playAgain.Equals("no"))
        {
            repeat = false;
            invalidAnswer = false;
        }
        else
        {
            Console.WriteLine("Please give a valid answer");
            invalidAnswer = true;
        }
    }
}

