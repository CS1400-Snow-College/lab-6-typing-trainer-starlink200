// See https://aka.ms/new-console-template for more information
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;
bool repeat = true;
Random rand = new Random();

while(repeat)
{
    repeat = false;
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.White;
    Stopwatch stopwatch = new Stopwatch();
    Console.WriteLine("Hello! This program will allow you to practice your typing ability by timing your typing speed and accuracy");
    Console.WriteLine("Press any key when you are ready to start");
    Console.ReadKey();
    stopwatch.Start();

    Console.Clear();
    //create a random number to help choose which paragraph to use
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
    int originX = Console.CursorLeft;
    int originY = Console.CursorTop;
    Console.WriteLine(paragraph);
    Console.SetCursorPosition(originX, originY);

    int numCorrect = 0;
    int numIncorrect = 0;
    double elapsedSeconds = 0;

    for(int i = 0; i < paragraph.Length - 1; i++)
    {
        char typedChar = Console.ReadKey(true).KeyChar;
        elapsedSeconds = stopwatch.ElapsedMilliseconds / 1000;
        if(typedChar == paragraph[i])
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(paragraph[i]);
            numCorrect++;
            typedParagraph += paragraph[i];
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(paragraph[i]);
            numIncorrect++;
        }
        // force the loop to break once 60 seconds have elapsed
        if(elapsedSeconds == 60)
        {
            i = paragraph.Length;
        }
    }
    stopwatch.Stop();

    Console.Clear();
    Console.ForegroundColor = ConsoleColor.White;
    //accuracy is only tested against the number of characters that they actually managed to type
    double accuracy = (double) numCorrect/typedParagraph.Length;
    //the standardized way to count words is every 5 characters is one "word" so the number of characters in typedParagraph by 5
    double wpm = (typedParagraph.Length / 5) / (elapsedSeconds/60);
    Console.WriteLine($"You had {accuracy*100:##.#}% accuracy!");
    Console.WriteLine($"And you typed {wpm} WPM");
    
    //while loop asking user if they want to play again, only accepting 4 values, 1, yes, 2, no
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

