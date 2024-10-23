// See https://aka.ms/new-console-template for more information
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
Console.Clear();
Console.ForegroundColor = ConsoleColor.White;
Random rand = new Random();
int originX = Console.CursorLeft;
int originY = Console.CursorTop;
Console.WriteLine("Hello! This program will allow you to practice your typing ability");
Console.WriteLine("Press any key when you are ready to start");
Console.ReadKey();
Console.Clear();
int randParagraph = rand.Next(1,4);
string paragraph = "";
switch(randParagraph)
{
    case 1:
        paragraph = File.ReadAllText(@"Paragraph1.txt");
        break;
    case 2:
        paragraph = File.ReadAllText(@"Paragraph2.txt");
        break;
    default:
        paragraph = File.ReadAllText(@"Paragraph3.txt");
        break;
}
Console.WriteLine(paragraph);
Console.SetCursorPosition(originX, originY);
int numCorrect = 0;
int numIncorrect = 0;
//char typedChar = Console.ReadKey(true).KeyChar;
for(int i = 0; i < paragraph.Length - 1; i++)
{
    char typedChar = Console.ReadKey(true).KeyChar;
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
}
Console.Clear();
int accuracy = numCorrect/paragraph.Length;
Console.WriteLine($"you had {accuracy*100}% accuracy!");

