using System;

namespace ConsoleApplication
{
    class MainClass
    {
        static void Main(string[] args)
        {
            // Store name and location
            var name = "Christopher";
            var location = "Idaho";
            // Output using string interpolation
            Console.WriteLine($"My name is {name}, I am from {location}.");

            // Store today
            DateTime today = DateTime.Today;
            // Output today without time
            Console.WriteLine("Today's date: {0}", today.ToString("d"));

            // Story Christmas
            DateTime christmas = new DateTime(today.Year, 12, 25);

            // Store Days until Christmas
            var days = (christmas - today).Days;
            // Output days until Christmas
            Console.WriteLine($"Days until Christmas: {days}");

            // Call 2.1 from the book
            GlazerCalc();
        }

        static void GlazerCalc ()
        {
            // store our variables
            double width, height, woodLength, glassArea;
            string widthString, heightString;

            // Prompt user for width
            Console.Write("Width: ");
            widthString = Console.ReadLine();
            width = double.Parse(widthString);

            // Prompt user for height
            Console.Write("Height: ");
            heightString = Console.ReadLine();
            height = double.Parse(heightString);

            // Perform calculations
            woodLength = 2 * (width + height) * 3.25;
            glassArea = 2 * (width * height);
            // Output info
            Console.WriteLine("The length of the wood is " +
            woodLength + " feet");
            Console.WriteLine("The area of the glass is " +
            glassArea + " square metres");

            // Wait for user to press enter to finish
            Console.Write("Press <Enter> to exit... ");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
        }
    }
}
