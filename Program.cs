// See https://aka.ms/new-console-template for more information
Random rand = new Random();
Console.WriteLine("Hello! This program will allow you to practice your typing ability");
string[] paragraphChoices = {"Words per minute (WPM) is a measure of typing speed, commonly used in recruitment. For the purposes of WPM measurement a word is standardized to five characters or keystrokes. Therefore, \"brown\" counts as one word, but \"accounted\" counts as two. The benefits of a standardized measurement of input speed are that it enables comparison across language and hardware boundaries. The speed of an Afrikaans-speaking operator in Cape Town can be compared with a French-speaking operator in Paris.",
"Two competing software companies, AlphaTech and Beta Solutions, were constantly vying for market share. After years of rivalry, their CEOs, Mark and Lisa, found themselves seated next to each other on a long flight. They struck up a conversation, discovering shared frustrations with industry challenges. This chance encounter led to a groundbreaking partnership. By combining their strengths, AlphaTech and Beta Solutions developed a revolutionary product that captured 50% of the market within a year, proving that sometimes, collaboration can be more powerful than competition."};
int randParagraph = rand.Next(0,2);
string paragraph = paragraphChoices[randParagraph];
Console.WriteLine(paragraph);
for(int i = 0; i < paragraph.Length; i++)
{
    if(paragraph[i].Equals(Console.ReadKey()))
    {
        Console.WriteLine("this is working so far");
    }
    else{
        Console.WriteLine("is not working");
    }
    
}